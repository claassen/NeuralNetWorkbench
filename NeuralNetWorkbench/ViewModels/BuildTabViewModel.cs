using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NeuralNetWorkbench.Framework;
using NeuralNetWorkbench.Models;
using NeuralNetWorkbench.Controls;
using NeuralNetWorkbench.ControlModels;
using NeuralNetwork;
using NeuralNetwork.Layers;
using NeuralNetwork.DataSetProviders;
using System.IO;

namespace NeuralNetWorkbench.ViewModels
{
    public class BuildTabViewModel : TabViewModel
    {
        #region Properties

        private ObservableCollection<LayerControl> m_Layers;
        private List<string> m_LayerTypes;
        private string m_SelectedLayerType;
        private string m_NetworkName;

        public ObservableCollection<LayerControl> Layers
        {
            get { return m_Layers; }
            set
            {
                if (m_Layers != value)
                {
                    m_Layers = value;
                    RaisePropertyChanged(() => Layers);
                }
            }
        }

        public List<string> LayerTypes
        {
            get { return m_LayerTypes; }
            set
            {
                if (m_LayerTypes != value)
                {
                    m_LayerTypes = value;
                    RaisePropertyChanged(() => LayerTypes);
                }
            }
        }

        public string SelectedLayerType
        {
            get { return m_SelectedLayerType; }
            set
            {
                if (m_SelectedLayerType != value)
                {
                    m_SelectedLayerType = value;
                    RaisePropertyChanged(() => SelectedLayerType);
                }
            }
        }

        public string NetworkName
        {
            get { return m_NetworkName; }
            set
            {
                if (m_NetworkName != value)
                {
                    m_NetworkName = value;
                    RaisePropertyChanged(() => NetworkName);
                }
            }
        }

        #endregion

        public ICommand AddLayerCommand { get { return new DelegateCommand(ExecuteAddLayerCommand, CanExecuteAddLayer); } }
        public ICommand SaveNetworkCommand { get { return new DelegateCommand(ExecuteSaveNetworkCommand, CanExecuteSaveNetworkCommand); } }
        public ICommand LoadNetworkCommand { get { return new DelegateCommand(ExecuteLoadNetworkCommand); } }

        public BuildTabViewModel()
        {
        }

        public BuildTabViewModel(MainWindowViewModel parent) 
            : base(parent)
        {
            Title = "Build";

            Layers = new ObservableCollection<LayerControl>()
            {
                new InputLayerControl()
            };

            LayerTypes = Models.LayerTypes.GetLayerTypes();

            SelectedLayerType = m_LayerTypes[0];
        }

        public void RemoveLayer(LayerControl layer)
        {
            Layers.Remove(layer);
        }

        private void ExecuteAddLayerCommand()
        {
            switch (SelectedLayerType)
            {
                case Models.LayerTypes.FULLY_CONNECTED:
                    Layers.Add(new FullyConnectedLayerControl(this));
                    break;

                case Models.LayerTypes.CONVOLUTIONAL:
                    Layers.Add(new ConvolutionalLayerControl(this));
                    break;

                case Models.LayerTypes.OUTPUT:
                    Layers.Add(new OutputLayerControl(this));
                    break;
            }
        }

        private bool CanExecuteAddLayer()
        {
            return !HasOutputLayer();
        }

        private bool HasOutputLayer()
        {
            return Layers.Any(l => l is OutputLayerControl);
        }

        private void ExecuteSaveNetworkCommand()
        {
            BuildNetwork();
            System.Windows.Forms.SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
            dlg.AddExtension = true;
            dlg.DefaultExt = "xml";
            dlg.FileName = NetworkName;
            dlg.OverwritePrompt = true;

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ApplicationContext.Network.SaveToDisk(dlg.FileName);
            }
        }

        private bool CanExecuteSaveNetworkCommand()
        {
            return HasOutputLayer();
        }

        private void ExecuteLoadNetworkCommand()
        {
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                NeuralNetwork.NeuralNetwork network = new NeuralNetwork.NeuralNetwork();
                network.LoadFromDisk(dlg.FileName);

                NetworkName = Path.GetFileNameWithoutExtension(dlg.FileName);
                
                Layers.Clear();

                Layers.Add(new InputLayerControl(network.InputLayer, network.InputLayer.DataSetProvider));

                foreach (HiddenLayer layer in network.HiddenLayers)
                {
                    if (layer is ConvolutionalLayer)
                    {
                        Layers.Add(new ConvolutionalLayerControl(this, layer as ConvolutionalLayer));
                    }
                    else if (layer is FullyConnectedLayer)
                    {
                        Layers.Add(new FullyConnectedLayerControl(this, layer as FullyConnectedLayer));
                    }
                }

                Layers.Add(new OutputLayerControl(this, network.OutputLayer));

                ApplicationContext.Network = network;
            }
        }

        private void BuildNetwork()
        {
            IDataSetProvider dataSetProvider = null;
            InputLayer inputLayer = null;
            List<HiddenLayer> hiddenLayers = new List<HiddenLayer>();
            OutputLayer outputLayer = null;

            foreach (LayerControl layer in Layers)
            {
                LayerModelBase model = layer.DataContext as LayerModelBase;

                if (model is InputLayerModel)
                {
                    dataSetProvider = (model as InputLayerModel).DataSetProvider.Provider;
                    inputLayer = (model as InputLayerModel).GetLayer();
                }
                else if (model is FullyConnectedLayerModel)
                {
                    hiddenLayers.Add((model as FullyConnectedLayerModel).GetLayer());
                }
                else if (model is ConvolutionalLayerModel)
                {
                    hiddenLayers.Add((model as ConvolutionalLayerModel).GetLayer());
                }
                else if (model is OutputLayerModel)
                {
                    outputLayer = (model as OutputLayerModel).GetLayer(dataSetProvider.ResultSize());
                }
            }

            ApplicationContext.Network = new NeuralNetwork.NeuralNetwork(dataSetProvider, NetworkName, inputLayer, hiddenLayers, outputLayer/*, LearningRate, Momentum, WeightDecay*/);
        }
    }
}

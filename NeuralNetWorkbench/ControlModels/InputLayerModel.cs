using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetWorkbench.Framework;
using NeuralNetWorkbench.Adapters;
using NeuralNetwork.DataSetProviders;
using NeuralNetwork.Layers;

namespace NeuralNetWorkbench.ControlModels
{
    public class InputLayerModel : LayerModelBase
    {
        private List<DataSetProviderAdapter> m_DataSetProviders;
        private DataSetProviderAdapter m_DataSetProvider;
        
        public List<DataSetProviderAdapter> DataSetProviders
        {
            get { return m_DataSetProviders; }
            set
            {
                if (m_DataSetProviders != value)
                {
                    m_DataSetProviders = value;
                    RaisePropertyChanged(() => DataSetProviders);
                }
            }
        }

        public DataSetProviderAdapter DataSetProvider
        {
            get { return m_DataSetProvider; }
            set
            {
                if (m_DataSetProvider != value)
                {
                    m_DataSetProvider = value;
                    RaisePropertyChanged(() => DataSetProvider);
                }
            }
        }

        public InputLayerModel()
        {
            m_DataSetProviders = new List<DataSetProviderAdapter>()
            {
                new DataSetProviderAdapter(new MNISTDataSetProvider(), "MNIST"),
                new DataSetProviderAdapter(new LogicalXOrDataSetProvider(), "XOR"),
                new DataSetProviderAdapter(new SinFunctionDataSetProvider(), "Sin function"),
                new DataSetProviderAdapter(new LogicalAndDataSetProvider(), "Logical AND")
            };

            m_DataSetProvider = m_DataSetProviders[0];
        }

        public InputLayer GetLayer()
        {
            return new InputLayer(DataSetProvider.Provider);
        }
    }
}

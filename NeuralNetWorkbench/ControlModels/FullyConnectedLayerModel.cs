using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetWorkbench.Framework;
using System.Windows.Input;
using NeuralNetWorkbench.ViewModels;
using NeuralNetWorkbench.Controls;
using NeuralNetwork.Layers;

namespace NeuralNetWorkbench.ControlModels
{
    public class FullyConnectedLayerModel : LayerWithActivationFunction
    {
        private int m_NumNodes;

        public int NumNodes
        {
            get { return m_NumNodes; }
            set
            {
                if (m_NumNodes != value)
                {
                    m_NumNodes = value;
                    RaisePropertyChanged(() => NumNodes);
                }
            }
        }

        public FullyConnectedLayer GetLayer()
        {
            return new FullyConnectedLayer(ActivationFunctionType.Type, NumNodes);
        }

        public void SetLayer(FullyConnectedLayer layer)
        {
            ActivationFunctionType = ActivationFunctionTypes.First(t => t.Type == layer.ActivationFuncType);
            NumNodes = layer.NumNodes;
        }
    }
}

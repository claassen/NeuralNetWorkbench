using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetWorkbench.Framework;
using NeuralNetWorkbench.Adapters;
using NeuralNetwork.Layers;

namespace NeuralNetWorkbench.ControlModels
{
    public class OutputLayerModel : LayerWithActivationFunction
    {
        public OutputLayerModel()
        {
            ActivationFunctionTypes.Add(new ActivationFunctionTypeAdapter(NeuralNetwork.Functions.ActivationFunctionType.Softmax, "Softmax"));
        }

        public OutputLayer GetLayer(int numNodes)
        {
            return new OutputLayer(ActivationFunctionType.Type, numNodes);
        }

        public void SetLayer(OutputLayer layer)
        {
            ActivationFunctionType = ActivationFunctionTypes.First(t => t.Type == layer.ActivationFuncType);
        }
    }
}

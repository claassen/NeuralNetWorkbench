using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetWorkbench.Models
{
    public static class LayerTypes
    {
        public const string FULLY_CONNECTED = "Fully Connected";
        public const string CONVOLUTIONAL = "Convolutional";
        public const string OUTPUT = "Output";

        public static List<string> GetLayerTypes()
        {
            return new List<string>()
            {
                FULLY_CONNECTED,
                CONVOLUTIONAL,
                OUTPUT
            };
        }
    }
}

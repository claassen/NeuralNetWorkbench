using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetwork;

namespace NeuralNetWorkbench.Models
{
    public class ApplicationContext
    {
        public static NeuralNetwork.NeuralNetwork Network { get; set; }
        public static NetworkManager NetworkManager { get; set; }
    }
}

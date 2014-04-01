using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetWorkbench.Framework;
using NeuralNetwork;
using NeuralNetwork.Functions;

namespace NeuralNetWorkbench.Adapters
{
    public class ActivationFunctionTypeAdapter : AdapterBase
    {
        private ActivationFunctionType m_Type;

        public ActivationFunctionType Type
        {
            get { return m_Type; }
            set
            {
                if (m_Type != value)
                {
                    m_Type = value;
                    RaisePropertyChanged(() => Type);
                }
            }
        }

        public ActivationFunctionTypeAdapter(ActivationFunctionType type, string name)
        {
            Type = type;
            DisplayName = name;
        }
    }
}

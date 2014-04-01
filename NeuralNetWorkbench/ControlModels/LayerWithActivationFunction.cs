using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using NeuralNetWorkbench.Adapters;

namespace NeuralNetWorkbench.ControlModels
{
    public class LayerWithActivationFunction : LayerModelBase
    {
        private ObservableCollection<ActivationFunctionTypeAdapter> m_ActivationFunctionTypes;
        private ActivationFunctionTypeAdapter m_ActivationFunctionType;

        public ObservableCollection<ActivationFunctionTypeAdapter> ActivationFunctionTypes
        {
            get { return m_ActivationFunctionTypes; }
            set
            {
                if (m_ActivationFunctionTypes != value)
                {
                    m_ActivationFunctionTypes = value;
                    RaisePropertyChanged(() => ActivationFunctionTypes);
                }
            }
        }

        public ActivationFunctionTypeAdapter ActivationFunctionType
        {
            get { return m_ActivationFunctionType; }
            set
            {
                if (m_ActivationFunctionType != value)
                {
                    m_ActivationFunctionType = value;
                    RaisePropertyChanged(() => ActivationFunctionType);
                }
            }
        }

        public LayerWithActivationFunction()
        {
            m_ActivationFunctionTypes = new ObservableCollection<ActivationFunctionTypeAdapter>()
            {
                new ActivationFunctionTypeAdapter(NeuralNetwork.Functions.ActivationFunctionType.Tanh, "Tanh"),
                new ActivationFunctionTypeAdapter(NeuralNetwork.Functions.ActivationFunctionType.Sigmoid, "Sigmoid")
            };

            m_ActivationFunctionType = m_ActivationFunctionTypes.First();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetWorkbench.Framework;
using NeuralNetwork;
using NeuralNetwork.DataSetProviders;

namespace NeuralNetWorkbench.Adapters
{
    public class DataSetProviderAdapter : AdapterBase
    {
        private IDataSetProvider m_Provider;

        public IDataSetProvider Provider
        {
            get { return m_Provider; }
            set
            {
                if (m_Provider != value)
                {
                    m_Provider = value;
                    RaisePropertyChanged(() => Provider);
                }
            }
        }

        public DataSetProviderAdapter(IDataSetProvider provider, string name)
        {
            Provider = provider;
            DisplayName = name;
        }
    }
}

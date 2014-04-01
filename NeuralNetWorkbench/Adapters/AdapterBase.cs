using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetWorkbench.Framework;

namespace NeuralNetWorkbench.Adapters
{
    public class AdapterBase : NotificationObject
    {
        private string m_DisplayName;

        public string DisplayName
        {
            get { return m_DisplayName; }
            set
            {
                if (m_DisplayName != value)
                {
                    m_DisplayName = value;
                    RaisePropertyChanged(() => DisplayName);
                }
            }
        }

        public override string ToString()
        {
            return m_DisplayName;
        }
    }
}

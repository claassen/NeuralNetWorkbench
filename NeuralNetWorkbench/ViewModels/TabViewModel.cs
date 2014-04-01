using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetWorkbench.Framework;
using System.Windows.Threading;

namespace NeuralNetWorkbench.ViewModels
{
    public class TabViewModel : BaseViewModel
    {
        protected MainWindowViewModel ParentViewModel;
        protected Dispatcher m_Dispatcher;

        private string m_Title;

        public TabViewModel()
        {
        }

        public TabViewModel(MainWindowViewModel parent)
        {
            ParentViewModel = parent;
            m_Dispatcher = Dispatcher.CurrentDispatcher;
        }

        public string Title
        {
            get { return m_Title; }
            set
            {
                if (m_Title != value)
                {
                    m_Title = value;
                    RaisePropertyChanged(() => m_Title);
                }
            }
        }
    }
}

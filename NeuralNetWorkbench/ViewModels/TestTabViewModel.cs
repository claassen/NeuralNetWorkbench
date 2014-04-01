using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using NeuralNetWorkbench.Framework;
using NeuralNetWorkbench.Models;
using System.ComponentModel;

namespace NeuralNetWorkbench.ViewModels
{
    public class TestTabViewModel : TabViewModel
    {
        private BackgroundWorker m_Worker;
        
        #region Properties

        private int m_TestingProgress;
        private bool m_TestingInProgress;

        public int TestingProgress
        {
            get { return m_TestingProgress; }
            set
            {
                if (m_TestingProgress != value)
                {
                    m_TestingProgress = value;
                    RaisePropertyChanged(() => TestingProgress);
                }
            }
        }

        public bool TestingInProgress
        {
            get { return m_TestingInProgress; }
            set
            {
                if (m_TestingInProgress != value)
                {
                    m_TestingInProgress = value;
                    RaisePropertyChanged(() => TestingInProgress);
                }
            }
        }

        #endregion

        public ICommand TestCommand { get { return new DelegateCommand(ExecuteTestCommand); } }

        public TestTabViewModel(MainWindowViewModel parent)
            : base(parent)
        {
            Title = "Test";
        }

        private void ExecuteTestCommand()
        {
            m_Worker = new BackgroundWorker();
            m_Worker.WorkerReportsProgress = true;
            m_Worker.WorkerSupportsCancellation = true;

            int total = 0;
            int correct = 0;

            int progressUpdateFreq = Math.Max(1, (int)(10000 * 0.01));

            m_Worker.DoWork += new DoWorkEventHandler((o, args) =>
            {
                try
                {
                    ApplicationContext.NetworkManager.TestNetwork((network, input, result, expected) =>
                    {
                        ++total;

                        if (total % progressUpdateFreq == 0)
                        {
                            m_Worker.ReportProgress((int)(((double)total / (double)10000) * 100));
                        }

                        if (network.InputLayer.DataSetProvider.IsCorrect(expected, result))
                        {
                            ++correct;
                        }

                        return !m_Worker.CancellationPending;
                    }, 10000);
                }
                catch (Exception ex)
                {
                    m_Dispatcher.BeginInvoke(new Action(() =>
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }));
                }
            });

            m_Worker.ProgressChanged += new ProgressChangedEventHandler((o, args) =>
            {
                TestingProgress = args.ProgressPercentage;
            });

            m_Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler((o, args) =>
            {
                double percentCorrect = 100 * (double)correct / (double)total;

                System.Windows.Forms.MessageBox.Show(percentCorrect + "%  correct (" + correct + " out of " + total + ")");
                
                TestingInProgress = false;
                CommandManager.InvalidateRequerySuggested();
            });

            TestingInProgress = true;
            m_Worker.RunWorkerAsync();
        }
    }
}

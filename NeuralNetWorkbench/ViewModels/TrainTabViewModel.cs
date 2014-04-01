using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using NeuralNetWorkbench.Framework;
using NeuralNetwork;
using NeuralNetWorkbench.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Threading;
using NeuralNetwork.DataSetProviders;

namespace NeuralNetWorkbench.ViewModels
{
    public class TrainTabViewModel : TabViewModel
    {
        private BackgroundWorker m_Worker;

        #region Properties

        private ObservableCollection<KeyValuePair<double, double>> m_ErrorData;
        private double m_LearningRate;
        private double m_Momentum;
        private double m_WeightDecay;
        private int m_MaxIterations;
        private double m_EarlyStopThreshold;
        private bool m_UseMiniBatchMode;
        private int m_MiniBatchSize;
        private int m_TrainingProgress;
        private bool m_TrainingInProgress;
        private int m_YAxisMax;
        private bool m_IsPaused;
        private bool m_IsSGD;
        private bool m_IsRmsProp;
        private int m_GraphHistoryLength;

        public ObservableCollection<KeyValuePair<double, double>> ErrorData
        {
            get { return m_ErrorData; }
            set 
            {
                if (m_ErrorData != value)
                {
                    m_ErrorData = value;
                    RaisePropertyChanged(() => ErrorData);
                }
            }
        }

        public double LearningRate
        {
            get { return m_LearningRate; }
            set
            {
                if (m_LearningRate != value)
                {
                    m_LearningRate = value;
                    RaisePropertyChanged(() => LearningRate);
                }
            }
        }

        public double Momentum
        {
            get { return m_Momentum; }
            set
            {
                if (m_Momentum != value)
                {
                    m_Momentum = value;
                    RaisePropertyChanged(() => Momentum);
                }
            }
        }

        public double WeightDecay
        {
            get { return m_WeightDecay; }
            set
            {
                if (m_WeightDecay != value)
                {
                    m_WeightDecay = value;
                    RaisePropertyChanged(() => WeightDecay);
                }
            }
        }

        public int MaxIterations
        {
            get { return m_MaxIterations; }
            set
            {
                if (m_MaxIterations != value)
                {
                    m_MaxIterations = value;
                    RaisePropertyChanged(() => MaxIterations);
                }
            }
        }

        public double EarlyStopThreshold
        {
            get { return m_EarlyStopThreshold; }
            set
            {
                if (m_EarlyStopThreshold != value)
                {
                    m_EarlyStopThreshold = value;
                    RaisePropertyChanged(() => EarlyStopThreshold);
                }
            }
        }

        public bool UseMiniBatchMode
        {
            get { return m_UseMiniBatchMode; }
            set
            {
                if (m_UseMiniBatchMode != value)
                {
                    m_UseMiniBatchMode = value;
                    RaisePropertyChanged(() => UseMiniBatchMode);
                }
            }
        }

        public int MiniBatchSize
        {
            get { return m_MiniBatchSize; }
            set
            {
                if (m_MiniBatchSize != value)
                {
                    m_MiniBatchSize = value;
                    RaisePropertyChanged(() => MiniBatchSize);
                }
            }
        }

        public int TrainingProgress
        {
            get { return m_TrainingProgress; }
            set
            {
                if (m_TrainingProgress != value)
                {
                    m_TrainingProgress = value;
                    RaisePropertyChanged(() => TrainingProgress);
                }
            }
        }

        public bool TrainingInProgress
        {
            get { return m_TrainingInProgress; }
            set 
            {
                if (m_TrainingInProgress != value)
                {
                    m_TrainingInProgress = value;
                    RaisePropertyChanged(() => TrainingInProgress);
                } 
            }
        }

        public int YAxisMax
        {
            get { return m_YAxisMax; }
            set
            {
                if (m_YAxisMax != value)
                {
                    m_YAxisMax = value;
                    RaisePropertyChanged(() => YAxisMax);
                }
            }
        }

        public bool IsPaused
        {
            get { return m_IsPaused; }
            set
            {
                if (m_IsPaused != value)
                {
                    m_IsPaused = value;
                    RaisePropertyChanged(() => IsPaused);
                }
            }
        }

        public bool IsSGD
        {
            get { return m_IsSGD; }
            set
            {
                if (m_IsSGD != value)
                {
                    m_IsSGD = value;
                    RaisePropertyChanged(() => IsSGD);
                }
            }
        }

        public bool IsRmsProp
        {
            get { return m_IsRmsProp; }
            set
            {
                if (m_IsRmsProp != value)
                {
                    m_IsRmsProp = value;
                    RaisePropertyChanged(() => IsRmsProp);
                }
            }
        }

        public int GraphHistoryLength
        {
            get { return m_GraphHistoryLength; }
            set
            {
                if (m_GraphHistoryLength != value)
                {
                    m_GraphHistoryLength = value;
                    RaisePropertyChanged(() => GraphHistoryLength);
                }
            }
        }

        #endregion

        public ICommand StartTrainingCommand { get { return new DelegateCommand(ExecuteStartTrainingCommand, CanExecuteStartTrainingCommand); } }
        public ICommand StopTrainingCommand { get { return new DelegateCommand(ExecuteStopTrainingCommand, CanExecuteStopTrainingCommand); } }
        public ICommand PauseTrainingCommand { get { return new DelegateCommand(ExecutePauseTrainingCommand, CanExecutePauseTrainingCommand); } }

        public TrainTabViewModel(MainWindowViewModel parent)
            : base(parent)
        {
            Title = "Train";
            LearningRate = 0.001;
            Momentum = 0.4;
            MaxIterations = 100000;
            EarlyStopThreshold = 0.001;
            GraphHistoryLength = 100000;
        }

        private void ExecuteStartTrainingCommand()
        {
            NeuralNetwork.LearningMethod learningMethod = IsSGD ? NeuralNetwork.LearningMethod.SGD : NeuralNetwork.LearningMethod.RMSPROP;

            ApplicationContext.NetworkManager = new NetworkManager(ApplicationContext.Network, learningMethod, LearningRate, Momentum, WeightDecay);

            m_Worker = new BackgroundWorker();
            m_Worker.WorkerReportsProgress = true;
            m_Worker.WorkerSupportsCancellation = true;

            int count = 0;
            int progressUpdateFreq = Math.Max(1, (int)(MaxIterations * 0.001));

            if (ApplicationContext.NetworkManager.GetNetwork().InputLayer.DataSetProvider is MNISTDataSetProvider)
            {
                YAxisMax = 2;
            }
            else
            {
                YAxisMax = 1;
            }

            double avgError = 1;
            DateTime last = DateTime.Now;

            m_Worker.DoWork += new DoWorkEventHandler((o, args) =>
            {
                try
                {
                    ApplicationContext.NetworkManager.TrainNetwork(MaxIterations, false, UseMiniBatchMode, MiniBatchSize, (network, error) =>
                    {
                        pauseEvt.WaitOne();

                        avgError *= 24;
                        avgError += error;
                        avgError /= 25;

                        ++count;

                        m_Worker.ReportProgress((int)(((double)count / (double)MaxIterations) * 100), avgError);
                        
                        
                        int timeDiff = Math.Max(0, 20 - (int)DateTime.Now.Subtract(last).TotalMilliseconds);
                        last = DateTime.Now;
                        if(timeDiff > 0) Thread.Sleep(timeDiff);

                        if (avgError < EarlyStopThreshold) return false;

                        return !m_Worker.CancellationPending;
                    });
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
                double error = (double)args.UserState;

                ErrorData.Add(new KeyValuePair<double, double>((double)count, error));
                if (ErrorData.Count > GraphHistoryLength)
                {
                    for (int i = 0; i < Math.Max(1, Math.Sqrt(ErrorData.Count - GraphHistoryLength)); i++)
                    {
                        ErrorData.RemoveAt(0);
                    }
                }

                if (count % progressUpdateFreq == 0)
                {
                    TrainingProgress = args.ProgressPercentage;
                }

                //CommandManager.InvalidateRequerySuggested();
            });

            m_Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler((o, args) =>
            {
                TrainingInProgress = false;
                CommandManager.InvalidateRequerySuggested();
            });

            TrainingInProgress = true;
            ErrorData = new ObservableCollection<KeyValuePair<double, double>>();
            m_Worker.RunWorkerAsync();
        }

        private bool CanExecuteStartTrainingCommand()
        {
            return !TrainingInProgress;
        }

        private void ExecuteStopTrainingCommand()
        {
            m_Worker.CancelAsync();
            TrainingInProgress = false;
            if (IsPaused)
            {
                ExecutePauseTrainingCommand();
            }
        }

        private bool CanExecuteStopTrainingCommand()
        {
            return TrainingInProgress;
        }

        ManualResetEvent pauseEvt = new ManualResetEvent(true);
        object pauseLockObj = new object();
        private void ExecutePauseTrainingCommand()
        {
            lock (pauseLockObj)
            {
                if (IsPaused)
                {
                    IsPaused = false;
                    pauseEvt.Set();
                }
                else
                {
                    IsPaused = true;
                    pauseEvt.Reset();
                }
            }
        }

        private bool CanExecutePauseTrainingCommand()
        {
            return TrainingInProgress;
        }
    }
}

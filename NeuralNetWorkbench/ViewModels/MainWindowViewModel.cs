using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using NeuralNetWorkbench.Framework;
using NeuralNetWorkbench.Helpers;
using System.Windows.Media;

namespace NeuralNetWorkbench.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Properties

        private ImageSource m_PreviewImage;

        //tabs
        private ObservableCollection<TabViewModel> m_Tabs;
        private TabViewModel m_SelectedTab;

        public ObservableCollection<TabViewModel> Tabs
        {
            get
            {
                return m_Tabs;
            }
        }

        public TabViewModel SelectedTab
        {
            get { return m_SelectedTab; }
            set
            {
                if (m_SelectedTab != value)
                {
                    m_SelectedTab = value;
                    RaisePropertyChanged(() => SelectedTab);
                }
            }
        }

        public ImageSource PreviewImage
        {
            get { return m_PreviewImage; }
            set
            {
                if (m_PreviewImage != value)
                {
                    m_PreviewImage = value;
                    RaisePropertyChanged(() => PreviewImage);
                }
            }
        }

        #endregion

        public MainWindowViewModel()
        {
            m_Tabs = new ObservableCollection<TabViewModel>()
            {
                new BuildTabViewModel(this),
                new TrainTabViewModel(this),
                new TestTabViewModel(this)
            };

            m_SelectedTab = m_Tabs[1];
        }

        #region Commands

        private void OnTest()
        {
            byte[] data = new byte[10000];

            Random rand = new Random();

            for (int i = 0; i < 10000; i++)
            {
                data[i] = (byte)(rand.Next() * 255);
            }

            PreviewImage = ImageHelper.ImageSourceFromByteArray(data, 100, 100);
        }

        #endregion
    }
}
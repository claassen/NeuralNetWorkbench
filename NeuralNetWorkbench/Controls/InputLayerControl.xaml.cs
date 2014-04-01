using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NeuralNetwork.Layers;
using NeuralNetWorkbench.ControlModels;
using NeuralNetwork.DataSetProviders;

namespace NeuralNetWorkbench.Controls
{
    /// <summary>
    /// Interaction logic for InputLayer.xaml
    /// </summary>
    public partial class InputLayerControl : LayerControl
    {
        public InputLayerControl()
            : base(null)
        {
            InitializeComponent();
        }

        public InputLayerControl(InputLayer layer, IDataSetProvider dataProvider)
            : base(null)
        {
            InitializeComponent();

            InputLayerModel model = DataContext as InputLayerModel;

            model.DataSetProvider = model.DataSetProviders.First(p => p.Provider.GetType() == dataProvider.GetType());
        }
    }
}

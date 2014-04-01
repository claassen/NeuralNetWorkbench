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
using NeuralNetWorkbench.ViewModels;
using NeuralNetwork.Layers;
using NeuralNetWorkbench.ControlModels;

namespace NeuralNetWorkbench.Controls
{
    /// <summary>
    /// Interaction logic for OutputLayer.xaml
    /// </summary>
    public partial class OutputLayerControl : LayerControl
    {
        public OutputLayerControl(BuildTabViewModel parent)
            : base(parent)
        {
            InitializeComponent();
        }

        public OutputLayerControl(BuildTabViewModel parent, OutputLayer layer)
            : base(parent)
        {
            InitializeComponent();

            (DataContext as OutputLayerModel).SetLayer(layer);
        }
    }
}

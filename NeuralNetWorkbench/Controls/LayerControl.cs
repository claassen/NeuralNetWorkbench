using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using NeuralNetWorkbench.ViewModels;
using System.Windows;
using NeuralNetwork;
using NeuralNetwork.Layers;
using NeuralNetWorkbench.ControlModels;

namespace NeuralNetWorkbench.Controls
{
    public class LayerControl : UserControl
    {
        protected BuildTabViewModel m_Parent;

        public LayerControl(BuildTabViewModel parent)
        {
            m_Parent = parent;
        }

        protected void Remove_Click(object sender, RoutedEventArgs e)
        {
            m_Parent.RemoveLayer(this);
        }
    }
}

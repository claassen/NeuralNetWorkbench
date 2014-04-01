using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using NeuralNetWorkbench.ViewModels;

namespace NeuralNetWorkbench.Framework
{
    public class TemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            if (item.GetType() == typeof(BuildTabViewModel))
            {
                return BuildTemplate;
            }
            else if (item.GetType() == typeof(TrainTabViewModel))
            {
                return TrainTemplate;
            }
            else if (item.GetType() == typeof(TestTabViewModel))
            {
                return TestTemplate;
            }

            return null;
        }

        public DataTemplate BuildTemplate { get; set; }
        public DataTemplate TrainTemplate { get; set; }
        public DataTemplate TestTemplate { get; set; }
    }
}

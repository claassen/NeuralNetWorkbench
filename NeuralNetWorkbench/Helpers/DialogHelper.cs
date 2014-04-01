using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace NeuralNetWorkbench.Helpers
{
    public static class DialogHelper
    {
        public static void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}

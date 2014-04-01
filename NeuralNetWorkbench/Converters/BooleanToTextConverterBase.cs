using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace NeuralNetWorkbench.Converters
{
    public class BooleanToTextConverterBase : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return System.Convert.ToBoolean(value, culture) ? GetTrueText() : GetFalseText();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        protected virtual string GetTrueText()
        {
            throw new NotImplementedException();
        }

        protected virtual string GetFalseText()
        {
            throw new NotImplementedException();
        }
    }
}

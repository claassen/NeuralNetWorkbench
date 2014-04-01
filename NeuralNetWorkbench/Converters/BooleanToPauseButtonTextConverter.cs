using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetWorkbench.Converters
{
    public class BooleanToPauseButtonTextConverter : BooleanToTextConverterBase
    {
        protected override string GetTrueText()
        {
            return "Resume";
        }

        protected override string GetFalseText()
        {
            return "Pause";
        }
    }
}

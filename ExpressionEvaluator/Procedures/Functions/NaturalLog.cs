using System;
using System.Globalization;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class NaturalLog : Function
    {
        public NaturalLog(int precedance)
            : base("ln", precedance, 1, false)
        {
            _name2 = "NaturalLog";
            DecimalDecimal = x => {
                double dblResult = Math.Log((double)x);
                if (double.IsNaN(dblResult)) {
                    throw new NotFiniteNumberException("Not a number");
                }
                return decimal.Parse(dblResult.ToString("R"));
            };
        }
    }
}

using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    internal class Power : Operator
    {
        public Power(int precedance)
            : base("^", precedance, 2, false)
        {
            _name2 = "Power";
            DecimalDecimalDecimal = (x, y) => {
                double dblResult = Math.Pow((double)x, (double)y);
                if (double.IsNaN(dblResult)) {
                    throw new NotFiniteNumberException("Not a number");
                }
                return Convert.ToDecimal(dblResult.ToString("R"));
            };
        }
    }
}

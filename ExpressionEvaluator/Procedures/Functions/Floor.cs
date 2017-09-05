using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Floor : Function
    {
        public Floor(int precedance)
            : base("floor", precedance, 1, false)
        {
            _name2 = "floor";
            DecimalDecimal = x => (decimal)Math.Floor(x);
        }
    }
}

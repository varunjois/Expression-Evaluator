using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Ceiling : Function
    {
        public Ceiling(int precedance)
            : base("ceiling", precedance, 1, false)
        {
            _name2 = "ceiling";
            DecimalDecimal = x => (decimal)Math.Ceiling(x);
        }
    }
}

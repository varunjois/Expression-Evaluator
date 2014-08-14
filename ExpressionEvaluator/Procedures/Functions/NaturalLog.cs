using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class NaturalLog : Function
    {
        public NaturalLog(int precedance)
            : base("ln", precedance, 1, false)
        {
            _name2 = "NaturalLog";
            DoubleDouble = Math.Log;
        }
    }
}

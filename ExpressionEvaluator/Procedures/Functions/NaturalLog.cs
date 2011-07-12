using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    class NaturalLog : Function
    {
        public NaturalLog(int precedance) : base("ln", precedance, 1)
        {
            _name2 = "Absolute";
            DoubleDouble = Math.Log;
        }
    }
}
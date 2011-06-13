using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class NaturalLog : Function
    {
        public NaturalLog(int precedance) : base("ln", precedance, 1)
        {
            _name2 = "Absolute";
            _doubledouble = Math.Log;
        }
    }
}
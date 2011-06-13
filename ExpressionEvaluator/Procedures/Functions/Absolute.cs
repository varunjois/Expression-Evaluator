using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Absolute : Function
    {
        public Absolute(int precedance) : base("abs", precedance, 1)
        {
            _name2 = "Absolute";
            _doubledouble = Math.Abs;
        }
    }
}
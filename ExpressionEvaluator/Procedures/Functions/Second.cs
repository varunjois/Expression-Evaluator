using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Second : Function
    {
        public Second(int precedance)
            : base("second", precedance, 1)
        {
            _name2 = "Second";
            DoubleTimespan = x => new TimeSpan(0, 0, Convert.ToInt32(x));
        }
    }
}
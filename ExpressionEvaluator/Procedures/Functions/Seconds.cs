using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    class Seconds : Function
    {
        public Seconds(int precedance)
            : base("seconds", precedance, 1)
        {
            _name2 = "Seconds";
            DoubleTimespan = x => new TimeSpan(0, 0, Convert.ToInt32(x));
        }
    }
}
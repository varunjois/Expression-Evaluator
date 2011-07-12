using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    class Minute : Function
    {
        public Minute(int precedance)
            : base("minute", precedance, 1)
        {
            _name2 = "Minute";
            DoubleTimespan = x => new TimeSpan(0, Convert.ToInt32(x), 0);
        }
    }
}
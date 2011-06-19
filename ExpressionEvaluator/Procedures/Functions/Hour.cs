using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Hour : Function
    {
        public Hour(int precedance)
            : base("hour", precedance, 1)
        {
            _name2 = "Hour";
            DoubleTimespan = x => new TimeSpan(0, Convert.ToInt32(x), 0);
        }
    }
}
using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    class Hour : Function
    {
        public Hour(int precedance)
            : base("hour", precedance, 1)
        {
            _name2 = "Hour";
            DoubleTimespan = x => new TimeSpan(Convert.ToInt32(x), 0, 0);
        }
    }
}
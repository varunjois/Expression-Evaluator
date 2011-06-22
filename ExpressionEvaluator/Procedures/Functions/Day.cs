using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Day : Function
    {
        public Day(int precedance)
            : base("day", precedance, 1)
        {
            _name2 = "Day";
            DoubleTimespan = x => new TimeSpan(Convert.ToInt32(x), 0, 0, 0);
        }
    }
}
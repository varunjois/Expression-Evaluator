using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Now : Function
    {
        public Now(int precedance)
            : base("now", precedance, 0)
        {
            _name2 = "Now";
            Datetime = () => DateTime.Now;
        }
    }
}
using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    class ToString : Function
    {
        public ToString(int precedance)
            : base("tostring", precedance, 1)
        {
            _name2 = "ToString";
            DoubleString = x => x.ToString();
            DateTimeString = x => x.ToString();
            BoolString = x => x.ToString();
            StringString = x => x;
            AnyString = x => x == null ? "null" : x.ToString();
        }
    }
}
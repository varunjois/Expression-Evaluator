using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    internal class Addition : Operator
    {
        public Addition(int precedance)
            : base("+", precedance, 2, false)
        {
            _name2 = "Addition";
            DecimalDecimalDecimal = (x, y) => x+y;
            DatetimeTimespanDatetime = (x, y) => x + y;
            TimespanDatetimeDatetime = (x, y) => y + x;
            TimespanTimespanTimespan = (x, y) => x + y;
        }
    }
}

using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    internal class LesserThan : Operator
    {
        public LesserThan(int precedance)
            : base("<", precedance, 2, false)
        {
            _name2 = "LessThan";
            DecimalDecimalBool = (x, y) => x < y;
            TimespanTimespanBool = (x, y) => x < y;
            DatetimeDatetimeBool = (x, y) => x < y;
        }
    }
}

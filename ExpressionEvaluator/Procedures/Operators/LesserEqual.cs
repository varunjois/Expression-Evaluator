using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    internal class LesserEqual : Operator
    {
        public LesserEqual(int precedance)
            : base("<=", precedance, 2, false)
        {
            _name2 = "LesserEqual";
            DecimalDecimalBool = (x, y) => x <= y;
            TimespanTimespanBool = (x, y) => x <= y;
            DatetimeDatetimeBool = (x, y) => x <= y;
            DecimalDoubleDouble = (x, y) => double.NaN;
            DoubleDecimalDouble = (x, y) => double.NaN;
        }
    }
}

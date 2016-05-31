using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    internal class GreaterEqual : Operator
    {
        public GreaterEqual(int precedance)
            : base(">=", precedance, 2, false)
        {
            _name2 = "GreaterEqual";
            DecimalDecimalBool = (x, y) => x >= y;
            TimespanTimespanBool = (x, y) => x >= y;
            DatetimeDatetimeBool = (x, y) => x >= y;
            DecimalDoubleDouble = (x, y) => double.NaN;
            DoubleDecimalDouble = (x, y) => double.NaN;
        }
    }
}

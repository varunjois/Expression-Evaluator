using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    class GreaterEqual : Operator
    {
        public GreaterEqual(int precedance) : base(">=", precedance, 2)
        {
            _name2 = "GreaterEqual";
            DoubleDoubleBool = (x, y) => x >= y;
            TimespanTimespanBool = (x, y) => x >= y;
            DatetimeDatetimeBool = (x, y) => x >= y;
        }
    }
}
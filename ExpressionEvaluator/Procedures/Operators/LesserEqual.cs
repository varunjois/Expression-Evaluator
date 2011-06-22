using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class LesserEqual : Operator
    {
        public LesserEqual(int precedance) : base("<=", precedance, 2)
        {
            _name2 = "LesserEqual";
            DoubleDoubleBool = (x, y) => x <= y;
            TimespanTimespanBool = (x, y) => x <= y;
            DatetimeDatetimeBool = (x, y) => x <= y;
        }
    }
}
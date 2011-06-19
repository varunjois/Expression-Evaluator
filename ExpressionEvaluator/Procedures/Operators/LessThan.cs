using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class LessThan : Operator
    {
        public LessThan(int precedance) : base("<", precedance, 2)
        {
            _name2 = "LessThan";
            DoubleDoubleBool = (x, y) => x < y;
            DatetimeDatetimeBool = (x, y) => x < y;
        }
    }
}
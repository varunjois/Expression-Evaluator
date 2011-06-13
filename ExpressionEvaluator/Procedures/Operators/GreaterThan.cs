using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class GreaterThan : Operator
    {
        public GreaterThan(int precedance) : base(">", precedance, 2)
        {
            _name2 = "GreaterThan";
            _doubledoublebool = (x, y) => x > y;
        }
    }
}
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class GreaterEqual : Operator
    {
        public GreaterEqual(int precedance) : base(">=", precedance, 2)
        {
            _name2 = "GreaterEqual";
            _doubledoublebool = (x,y) => x >= y;
        }
    }
}
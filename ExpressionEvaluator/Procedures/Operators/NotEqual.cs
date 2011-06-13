using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class NotEqual : Operator
    {
        public NotEqual(int precedance) : base("!=", precedance, 2)
        {
            _name2 = "NotEqual";
            _doubledoublebool = (x, y) => x != y;
        }
    }
}
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Equal : Operator
    {
        public Equal(int precedance) : base("==", precedance, 2)
        {
            _name2 = "Equal";
            _doubledoublebool = (x, y) => x == y;
            _boolboolbool = (x, y) => x == y;
        }
    }
}
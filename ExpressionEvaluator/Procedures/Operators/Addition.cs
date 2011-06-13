using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Addition : Operator
    {
        public Addition(int precedance) : base("+", precedance, 2)
        {
            _name2 = "Addition";
            _doubledoubledouble = (x, y) => x + y;
        }
    }
}

using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Multiplication : Operator
    {
        public Multiplication(int precedance) : base("*", precedance, 2)
        {
            _name2 = "Multiplication";
            _doubledoubledouble = (x, y) => x * y;
        }
    }
}

using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    internal class Modulo : Operator
    {
        public Modulo(int precedance)
            : base("%", precedance, 2, false)
        {
            _name2 = "Modulo";
            DecimalDecimalDecimal = (x, y) => x % y;
        }
    }
}
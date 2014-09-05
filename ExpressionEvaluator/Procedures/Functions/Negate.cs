using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Negate : Function
    {
        public Negate(int precedance)
            : base("neg", precedance, 1, false)
        {
            _name2 = "Negate";
            DecimalDecimal = x => -1 * x;
        }
    }
}

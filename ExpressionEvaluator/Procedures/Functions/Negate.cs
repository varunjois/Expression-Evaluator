using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Negate : Function
    {
        public Negate(int precedance)
            : base("neg", precedance, 1)
        {
            _name2 = "Absolute";
            DoubleDouble = x => -1 * x;
        }
    }
}
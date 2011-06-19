using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Sign : Function
    {
        public Sign(int precedance)
            : base("sign", precedance, 1)
        {
            _name2 = "Sign";
            DoubleDouble = x => x >= 0 ? 1 : -1;
        }
    }
}
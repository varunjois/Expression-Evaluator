using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Sign : Function
    {
        public Sign(int precedance) : base("sign", precedance, 1) { }

        override public IOperand Evaluate(IOperand op1)
        {
            if (op1.Type == typeof(double))
            {
                var dOp1 = op1 as GenericOperand<double>;
                return new GenericOperand<double>(dOp1.Value >= 0 ? 1 : -1);
            }

            throw new ExpressionException("Sign Function used incorrectly.");
        }
    }
}
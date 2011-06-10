using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Negate : Function
    {
        public Negate(int precedance) : base("neg", precedance, 1) { }

        override public IOperand Evaluate(IOperand op1)
        {
            if (op1.Type == typeof(double))
            {
                var dOp1 = op1 as Operand<double>;
                return new Operand<double>(-1 * dOp1.Value);
            }

            throw new ExpressionException("Negate Function used incorrectly.");
        }
    }
}
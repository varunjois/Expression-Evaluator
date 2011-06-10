using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class GreaterThan : TwoOperandOperator
    {
        public GreaterThan(int precedance) : base(">", precedance, 2) { }

        override public IOperand Evaluate(IOperand op1, IOperand op2)
        {
            if (IsDoubleDouble(op1, op2))
            {
                return DoubleDoubleBoolean(op1, op2, (x, y) => x > y);
            }

            throw new ExpressionException("GreaterThan operator used incorrectly.");
        }
    }
}
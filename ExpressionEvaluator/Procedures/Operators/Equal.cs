using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Equal : TwoOperandOperator
    {
        public Equal(int precedance) : base("==", precedance, 2) { }

        override public IOperand Evaluate(IOperand op1, IOperand op2)
        {
            if (IsBooleanBoolean(op1, op2))
            {
                return BooleanBoolean(op1, op2, (x, y) => x == y);
            }

            if (IsDoubleDouble(op1, op2))
            {
                return DoubleDoubleBoolean(op1, op2, (x, y) => x == y);
            }

            throw new ExpressionException("Equal operator used incorrectly.");
        }
    }
}
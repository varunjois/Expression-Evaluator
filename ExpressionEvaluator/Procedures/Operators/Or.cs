using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Or : TwoOperandOperator
    {
        public Or(int precedance) : base("||", precedance, 2) { }

        override public IOperand Evaluate(IOperand op1, IOperand op2)
        {
            if (IsBooleanBoolean(op1, op2))
            {
                return BooleanBoolean(op1, op2, (x, y) => x || y);
            }

            throw new ExpressionException("Or operator used incorrectly.");
        }
    }
}
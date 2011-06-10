using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Power : TwoOperandOperator
    {
        public Power(int precedance) : base("^", precedance, 2) { }

        override public IOperand Evaluate(IOperand op1, IOperand op2)
        {
            if (IsDoubleDouble(op1, op2))
            {
                return DoubleDouble(op1, op2, Math.Pow);
            }

            throw new ExpressionException("Power operator used incorrectly.");
        }
    }
}
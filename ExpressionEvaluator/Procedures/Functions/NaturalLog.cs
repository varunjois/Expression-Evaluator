using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class NaturalLog : Function
    {
        public NaturalLog(int precedance) : base("ln", precedance, 1) { }

        override public IOperand Evaluate(IOperand op1)
        {
            if (op1.Type == typeof(double))
            {
                var dOp1 = op1 as Operand<double>;
                return new Operand<double>(Math.Log(dOp1.Value));
            }

            throw new ExpressionException("NaturalLog Function used incorrectly.");
        }
    }

    class Sign : Function
    {
        public Sign(int precedance) : base("ln", precedance, 1) { }

        override public IOperand Evaluate(IOperand op1)
        {
            if (op1.Type == typeof(double))
            {
                var dOp1 = op1 as Operand<double>;
                return new Operand<double>(dOp1.Value >= 0 ? 1 : -1);
            }

            throw new ExpressionException("Sign Function used incorrectly.");
        }
    }

    class Absolute : Function
    {
        public Absolute(int precedance) : base("ln", precedance, 1) { }

        override public IOperand Evaluate(IOperand op1)
        {
            if (op1.Type == typeof(double))
            {
                var dOp1 = op1 as Operand<double>;
                return new Operand<double>(Math.Abs(dOp1.Value));
            }

            throw new ExpressionException("Absolute Function used incorrectly.");
        }
    }
}
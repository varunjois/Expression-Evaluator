using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Absolute : Function
    {
        public Absolute(int precedance) : base("abs", precedance, 1) { }

        override public IOperand Evaluate(IOperand op1)
        {
            if (op1.Type == typeof(double))
            {
                var dOp1 = op1 as GenericOperand<double>;
                return new GenericOperand<double>(Math.Abs(dOp1.Value));
            }

            throw new ExpressionException("Absolute Function used incorrectly.");
        }
    }
}
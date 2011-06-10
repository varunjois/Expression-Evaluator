using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Division : TwoOperandOperator
    {
        public Division(int precedance) : base("/", precedance, 2) { }

        override public IOperand Evaluate(IOperand op1, IOperand op2)
        {
            if (IsDoubleDouble(op1, op2))
            {
                if (((GenericOperand<double>)op2).Value == 0)
                    return new GenericOperand<double>(double.NaN);

                return DoubleDouble(op1, op2, (x, y) => x / y);
            }

            throw new ExpressionException("Division operator used incorrectly.");
        }
    }
}

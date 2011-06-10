using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Addition : Evaluator
    {
        public Addition() { }

        public override IOperand Evaluate(IOperand op1)
        {
            throw new NotImplementedException();
        }

        public override IOperand Evaluate(IOperand op1, IOperand op2)
        {
            if (op1.Type == typeof(double) && op2.Type == typeof(double))
            {
                var dOp1 = op1 as Operand<double>;
                var dOp2 = op2 as Operand<double>;

                return new Operand<double>(dOp1.Value + dOp2.Value);
            }

            throw new ExpressionException("Addition operator used incorrectly.");
        }
    }
}

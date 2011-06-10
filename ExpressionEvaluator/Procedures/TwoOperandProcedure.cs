using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    internal class TwoOperandProcedure : Operator
    {
        public TwoOperandProcedure(string name, int precedance, int numParamters) 
            : base(name, precedance, numParamters)
        {
        }

        override public IOperand Evaluate(IOperand op1)
        {
            throw new NotImplementedException();
        }

        protected bool IsDoubleDouble(IOperand op1, IOperand op2)
        {
            return op1.Type == typeof(double) && op2.Type == typeof(double);
        }

        protected IOperand DoubleDouble(IOperand op1, IOperand op2, Func<double, double, double> action)
        {
            var dOp1 = op1 as Operand<double>;
            var dOp2 = op2 as Operand<double>;

            return new Operand<double>(action(dOp1.Value, dOp2.Value));
        }
    }
}
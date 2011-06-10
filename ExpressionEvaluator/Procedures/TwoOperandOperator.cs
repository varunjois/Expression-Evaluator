using System;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    internal class TwoOperandOperator : Operator
    {
        public TwoOperandOperator(string name, int precedance, int numParamters)
            : base(name, precedance, numParamters)
        {
        }

        override public IOperand Evaluate(IOperand op1)
        {
            throw new NotImplementedException();
        }

        public bool IsDoubleDouble(IOperand op1, IOperand op2) { return IsTypeType<double>(op1, op2); }
        public bool IsBooleanBoolean(IOperand op1, IOperand op2) { return IsTypeType<bool>(op1, op2); }

        public IOperand DoubleDouble(IOperand op1, IOperand op2, Func<double, double, double> action) { return evalType1(op1, op2, action); }
        public IOperand DoubleDoubleBoolean(IOperand op1, IOperand op2, Func<double, double, bool> action) { return evalType2(op1, op2, action); }
        public IOperand BooleanBoolean(IOperand op1, IOperand op2, Func<bool, bool, bool> action) { return evalType1(op1, op2, action); }

        private bool IsTypeType<T>(IOperand op1, IOperand op2)
        {
            return op1.Type == typeof(T) && op2.Type == typeof(T);
        }

        private IOperand evalType1<T>(IOperand op1, IOperand op2, Func<T, T, T> action)
        {
            var dOp1 = op1 as GenericOperand<T>;
            var dOp2 = op2 as GenericOperand<T>;

            return new GenericOperand<T>(action(dOp1.Value, dOp2.Value));
        }

        private IOperand evalType2<T, T2>(IOperand op1, IOperand op2, Func<T, T, T2> action)
        {
            var dOp1 = op1 as GenericOperand<T>;
            var dOp2 = op2 as GenericOperand<T>;

            return new GenericOperand<T2>(action(dOp1.Value, dOp2.Value));
        }

    }
}
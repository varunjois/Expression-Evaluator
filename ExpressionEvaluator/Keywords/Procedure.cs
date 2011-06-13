using System;
using ExpressionEvaluator.Procedures;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class Procedure : Keyword
    {
        protected Func<double, double> _doubledouble;

        protected Func<double, double, double> _doubledoubledouble;
        protected Func<bool, bool, bool> _boolboolbool;
        protected Func<double, double, bool> _doubledoublebool;
        protected string _name2;

        public Procedure(string name, int precedance, int numParams)
            : base(name, precedance)
        {
            NumParameters = numParams;
        }

        public int NumParameters { get; private set; }

        public IOperand Evaluate(IOperand op1)
        {
            if (_doubledouble != null)
            {
                if (op1.Type == typeof(double))
                {
                    var dOp1 = op1 as GenericOperand<double>;
                    return new GenericOperand<double>(_doubledouble(dOp1.Value));
                }
            }

            throw new ExpressionException(_name2 + " operator used incorrectly.");
        }

        public IOperand Evaluate(IOperand op1, IOperand op2)
        {
            if (_doubledoubledouble != null)
            {
                if (op1.Type == typeof(double) && op2.Type == typeof(double))
                {
                    var dOp1 = op1 as GenericOperand<double>;
                    var dOp2 = op2 as GenericOperand<double>;
                    return new GenericOperand<double>(_doubledoubledouble(dOp1.Value, dOp2.Value));
                }
            }

            if (_boolboolbool != null)
            {
                if (op1.Type == typeof(bool) && op2.Type == typeof(bool))
                {
                    var bOp1 = op1 as GenericOperand<bool>;
                    var bOp2 = op2 as GenericOperand<bool>;
                    return new GenericOperand<bool>(_boolboolbool(bOp1.Value, bOp2.Value));
                }
            }

            if (_doubledoublebool != null)
            {
                if (op1.Type == typeof(double) && op2.Type == typeof(double))
                {
                    var bOp1 = op1 as GenericOperand<double>;
                    var bOp2 = op2 as GenericOperand<double>;
                    return new GenericOperand<bool>(_doubledoublebool(bOp1.Value, bOp2.Value));
                }
            }

            throw new ExpressionException(_name2 + " operator used incorrectly.");
        }

    }
}
using System;
using ExpressionEvaluator.Procedures;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class Procedure : Keyword
    {
        public Procedure(string name, int precedance, int numParams)
            : base(name, precedance)
        {
            NumParameters = numParams;
        }

        public int NumParameters { get; private set; }

        virtual public IOperand Evaluate(IOperand op1) { throw new NotImplementedException(); }
        virtual public IOperand Evaluate(IOperand op1, IOperand op2) { throw new NotImplementedException(); }

    }
}
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    abstract public class Evaluator
    {
        public abstract IOperand Evaluate(IOperand op1);
        public abstract IOperand Evaluate(IOperand op1, IOperand op2);
    }
}
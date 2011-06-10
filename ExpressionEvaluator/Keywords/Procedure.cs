using ExpressionEvaluator.Procedures;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class Procedure : Keyword
    {
        public Procedure(string name, int precedance, int numParams, Evaluator evaluator)
            : base(name, precedance)
        {
            NumParameters = numParams;
            Evaluator = evaluator;
        }

        public int NumParameters { get; private set; }
        public Evaluator Evaluator { get; private set; }
    }
}
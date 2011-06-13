using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class And : Operator
    {
        public And(int precedance) : base("&&", precedance, 2)
        {
            _name2 = "And";
            _boolboolbool = (x, y) => x && y;
        }
    }
}
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    class And : Operator
    {
        public And(int precedance) : base("&&", precedance, 2)
        {
            _name2 = "And";
            BoolBoolBool = (x, y) => x && y;
        }
    }
}
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Or : Operator
    {
        public Or(int precedance) : base("||", precedance, 2)
        {
            _name2 = "Or";
            BoolBoolBool = (x, y) => x || y;            
        }
    }
}
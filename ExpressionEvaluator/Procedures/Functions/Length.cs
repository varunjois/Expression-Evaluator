using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Length : Function
    {
        public Length(int precedance)
            : base("length", precedance, 1, false)
        {
            _name2 = "Length";
            StringDecimal = x => x.Length;
        }
    }
}

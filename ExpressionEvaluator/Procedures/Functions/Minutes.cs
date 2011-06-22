using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Minutes : Function
    {
        public Minutes(int precedance)
            : base("minutes", precedance, 1)
        {
            _name2 = "Minutes";
            TimespanDouble = x => x.TotalMinutes;
        }
    }
}
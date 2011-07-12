using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class TotalSeconds : Function
    {
        public TotalSeconds(int precedance)
            : base("totalseconds", precedance, 1)
        {
            _name2 = "TotalSeconds";
            TimespanDouble = x => x.TotalSeconds;
        }
    }
}
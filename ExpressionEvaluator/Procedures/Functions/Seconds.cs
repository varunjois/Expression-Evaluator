using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Seconds : Function
    {
        public Seconds(int precedance)
            : base("seconds", precedance, 1)
        {
            _name2 = "Seconds";
            TimespanDouble = x => x.TotalSeconds;
        }
    }
}
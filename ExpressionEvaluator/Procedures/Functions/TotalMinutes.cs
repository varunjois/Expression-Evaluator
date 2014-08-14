using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class TotalMinutes : Function
    {
        public TotalMinutes(int precedance)
            : base("totalminutes", precedance, 1, false)
        {
            _name2 = "TotalMinutes";
            TimespanDouble = x => x.TotalMinutes;
        }
    }
}

using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Days : Function
    {
        public Days(int precedance)
            : base("days", precedance, 1)
        {
            _name2 = "Days";
            TimespanDouble = x => x.TotalDays;
        }
    }
}
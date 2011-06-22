using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Hours : Function
    {
        public Hours(int precedance)
            : base("hours", precedance, 1)
        {
            _name2 = "Hours";
            TimespanDouble = x => x.TotalHours;
        }
    }
}
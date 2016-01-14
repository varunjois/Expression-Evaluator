using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class DaysComponent : Function
    {
        public DaysComponent(int precedance)
            : base("dayscomponent", precedance, 1, false)
        {
            _name2 = "DaysComponent";
            TimespanDecimal = x => (decimal)x.Days;
        }
    }
}
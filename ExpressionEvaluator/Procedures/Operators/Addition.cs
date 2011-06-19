using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Addition : Operator
    {
        public Addition(int precedance) : base("+", precedance, 2)
        {
            _name2 = "Addition";
            DoubleDoubleDouble = (x, y) => x + y;
            DatetimeTimespanDatetime = (x, y) => x + y;
            TimespanTimespanTimespan = (x, y) => x + y;
        }
    }
}

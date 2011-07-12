using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Operators
{
    class Division : Operator
    {
        public Division(int precedance) : base("/", precedance, 2)
        {
            _name2 = "Division";
            DoubleDoubleDouble = (x, y) =>
            {
                if (y == 0)
                    return double.NaN;

                return x / y;
            };
        }
    }
}

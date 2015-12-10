using System.Linq;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Concatenate : Function
    {
        public Concatenate(int precedance)
            : base("concatenate", precedance, 1, true)
        {
            _name2 = "Concatenate";
            ObjectStringOperandList = x => x.Aggregate("", (current, i) => current + i);
        }
    }
}

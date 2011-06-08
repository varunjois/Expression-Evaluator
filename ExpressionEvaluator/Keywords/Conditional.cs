using System;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class Conditional : Keyword
    {
        public Conditional(string name, int precedance)
        {
            Name = name;
            Precedance = precedance;
        }

        public OperandType? OperandType { get; protected set; }
    }
}
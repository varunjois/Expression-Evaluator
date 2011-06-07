namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class Operator : Keyword
    {
        public Operator(string name, int precedance, int numParams, OperandType type)
        {
            Name = name;
            Precedance = precedance;
            NumParameters = 0;
            OperandType = null;
        }

        public int NumParameters { get; private set; }
        public OperandType? OperandType { get; protected set; }
    }
}
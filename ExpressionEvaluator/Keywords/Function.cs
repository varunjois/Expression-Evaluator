namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class Function : Keyword
    {
        public Function(string name, int precedance, int numParams)
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
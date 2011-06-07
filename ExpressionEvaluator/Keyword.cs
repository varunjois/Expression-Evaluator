namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class Keyword
    {
        //public Keyword(string name, KeywordTypes type)
        //{
        //    Name = name;
        //    Type = type;
        //    Precedance = 0;
        //    NumParameters = 0;
        //    OperandType = null;
        //}

        //public Keyword(string name, KeywordTypes type, int precedance)
        //{
        //    Name = name;
        //    Type = type;
        //    Precedance = precedance;
        //    NumParameters = 0;
        //    OperandType = null;
        //}

        //public Keyword(string name, KeywordTypes type, int precedance, int numParameters, OperandType? operandType)
        //{
        //    Name = name; 
        //    Type = type;
        //    Precedance = precedance;
        //    NumParameters = numParameters;
        //    OperandType = operandType;
        //}

        public string Name { get; protected set; }
        public int Precedance { get; protected set; }
    }
}
namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class Keyword : IToken
    {
        public Keyword(string name, int precedance)
        {
            Name = name;
            Precedance = precedance;
        }

        public string Name { get; protected set; }
        public int Precedance { get; protected set; }

        public override string ToString() { return Name; }
    }
}

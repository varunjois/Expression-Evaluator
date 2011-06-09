namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class Keyword : Token
    {
        public string Name { get; protected set; }
        public int Precedance { get; protected set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
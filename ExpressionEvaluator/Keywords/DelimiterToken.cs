namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class DelimiterToken : Keyword
    {
        public DelimiterToken(string name, string delimiter)
            : base(name, 0) { Delimiter = delimiter; }

        public string Delimiter { get; protected set; }
    }
}
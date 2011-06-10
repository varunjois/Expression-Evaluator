namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class Grouping : Keyword
    {
        public Grouping(string name, string open, string close)
            : base(name, 0)
        {
            Open = open;
            Close = close;
        }

        public string Open { get; protected set; }
        public string Close { get; protected set; }
    }
}
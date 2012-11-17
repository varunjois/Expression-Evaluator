namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class StringGrouping : Keyword
    {
        public StringGrouping(string name, string delimiter)
            : base(name, 0)
        {
            Delimiter = delimiter;
        }

        public string Delimiter { get; protected set; }
    }
}
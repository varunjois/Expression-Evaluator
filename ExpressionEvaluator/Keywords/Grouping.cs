using System;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class Grouping : Keyword
    {
        public Grouping(string name, string mate)
        {
            Precedance = 0;
            Name = name;
            Mate = mate;
        }

        public Grouping(string name) 
        {
            Precedance = 0;
            Name = name;
        }

        public string Mate { get; protected set; }
    }
}
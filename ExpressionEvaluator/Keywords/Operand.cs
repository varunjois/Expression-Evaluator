using System;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public interface IOperand : IToken
    {
        Type Type { get; }

        string ToString();
    }
}

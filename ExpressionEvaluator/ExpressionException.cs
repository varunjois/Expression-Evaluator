using System;
using System.Runtime.Serialization;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    [Serializable]
    public class ExpressionException : Exception
    {
        public ExpressionException(string description)
            : base(description) { }

        protected ExpressionException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}

using System;
using System.Runtime.Serialization;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    [Serializable]
    public class InvalidTypeExpressionException : Exception
    {
        public InvalidTypeExpressionException(string description) : base (description)
        {
        }

        protected InvalidTypeExpressionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
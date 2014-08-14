using System;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class GenericOperand<T> : IOperand
    {
        public GenericOperand(T value) { Value = value; }

        public GenericOperand() { }

        public Type Type { get { return typeof(T); } }
        public T Value { get; set; }

        public override string ToString() { return Value == null ? "null" : Value.ToString(); }
    }
}

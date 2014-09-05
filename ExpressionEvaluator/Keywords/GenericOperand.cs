using System;
using System.Security.Cryptography;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class GenericOperand<T> : IOperand
    {
        public GenericOperand(T value) { Value = value; }

        public GenericOperand() { }

        public Type Type { get { return typeof(T); } }
        public T Value { get; set; }

        public override string ToString() { return Value == null ? "null" : Value.ToString(); }

        public GenericOperand<double> ToDouble()
        {
            try {
                return new GenericOperand<double>(Convert.ToDouble(Value.ToString()));
            }
            catch {

                return new GenericOperand<double>(Double.NaN);
            }
        }
    }
}

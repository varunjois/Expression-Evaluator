using System;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class Operand<T> : Token, IOperand<T>
    {
        private T _value;

        public Operand(T value)
        {
            _value = value;
        }

        public Operand()
        {
        }

        public T Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public Type Type
        {
            get { return typeof(T); }
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
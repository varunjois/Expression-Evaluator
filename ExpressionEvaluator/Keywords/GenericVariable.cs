using System;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class GenericVariable<T> : GenericOperand<T>, IVariable
    {
        public GenericVariable(string name, T value)
            : base(value)
        {
            _name = name;
        }

        public GenericVariable(string name)
        {
            _name = name;
        }

        public string _name;
        public string Name
        {
            get { return _name; }
        }

        public override string ToString()
        {
            return Name + "=" + base.ToString();
        }
    }
}
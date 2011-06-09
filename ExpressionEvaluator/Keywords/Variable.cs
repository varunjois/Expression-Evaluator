namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class Variable<T> : Operand<T>, IVariable
    {
        public Variable(string name, T value)
            : base(value)
        {
            _name = name;
        }

        public Variable(string name)
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
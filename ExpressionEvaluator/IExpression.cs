using System;
using System.Collections.ObjectModel;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public interface IExpression
    {
        string Function { get; set; }
        string PostFix { get; }
        string InFix { get; }
        ReadOnlyCollection<string> FunctionVariables { get; }
        void AddSetVariable(string name, TimeSpan val);
        void AddSetVariable(string name, double val);
        void AddSetVariable(string name, DateTime val);
        void AddSetVariable(string name, bool val);
        void ClearVariables();
        void Clear();
        double GetVariableValue(string token);
        double EvaluateNumeric();
        bool EvaluateBoolean();
        T Evaluate<T>();
    }
}
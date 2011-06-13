using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures
{
    class Subtraction : Operator
    {
        public Subtraction(int precedance) : base("-", precedance, 2)
        {
            _name2 = "Subtraction";
            _doubledoubledouble = (x, y) => x - y;
        }
    }
}

﻿using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluator.Procedures.Functions
{
    internal class Sum : Function
    {
        public Sum(int precedance)
            : base("sum", precedance, 1, true)
        {
            _name2 = "Sum";
            DecimalDecimalOperandList = x => {
                decimal sum = 0;
                foreach (var i in x) {
                    sum += i;
                }
                return sum;
            };
        }
    }
}

using System;
using System.Collections.Generic;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class Procedure : Keyword
    {
        protected Func<Object, Object, bool> AnyAnyBool;
        protected Func<Object, bool> AnyBool;
        protected Func<Object, string> AnyString;
        protected Func<bool, bool, bool> BoolBoolBool;
        protected Func<bool, string> BoolString;
        protected Func<DateTime, string> DateTimeString;
        protected Func<DateTime> Datetime;
        protected Func<DateTime, DateTime, bool> DatetimeDatetimeBool;
        protected Func<DateTime, DateTime, TimeSpan> DatetimeDatetimeTimespan;
        protected Func<DateTime, double> DatetimeDouble;
        protected Func<DateTime, TimeSpan, DateTime> DatetimeTimespanDatetime;
        protected Func<double> Double;
        protected Func<decimal, decimal> DecimalDecimal;
        protected Func<decimal, decimal, bool> DecimalDecimalBool;
        protected Func<decimal, decimal, decimal> DecimalDecimalDecimal;
        protected Func<decimal, string> DecimalString;
        protected Func<decimal, TimeSpan> DecimalTimespan;
        protected Func<Object, Object, bool> ObjectObjectBool;
        protected Func<List<decimal>, decimal> OperandList;
        protected Func<string, bool> StringBool;
        protected Func<String, decimal> StringDecimal;
        protected Func<String, decimal, decimal, String> StringDecimalDecimalString;
        protected Func<string, string> StringString;
        protected Func<string, string, bool> StringStringBool;
        protected Func<TimeSpan, DateTime, DateTime> TimespanDatetimeDatetime;
        protected Func<TimeSpan, double> TimespanDouble;
        protected Func<TimeSpan, TimeSpan, bool> TimespanTimespanBool;
        protected Func<TimeSpan, TimeSpan, TimeSpan> TimespanTimespanTimespan;
        protected string _name2;

        public Procedure(string name, int precedance, int numParams, bool variableOperandsCount)
            : base(name, precedance)
        {
            NumParameters = numParams;
            AlwaysReturnsValue = true;
            VariableOperandsCount = variableOperandsCount;
        }

        public Procedure(string name, int precedance, int numParams, bool alwaysReturnsValue,
            bool variableOperandsCount)
            : base(name, precedance)
        {
            NumParameters = numParams;
            AlwaysReturnsValue = alwaysReturnsValue;
            VariableOperandsCount = variableOperandsCount;
        }

        public bool AlwaysReturnsValue { get; private set; }
        public int NumParameters { get; set; }
        public bool VariableOperandsCount { get; private set; }

        public IOperand Evaluate()
        {
            if (Datetime != null) {
                return new GenericOperand<DateTime>(Datetime());
            }

            throw new ExpressionException(_name2 + " operator used incorrectly.");
        }

        public IOperand Evaluate(IOperand op1)
        {
            if (DecimalDecimal != null) {
                if (op1.Type == typeof(decimal)) {
                    var dOp1 = op1 as GenericOperand<decimal>;
                    return new GenericOperand<decimal>(DecimalDecimal(dOp1.Value));
                }
            }

            if (StringBool != null) {
                if (op1.Type == typeof(string)) {
                    var dOp1 = op1 as GenericOperand<string>;
                    return new GenericOperand<bool>(StringBool(dOp1.Value));
                }
            }

            if (StringDecimal != null) {
                if (op1.Type == typeof(string)) {
                    var dOp1 = op1 as GenericOperand<string>;
                    return new GenericOperand<decimal>(StringDecimal(dOp1.Value));
                }
            }

            if (DecimalTimespan != null) {
                if (op1.Type == typeof(decimal)) {
                    var dOp1 = op1 as GenericOperand<decimal>;
                    return new GenericOperand<TimeSpan>(DecimalTimespan(dOp1.Value));
                }
            }

            if (TimespanDouble != null) {
                if (op1.Type == typeof(TimeSpan)) {
                    var dOp1 = op1 as GenericOperand<TimeSpan>;
                    return new GenericOperand<double>(TimespanDouble(dOp1.Value));
                }
            }

            if (DecimalString != null) {
                if (op1.Type == typeof(decimal)) {
                    var dOp1 = op1 as GenericOperand<decimal>;
                    return new GenericOperand<string>(DecimalString(dOp1.Value));
                }
            }

            if (DateTimeString != null) {
                if (op1.Type == typeof(DateTime)) {
                    var dOp1 = op1 as GenericOperand<DateTime>;
                    return new GenericOperand<string>(DateTimeString(dOp1.Value));
                }
            }

            if (BoolString != null) {
                if (op1.Type == typeof(bool)) {
                    var dOp1 = op1 as GenericOperand<bool>;
                    return new GenericOperand<string>(BoolString(dOp1.Value));
                }
            }

            if (StringString != null) {
                if (op1.Type == typeof(string)) {
                    var dOp1 = op1 as GenericOperand<string>;
                    return new GenericOperand<string>(StringString(dOp1.Value));
                }
            }

            if (AnyString != null) {
                if (op1.Type == typeof(object)) {
                    var dOp1 = op1 as GenericOperand<object>;
                    return new GenericOperand<string>(AnyString(dOp1.Value));
                }
            }

            if (AnyBool != null) {
                if (op1.Type == typeof(object)) {
                    var dOp1 = op1 as GenericOperand<object>;
                    return new GenericOperand<bool>(AnyBool(dOp1.Value));
                }
            }

            throw new ExpressionException(_name2 + " operator used incorrectly.");
        }

        public IOperand Evaluate(List<IOperand> operands)
        {
            if (OperandList != null) {
                List<decimal> nums = new List<decimal>();
                for (int i = 0; i < operands.Count; i++) {
                    var op = operands[i] as GenericOperand<decimal>;
                    if (op != null) {
                        nums.Add(op.Value);
                    }
                }

                return new GenericOperand<decimal>(OperandList(nums));
            }
            throw new ExpressionException(
                _name2 + " operator used incorrectly. Operand types: " + operands[0].Type.Name
                    + ", " + operands[0].Type.Name + ".");
        }

        public IOperand Evaluate(IOperand op1, IOperand op2)
        {
            try {
                if (DecimalDecimalDecimal != null) {
                    if (op1.Type == typeof(decimal)
                        && op2.Type == typeof(decimal)) {
                        var dOp1 = op1 as GenericOperand<decimal>;
                        var dOp2 = op2 as GenericOperand<decimal>;
                        return
                            new GenericOperand<decimal>(
                                DecimalDecimalDecimal(dOp1.Value, dOp2.Value));
                    }
                }

                if (BoolBoolBool != null) {
                    if (op1.Type == typeof(bool)
                        && op2.Type == typeof(bool)) {
                        var bOp1 = op1 as GenericOperand<bool>;
                        var bOp2 = op2 as GenericOperand<bool>;
                        return new GenericOperand<bool>(BoolBoolBool(bOp1.Value, bOp2.Value));
                    }
                }

                if (TimespanTimespanBool != null) {
                    if (op1.Type == typeof(TimeSpan)
                        && op2.Type == typeof(TimeSpan)) {
                        var bOp1 = op1 as GenericOperand<TimeSpan>;
                        var bOp2 = op2 as GenericOperand<TimeSpan>;
                        return new GenericOperand<bool>(
                            TimespanTimespanBool(bOp1.Value, bOp2.Value));
                    }
                }

                if (DecimalDecimalBool != null) {
                    if (op1.Type == typeof(decimal)
                        && op2.Type == typeof(decimal)) {
                        var bOp1 = op1 as GenericOperand<decimal>;
                        var bOp2 = op2 as GenericOperand<decimal>;
                        return new GenericOperand<bool>(DecimalDecimalBool(bOp1.Value, bOp2.Value));
                    }
                }

                if (StringStringBool != null) {
                    if (op1.Type == typeof(string)
                        && op2.Type == typeof(string)) {
                        var bOp1 = op1 as GenericOperand<string>;
                        var bOp2 = op2 as GenericOperand<string>;
                        return new GenericOperand<bool>(StringStringBool(bOp1.Value, bOp2.Value));
                    }
                }

                if (TimespanTimespanTimespan != null) {
                    if (op1.Type == typeof(TimeSpan)
                        && op2.Type == typeof(TimeSpan)) {
                        var bOp1 = op1 as GenericOperand<TimeSpan>;
                        var bOp2 = op2 as GenericOperand<TimeSpan>;
                        return
                            new GenericOperand<TimeSpan>(
                                TimespanTimespanTimespan(bOp1.Value, bOp2.Value));
                    }
                }

                if (DatetimeTimespanDatetime != null) {
                    if (op1.Type == typeof(DateTime)
                        && op2.Type == typeof(TimeSpan)) {
                        var bOp1 = op1 as GenericOperand<DateTime>;
                        var bOp2 = op2 as GenericOperand<TimeSpan>;
                        return
                            new GenericOperand<DateTime>(
                                DatetimeTimespanDatetime(bOp1.Value, bOp2.Value));
                    }
                }

                if (TimespanDatetimeDatetime != null) {
                    if (op1.Type == typeof(TimeSpan)
                        && op2.Type == typeof(DateTime)) {
                        var bOp1 = op1 as GenericOperand<TimeSpan>;
                        var bOp2 = op2 as GenericOperand<DateTime>;
                        return
                            new GenericOperand<DateTime>(
                                TimespanDatetimeDatetime(bOp1.Value, bOp2.Value));
                    }
                }

                if (DatetimeDatetimeTimespan != null) {
                    if (op1.Type == typeof(DateTime)
                        && op2.Type == typeof(DateTime)) {
                        var bOp1 = op1 as GenericOperand<DateTime>;
                        var bOp2 = op2 as GenericOperand<DateTime>;
                        return
                            new GenericOperand<TimeSpan>(
                                DatetimeDatetimeTimespan(bOp1.Value, bOp2.Value));
                    }
                }

                if (DatetimeDatetimeBool != null) {
                    if (op1.Type == typeof(DateTime)
                        && op2.Type == typeof(DateTime)) {
                        var bOp1 = op1 as GenericOperand<DateTime>;
                        var bOp2 = op2 as GenericOperand<DateTime>;
                        return new GenericOperand<bool>(
                            DatetimeDatetimeBool(bOp1.Value, bOp2.Value));
                    }
                }

                if (ObjectObjectBool != null) {
                    if (op1.Type == typeof(Object)
                        && op2.Type == typeof(Object)) {
                        var bOp1 = op1 as GenericOperand<Object>;
                        var bOp2 = op2 as GenericOperand<Object>;
                        return new GenericOperand<bool>(ObjectObjectBool(bOp1.Value, bOp2.Value));
                    }
                }

                if (AnyAnyBool != null) {
                    return new GenericOperand<bool>(AnyAnyBool(op1, op2));
                }

                if (op1.Type == typeof(Object)
                    || op2.Type == typeof(Object)) {
                    return new GenericOperand<object>();
                }
            }
            catch (NotFiniteNumberException nf) {
                throw nf;}
            catch (DivideByZeroException dz)
            {
                throw dz;
            }
            catch (Exception e) {
                throw new ExpressionException(
                    _name2 + " operator threw an exception. Operand types: " + op1.Type.Name + ", "
                        + op2.Type.Name + "." + Environment.NewLine + e.Message);
            }
            throw new ExpressionException(
                _name2 + " operator used incorrectly. Operand types: " + op1.Type.Name + ", "
                    + op2.Type.Name + ".");
        }

        public IOperand Evaluate(IOperand op1, IOperand op2, IOperand op3)
        {
            try {
                if (StringDecimalDecimalString != null) {
                    if (op1.Type == typeof(string)
                        && op2.Type == typeof(decimal)
                        && op3.Type == typeof(decimal)) {
                        var dOp1 = op1 as GenericOperand<string>;
                        var dOp2 = op2 as GenericOperand<decimal>;
                        var dOp3 = op3 as GenericOperand<decimal>;

                        if ((dOp2.Value % 1) != 0
                            || (dOp3.Value % 1) != 0) {
                            throw new ExpressionException(
                                "One or more of the substring parameters contain decimals and not integers!");
                        }

                        return
                            new GenericOperand<string>(
                                StringDecimalDecimalString(dOp1.Value, dOp2.Value, dOp3.Value));
                    }
                }

                if (op1.Type == typeof(Object)
                    || op2.Type == typeof(Object)
                    || op2.Type == typeof(Object)) {
                    return new GenericOperand<object>();
                }
            }
            catch (Exception e) {
                throw new ExpressionException(
                    _name2 + " operator threw an exception. Operand types: " + op1.Type.Name + ", "
                        + op2.Type.Name + ", " + op3.Type.Name + "." + Environment.NewLine
                        + e.Message);
            }
            throw new ExpressionException(
                _name2 + " operator used incorrectly. Operand types: " + op1.Type.Name + ", "
                    + op2.Type.Name + ", " + op3.Type.Name + ".");
        }
    }
}

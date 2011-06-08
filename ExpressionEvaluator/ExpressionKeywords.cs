using System;
using System.Collections.Generic;
using System.Linq;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public static class ExpressionKeywords
    {
        static public readonly List<Keyword> Keywords = new List<Keyword>
        {
            new Operator("+", 10, 2, OperandType.Numeric),
            new Operator("-", 10, 2, OperandType.Numeric),
            new Operator("||", 10, 2, OperandType.Boolean),

            new Operator("*", 20, 2, OperandType.Numeric),
            new Operator("/", 20, 2, OperandType.Numeric),
            new Operator("&&", 20, 2, OperandType.Boolean),

            new Operator("==", 30, 2, OperandType.Mixed),
            new Operator(">=", 30, 2, OperandType.Mixed),
            new Operator("<=", 30, 2, OperandType.Mixed),
            new Operator(">", 30, 2, OperandType.Mixed),
            new Operator("<", 30, 2, OperandType.Mixed),
            new Operator("!=", 30, 2, OperandType.Mixed),
            new Operator("^",  30, 1, OperandType.Numeric),

            new Function("abs", 40, 1),
            new Function("neg", 40, 1),
            new Function("ln", 40, 1),
            new Function("sign", 40, 1),

            new Conditional("if", 50),
            new Conditional("elseif", 50),
            new Conditional("else", 50),

            new Grouping("(", ")"),
            new Grouping(")"),
            new Grouping("{", "}"),
            new Grouping("}"),
        };

        static public readonly List<string> Operators
            = Keywords.OfType<Operator>().Select(x => x.Name).ToList();

        static public readonly List<string> Functions
            = Keywords.OfType<Function>().Select(x => x.Name).ToList();

        static public readonly List<string> OpenGroupOperators =
            Keywords.OfType<Grouping>()
                .Where(x => !String.IsNullOrEmpty(x.Mate))
                .Select(x => x.Name).ToList();

        static public readonly List<string> ClosingGroupOperators =
            Keywords.OfType<Grouping>()
                .Where(x => String.IsNullOrEmpty(x.Mate))
                .Select(x => x.Name).ToList();

        static public readonly List<string> GroupOperators =
            Keywords.OfType<Grouping>().Select(x => x.Name).ToList();

        static public readonly List<string> ConditionalOperators =
            Keywords.OfType<Conditional>()
                .Select(x => x.Name).ToList();

        public static Grouping GetGroupingFromClose(string token)
        {
            return Keywords.OfType<Grouping>().Where(x => x.Mate == token).Single();
        }

        /// <summary>
        /// Checks to see if a string is an operand.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="token">String to check</param>
        /// <returns></returns>
        static public bool IsOperand(string token)
        {
            if (!IsOperator(token) &&
                !GroupOperators.Contains(token))
                return true;

            return false;
        }

        /// <summary>
        /// Checks to see if a string is an operator.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="token">String to check</param>
        /// <returns></returns>
        static public bool IsOperator(string token)
        {
            return Operators
                .Union(Functions)
                .Union(ConditionalOperators)
                .Contains(token);
        }

        /// <summary>
        /// Returns the precedance of an operator.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="token">Token to check.</param>
        /// <returns></returns>
        static public int GetPrecedence(string token)
        {
            if (Keywords.Where(x => x.Name == token).Count() == 1)
                return Keywords.Where(x => x.Name == token).Single().Precedance;

            return 0;
        }


    }
}
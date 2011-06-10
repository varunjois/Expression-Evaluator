using System;
using System.Collections.Generic;
using System.Linq;
using ExpressionEvaluator.Procedures;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public static class ExpressionKeywords
    {
        static public readonly List<Keyword> Keywords = new List<Keyword>
        {
            new Addition(10),
            new Subtraction(10),
            new Operator("||", 10, 2),

            new Multiplication(20),
            new Division(20),
            new Operator("&&", 20, 2),

            new Operator("==", 30, 2),
            new Operator(">=", 30, 2),
            new Operator("<=", 30, 2),
            new Operator(">", 30, 2),
            new Operator("<", 30, 2),
            new Operator("!=", 30, 2),
            new Operator("^",  30, 2),

            new Function("abs", 40, 1),
            new Function("neg", 40, 1),
            new Function("ln", 40, 1),
            new Function("sign", 40, 1),

            new Conditional("if", 50, 2),
            new Conditional("elseif", 50, 2),
            new Conditional("else", 50, 1),

            new Grouping("Paranthesis", "(", ")"),
            new Grouping("Curley Braces", "{", "}"),
        };

        static public readonly List<string> Operators
            = Keywords.OfType<Operator>().Select(x => x.Name).ToList();

        static public readonly List<string> Functions
            = Keywords.OfType<Function>().Select(x => x.Name).ToList();

        static public readonly List<string> OpenGroupOperators =
            Keywords.OfType<Grouping>()
                .Select(x => x.Open).ToList();

        static public readonly List<string> ClosingGroupOperators =
            Keywords.OfType<Grouping>()
                .Select(x => x.Close).ToList();

        static public readonly List<string> GroupOperators =
            ClosingGroupOperators.Union(OpenGroupOperators).ToList();

        static public readonly List<string> ConditionalOperators =
            Keywords.OfType<Conditional>()
                .Select(x => x.Name).ToList();

        public static Grouping GetGroupingFromClose(string token)
        {
            return Keywords.OfType<Grouping>().Where(x => x.Close == token).Single();
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
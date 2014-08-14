using System;
using System.Collections.Generic;
using System.Linq;
using ExpressionEvaluator.Procedures;
using ExpressionEvaluator.Procedures.Functions;
using ExpressionEvaluator.Procedures.Operators;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public static class ExpressionKeywords
    {
        static public readonly Dictionary<string, IVariable> Constants;

        static public readonly List<Keyword> Keywords;

        static public readonly List<string> Operators;

        static public readonly List<string> Functions;

        static public readonly List<string> StringGroupOperators;

        static public readonly List<string> OpenGroupOperators;

        static public readonly List<string> ClosingGroupOperators;

        static public readonly List<string> GroupOperators;

        static public readonly List<string> ConditionalOperators;

        static ExpressionKeywords()
        {
            Constants = new Dictionary<string, IVariable>()
            {
                {"null", new GenericVariable<object>("null") {Value = null}},
                {"true", new GenericVariable<bool>("true") {Value = true}},
                {"false", new GenericVariable<bool>("false") {Value = false}}
            };

            Keywords = new List<Keyword>
            {
                new Or(10),
                new And(20),
                new Equal(30),
                new GreaterEqual(30),
                new LesserEqual(30),
                new GreaterThan(30),
                new LesserThan(30),
                new NotEqual(30),
                new Addition(40),
                new Subtraction(40),
                new Multiplication(50),
                new Division(50),
                new Power(55),
                new Absolute(60),
                new Negate(60),
                new NaturalLog(60),
                new Sign(60),
                new Now(60),
                new Days(60),
                new Hours(60),
                new Minutes(60),
                new Seconds(60),
                new TotalDays(60),
                new TotalHours(60),
                new TotalMinutes(60),
                new TotalSeconds(60),
                new Contains(60),
                new ToNumber(60),
                new ToString(60),
                new IsNumber(60),
                new Substring(60),
                new Length(60),
                new Sum(60),
                new Conditional("if", 70, 2, false, false),
                new Conditional("elseif", 70, 2, false, false),
                new Conditional("else", 70, 1, true, false),
                new Grouping("Paranthesis", "(", ")"),
                new Grouping("Curley Braces", "{", "}"),
                new StringGrouping("String", "'"),
            };

            Operators = Keywords.OfType<Operator>()
                .Select(x => x.Name)
                .ToList();

            Functions = Keywords.OfType<Function>()
                .Select(x => x.Name)
                .ToList();

            StringGroupOperators = Keywords.OfType<StringGrouping>()
                .Select(x => x.Delimiter)
                .ToList();

            OpenGroupOperators = Keywords.OfType<Grouping>()
                .Select(x => x.Open)
                .ToList();

            ClosingGroupOperators = Keywords.OfType<Grouping>()
                .Select(x => x.Close)
                .ToList();

            GroupOperators = ClosingGroupOperators.Union(OpenGroupOperators)
                .ToList();

            ConditionalOperators = Keywords.OfType<Conditional>()
                .Select(x => x.Name)
                .ToList();
        }
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

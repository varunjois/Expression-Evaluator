using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    public class InfixExpression
    {
        public InfixExpression(string expression)
        {
            _original = expression;
            Expression = Expand(expression);
            _tokens = Expression.Split(new[]
            { ' ' });

            CheckFunctionFormatting(Expression, _tokens);
            CheckGrouping(Expression);
            CheckConditionals(Expression, _tokens);

        }

        private string _expression;
        private string _original;
        private string[] _tokens;

        public string Original
        {
            get { return _original; }
        }

        public string Expression
        {
            get { return _expression; }
            private set { _expression = value; }
        }

        public IEnumerable<string> Tokens
        {
            get { return _tokens; }
        }

        /// <summary>
        /// Expandn the spaces around operators and operands.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="function">Function to expand.</param>
        /// <returns></returns>
        private string Expand(string function)
        {
            // Clean the function.
            //function = Regex.Replace(function, @"[ ]+", @""); // Remove spaces

            function = Regex.Replace(function, "\r\n", " ");

            foreach (var x in ExpressionKeywords.Operators.Union(ExpressionKeywords.GroupOperators))
            {
                function = function.Replace(x, " " + x + " ");
            }

            // Join the else if into a single operator.
            function = function.Replace("else if", "elseif");
            function = function.Replace("< =", "<=");
            function = function.Replace("> =", ">=");
            function = function.Trim();
            function = Regex.Replace(function, @"[ ]+", @" "); // Collapses multiple spaces

            // Find and correct for scientific notation
            function = ScientificNotationCorrection(function);

            // Fix negative real values. Ex:  "1 + - 2" = "1 + -2". "1 + - 2e-1" = "1 + -2e-1".
            function = Regex.Replace(
                function,
                @"([<>=/*+(-] -|sign -|^-) (\d+|[0-9]+[eE][+-]\d+)(\s|$)",
                @"$1$2$3");

            return function;
        }

        // Corrects for spaced function...
        /// <summary>
        /// Corrects scientific notation in an expression.
        /// </summary>
        /// <param name="function">The expanded function to check.</param>
        /// <returns>The corrected expanded function</returns>
        public static string ScientificNotationCorrection(string function)
        {
            char[] ops = { '-', '+' };
            int n = function.IndexOfAny(ops, 0);
            while ((n <= function.Length) && (n > -1))
            {
                // Find the previous space.
                int prevCut = -1;
                int nextCut = -1;

                if (n - 2 <= 0)
                    prevCut = 0;
                else
                    prevCut = function.LastIndexOf(" ", n - 2, n - 2) + 1;

                if (n + 2 < function.Length)
                    nextCut = function.IndexOf(" ", n + 2);
                else
                    nextCut = function.Length;
                nextCut = (nextCut == -1 ? function.Length : nextCut);

                string checkMeSpace = function.Substring(prevCut, nextCut - prevCut);
                string checkMe = checkMeSpace.Replace(" ", string.Empty);

                bool realValue = false;
                double val = Double.NaN;
                try
                {
                    val = Double.Parse(checkMe);
                    realValue = true;
                }
                catch { }

                if (realValue)
                {
                    function = function.Replace(checkMeSpace, checkMe);
                    n = prevCut + checkMe.Length - 1;
                }

                n = function.IndexOfAny(ops, n + 1);

            }

            return function;
        }

        private void CheckFunctionFormatting(string inFix, string[] tokens)
        {
            for (int i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];
                if (ExpressionKeywords.Functions.Contains(token))
                {
                    if (i + 3 >= tokens.Count() || tokens[i + 1] != "(")
                        throw new ExpressionException("Function error! " +
                            token + " not formatted correctly. Open and close parenthesis required. " +
                            inFix);
                }
            }
        }

        private void CheckGrouping(string inFix)
        {
            string errorMsg = "Grouping error! Open missing. " + " " + inFix;

            var groupingStack = new Stack<char>();
            foreach (var token in inFix.ToArray())
            {
                if (!ExpressionKeywords.GroupOperators.Contains(token.ToString()))
                {
                    continue;
                }

                if (ExpressionKeywords.OpenGroupOperators.Contains(token.ToString()))
                {
                    groupingStack.Push(token);
                    continue;
                }

                if (groupingStack.Count == 0)
                {
                    throw new ExpressionException(errorMsg);
                }

                var last = groupingStack.Pop();

                if (ExpressionKeywords.ClosingGroupOperators.Contains(token.ToString()))
                {
                    Grouping g = ExpressionKeywords.GetGroupingFromClose(token.ToString());
                    if (last.ToString() != g.Name)
                        throw new ExpressionException(errorMsg);

                }
            }

            if (groupingStack.Count != 0)
            {
                throw new ExpressionException("Grouping error! Close missing. " + " " + inFix);
            }
        }

        private void CheckConditionals(string inFix, string[] tokens)
        {
            CheckForMatchingIfElse(inFix, tokens);
            CheckConditionalFormatting(inFix);
        }

        private void CheckConditionalFormatting(string inFix)
        {
            string errorMsg = "Conditional Error! Boolean statement formatted incorrectly. " + inFix;

            // Find any instances of an "if" followed by something othern then a "(".
            if (Regex.IsMatch(inFix, @" if(?! *\()"))
            {
                throw new ExpressionException(errorMsg);
            }

            // Find any instances of an "else" followed by something othern then a "{" or an "if".
            if (Regex.IsMatch(inFix, @"else(?! *(if|{))"))
            {
                throw new ExpressionException(errorMsg);
            }

        }

        private void CheckForMatchingIfElse(string inFix, string[] tokens)
        {
            string errorMsg = "Conditional Error! If/Else mismatch. Should be in the following form: if (...) {...} else if (...) {...} else {...}. " + inFix;

            var workStack = new Stack<string>();
            foreach (var token in tokens)
            {
                if (!ExpressionKeywords.ConditionalOperators.Contains(token))
                {
                    continue;
                }

                if (token == "if")
                {
                    workStack.Push(token);
                    continue;
                }

                if (workStack.Count == 0)
                {
                    throw new ExpressionException(errorMsg);
                }

                var last = workStack.Pop();

                if (last != "if")
                {
                    throw new ExpressionException(errorMsg);
                }

                if (token == "elseif")
                {
                    workStack.Push("if");
                }
            }

            if (workStack.Count != 0)
            {
                throw new ExpressionException(errorMsg + " " + inFix);
            }
        }

    }
}
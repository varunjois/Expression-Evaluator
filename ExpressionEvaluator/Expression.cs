/*****************************************************************************************
* Jeremy Roberts                                                           Expression.cs *
* 2004-07-23                                                                     Wfccm2 *
*****************************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.Reflection;
//using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
//using System.Threading;
using System.Linq;

namespace Vanderbilt.Biostatistics.Wfccm2
{
    [Serializable]
    public class ExpressionException : Exception
    {
        public ExpressionException(string description) : base (description)
        {
        }

        protected ExpressionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    /// <summary>
    /// Evaluatable mathmatical function.
    /// </summary>
    /// <remarks><pre>
    /// 2004-07-19 - Jeremy Roberts
    /// Takes a string and allow a user to add variables. Evaluates the string as a mathmatical function.
    /// 2006-01-11 - Will Gray
    ///  - Added generic collection implementation.
    /// </pre></remarks>
    [Serializable()]
    public class Expression : MarshalByRefObject
    {
        /// <summary>
        /// Dynaamic function type.
        /// </summary>
        /// <remarks><pre>
        /// 2005-12-20 - Jeremy Roberts
        /// </pre></remarks>
        [Serializable()]
        public abstract class DynamicFunction
        {
            public abstract double EvaluateD(Dictionary<string, double> variables);
            public abstract bool EvaluateB(Dictionary<string, double> variables);
        }
        protected DynamicFunction dynamicFunction;
        //protected AppDomain NewAppDomain;

        #region Class variable
        //class Variable
        //{
        //    public string name;
        //    public double val;
        //}
        #endregion

        #region Member data
        
        /// <summary>
        /// The function.
        /// </summary>
        protected string inFunction = string.Empty; // Infix function.
        protected string postFunction = string.Empty; // Postfix function.
        protected Dictionary<string, double> variables = new Dictionary<string, double>();
        protected const double TRUE = 1;
        protected const double FALSE = 0;
        protected string[] splitPostFunction;
        //private bool compilecode = false;

        #endregion

        ~Expression()
        {
            //NewAppDomain.;
        }

        #region Constructors
        /// <summary>
        /// Creation constructor.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-20 - Jeremy Roberts
        /// </pre></remarks>
        public Expression()
        {
        }

        /// <summary>
        /// Creation constructor.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="function">The function to be evaluated.</param>
        public Expression(string function)
        {
            Function = function;
        }

        #endregion

        #region properties
        /// <summary>
        /// InFix property
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        public string Function
        {
            get{return this.inFunction;}
            set{
                // This will throw an error if it does not validate.
                Validate(value);

                // Function is valid.
                inFunction = value; 
                postFunction = Infix2Postfix(inFunction);
                splitPostFunction = postFunction.Split(new [] { ' ' });
                ClearVariables();
                //if (compilecode)
                //    this.compile();
            }
        }

        /// <summary>
        /// PostFix property
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        public string PostFix
        {
            get { return postFunction; }
        }

        /// <summary>
        /// PostFix property
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        public string InFix
        {
            get { return Expand(inFunction); }
        }

        //private bool Compile
        //{
        //    get
        //    {
        //        return compilecode;
        //    }
        //    set
        //    {
        //        compilecode = value;
        //    }
        //}

        static private readonly List<string> _operators = new List<string>
        {
            "+",
            "-",
            "*",
            "/",
            "^",
            "&&",
            "||",
            "==",
            ">=",
            "<=",
            ">",
            "<",
            "!="
        };

        static private readonly List<string> _functions = new List<string>
        {
            "sign",
            "abs",
            "neg",
            "ln"
        };

        static private readonly List<String> _openGroupOperators = new List<String>
        {
            "(",
            "{"
        };

        static private readonly List<String> _closeGroupOperators = new List<String>
        {
            ")",
            "}"
        };

        static private readonly List<String> _conditionalOperators = new List<String>
        {
            "if",
            "else",
            "elseif"
        };

        static private readonly List<string> _groupOperators = _openGroupOperators.Union(_closeGroupOperators).ToList();


        #endregion


        /// <summary>
        /// Convecs an infix string to a post fix string.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="func">The function to convert</param>
        /// <returns>A post fix string.</returns>
        protected string Infix2Postfix(string func)
        {
            func = Expand(func);

            string[] inFix = func.Split(new []{' '});

            var postFix = new Stack<string>();
            var operators = new Stack<string>();
            
            string currOperator;

            foreach (string token in inFix)
            {
                if (IsOperand(token))
                {
                    postFix.Push(token);
                }
                else if (token == "(" || token == "{")
                {
                    operators.Push(token);
                }
                else if (token == ")")
                {
                    currOperator = operators.Pop();

                    while (currOperator != "(")
                    {
                        postFix.Push(currOperator);
                        currOperator = operators.Pop();
                    }
                }
                else if (token == "}")
                {
                    currOperator = operators.Pop();

                    while (currOperator != "{")
                    {
                        postFix.Push(currOperator);
                        currOperator = operators.Pop();
                    }
                }
                else if (IsOperator(token))
                {
                    // while precedence of the operator is <= precedence of the token 
                    while (operators.Count > 0)
                    {
                        if (GetPrecedence(token) <= GetPrecedence(operators.Peek()))
                        {
                            currOperator = operators.Pop();
                            postFix.Push(currOperator);
                        }
                        else
                        {
                            break;
                        }
                    }

                    operators.Push(token);
                }
            }
            while (operators.Count > 0)
            {
                currOperator = operators.Pop();
                postFix.Push(currOperator);
            }

            // Build the post fix string.
            string psString = string.Empty;
            foreach (string item in postFix)
            {
                psString = item + " " + psString;
            }
            psString = psString.Trim();
 
            return psString;


        }

        /// <summary>
        /// Checks to see if a string is an operand.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="token">String to check</param>
        /// <returns></returns>
        public bool IsOperand(string token)
        {
            if (!IsOperator(token) &&
                !_groupOperators.Contains(token))
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
        public bool IsOperator(string token)
        {
            return _operators.Union(_functions).Union(_conditionalOperators).Contains(token);
        }

        /// <summary>
        /// Expandn the spaces around operators and operands.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="function">Function to expand.</param>
        /// <returns></returns>

        public string Expand(string function)
        {
            // Clean the function.
            //function = Regex.Replace(function, @"[ ]+", @""); // Remove spaces

            function = Regex.Replace(function, "\r\n", " ");

            foreach (var x in _operators.Union(_groupOperators))
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
            function = Expression.ScientificNotationCorrection(function);

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
            char[] ops = {'-','+'};
            int n = function.IndexOfAny(ops,0);
            while ((n <= function.Length) && (n > -1))
            {
                // Find the previous space.
                int prevCut=-1;
                int nextCut=-1;
                
                if (n-2 <= 0)
                    prevCut = 0;
                else
                    prevCut = function.LastIndexOf(" ", n-2, n-2) + 1;
                
                if (n + 2 < function.Length)
                    nextCut = function.IndexOf(" ", n+2);
                else 
                    nextCut = function.Length;
                nextCut = (nextCut == -1 ? function.Length : nextCut);
                
                string checkMeSpace = function.Substring(prevCut, nextCut - prevCut);
                string checkMe = checkMeSpace.Replace(" ", string.Empty);

                bool realValue=false;
                double val = Double.NaN;
                try 
                {
                    val = Double.Parse(checkMe);
                    realValue = true;
                }
                catch {}

                if (realValue)
                {
                    function = function.Replace(checkMeSpace, checkMe);
                    n = prevCut + checkMe.Length-1;
                }

                n = function.IndexOfAny(ops,n+1);

            }

            return function;
        }

        /// <summary>
        /// Returns the precedance of an operator.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="token">Token to check.</param>
        /// <returns></returns>
        protected int GetPrecedence(string token)
        {
            if (
                token == "+"    ||
                token == "-"    ||
                token == "||"   )
                return 10;
            else if (
                token == "*"    ||
                token == "/"    ||
                token == "&&")
                return 20;
            else if (
                token == "=="   ||
                token == ">="   ||
                token == "<="   ||
                token == ">"    ||
                token == "<"    ||
                token == "!="   ||
                token == "^" )
                return 30;
            else if (
                token == "abs"  ||
                token == "neg"  ||
                token == "ln"   ||
                token == "sign")
                return 40;
            else if (
                token == "if"   ||
                token == "else" ||
                token == "elseif")
                return 50;
            else
                return 0;
        }

        /// <summary>
        /// Adds or sets a Variable.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="name">Variable name.</param>
        /// <param name="value">Variabale value.</param>
        public void AddSetVariable(string name, double val)
        {
            variables[name] = val;
        }

        /// <summary>
        /// Adds or sets a Variable.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="name">Variable name.</param>
        /// <param name="value">Variabale value.</param>
        public void AddSetVariable(string name, bool val)
        {
            double dval;
            if (val)
                dval = 1;
            else
                dval = 0;

            variables[name] = dval;
        }

        /// <summary>
        /// Clears the variable information.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        public void ClearVariables()
        {
            variables.Clear();
        }

        /// <summary>
        /// Clears all information.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        public void Clear()
        {
            inFunction = string.Empty;
            postFunction = string.Empty;
            variables.Clear();
        }

        /// <summary>
        /// Checks to see if a string is a variable.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-20 - Jeremy Roberts
        /// 2004-08-11 - Jeremy Roberts
        ///  Changed to check to see if it is a number.
        /// </pre></remarks>
        /// <param name="token">String to check.</param>
        /// <returns></returns>
        protected bool IsVariable(string token)
        {
            //if (isOperator(token))
            //    return false;

            if (token == "true" || token == "false")
                return false;

            if (!IsOperand(token))
                return false;

            if (IsNumber(token))
                return false;

            return true;
        }

        public ReadOnlyCollection<string> FunctionVariables
        {
            get
            {
                // Check to see that the function is valid.
                if (inFunction.Equals(string.Empty) || this.inFunction == null)
                    throw new ExpressionException("Function does not exist");

                // Expand the function.
                string func = Expand(inFunction);

                // Tokenize the funcion.
                string[] inFix = func.Split(new char[] { ' ' });

                // The arraylist to return
                List<string> retVal = new List<string>();

                // Check each token to see if its a variable.
                foreach (string token in inFix)
                {
                    if (this.IsVariable(token))
                        retVal.Add(token);
                }

                return retVal.AsReadOnly();
            }
        }

        /// <summary>
        /// Returns a variable's value.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-20 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="token">Variable to return.</param>
        /// <returns></returns>
        public double GetVariableValue(string token)
        {
            try
            {
                return variables[token];
            }
            catch
            {
                return double.NaN;                
            }
        }

        /// <summary>
        /// Validates an infix function.
        /// </summary>
        /// <remarks><pre>
        /// 2011-05-27 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="token">Variable to return.</param>
        /// <returns></returns>
        protected bool Validate(string inFix)
        {
            string inFixClean = Expand(inFix);
            string[] tokens = inFixClean.Split(new []{' '});

            CheckFunctionFormatting(inFixClean, tokens);
            CheckGrouping(inFixClean);
            CheckConditionals(inFixClean, tokens);

            tokens = Infix2Postfix(inFixClean).Split(new char[] { ' ' });

            CheckPostVectorForEvaluability(inFixClean, tokens);            

            return true;
        }

        private void CheckPostVectorForEvaluability(string inFix, string[] tokens)
        {
            var workstack = new Stack<string>();

            for (int index = 0; index < tokens.Length; index++)
            {
                string token = tokens[index];

                if (IsOperator(token))
                {
                    if (_functions.Contains(token) ||
                        token == "else")
                    {
                        try
                        {
                            workstack.Pop();
                            workstack.Push("0");
                        }
                        catch
                        {
                            throw new ExpressionException("Operator error! \"" + token + "\". " + inFix);
                        }
                    }
                    else if (token == "if" || token == "elseif")
                    {
                        try
                        {
                            workstack.Pop();
                            workstack.Pop();
                        }
                        catch
                        {
                            throw new ExpressionException("Operator error! \"" + token + "\". " + inFix);
                        }
                    }
                    else
                    {
                        try
                        {
                            workstack.Pop();
                            workstack.Pop();
                            workstack.Push("0");
                        }
                        catch
                        {
                            throw new ExpressionException("Operator error! \"" + token + "\". " + inFix);
                        }
                    }
                }
                else
                {
                    workstack.Push(token);
                }
            }

            if (workstack.Count != 1)
            {
                throw new ExpressionException("Expression formatted incorrecty! " + inFix);
            }
        }


        private void CheckFunctionFormatting(string inFix, string[] tokens)
        {
            for (int i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];
                if (_functions.Contains(token))
                {
                    if (i + 3 >= tokens.Count() || tokens[i+1] != "(" )
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
                if (!_groupOperators.Contains(token.ToString()))
                {
                    continue;
                }

                if (_openGroupOperators.Contains(token.ToString()))
                {
                    groupingStack.Push(token);
                    continue;
                }

                if (groupingStack.Count == 0)
                {
                    throw new ExpressionException(errorMsg);
                }

                var last = groupingStack.Pop();

                if ((token == ')' && last != '(') ||
                    (token == '}' && last != '{'))
                {
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
                if (!_conditionalOperators.Contains(token.ToString()))
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

        /// <summary>
        /// Evaluates the function as a double.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        /// <returns></returns>
        public double EvaluateNumeric()
        {
            // TODO! Check to see that we have the variable that we need.

            // Create a temporary vector to hold the secondary stack.
            return ConvertString(Evaluate());
        }

        /// <summary>
        /// Evaluates the function given as a boolean expression.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-20 - Jeremy Roberts
        /// </pre></remarks>
        public bool EvaluateBoolean()
        {
            string result = Evaluate();

            if (this.ConvertString(result) == TRUE)
                return true;
            return false;
        }

        private string Evaluate()
        {
            Stack<string> workstack = new Stack<string>();
            string sLeft = "";
            string sRight = "";
            double dLeft = 0;
            double dRight = 0;
            string sResult = "";
            int currentConditionalDepth = 0;

            //this.splitPostFunction = postFunction.Split(new char[] { ' ' });

            // loop through the postfix vector
            string token = string.Empty;
            for (int i = 0, numCount = splitPostFunction.Length; i < numCount; i++)
            {
                token = splitPostFunction[i];

                // If the current string is an operator
                if (this.IsOperator(token))
                {
                    // Single operand operators. 
                    if (token == "abs"  ||
                        token == "neg"  ||
                        token == "ln"   ||
                        token == "sign" ||
                        token == "else")
                    {
                        sLeft = workstack.Pop();

                        // Convert the operands
                        dLeft = this.ConvertString(sLeft);  
                    }
                        // Double operand operators
                    else
                    {
                        sRight = workstack.Pop();
                        sLeft = workstack.Pop();

                        // Convert the operands
                        dLeft = this.ConvertString(sLeft);
                        dRight = this.ConvertString(sRight);
                    }

                    // call the operator 
                    switch (token)
                    {
                        case "+":
                            sResult = (dLeft + dRight).ToString();
                            break;

                        case"-":
                            sResult = (dLeft - dRight).ToString();
                            break;

                        case "*":
                            sResult = (dLeft * dRight).ToString();
                            break;

                        case "/":
                            if (dRight == 0) 
                                sResult = (double.NaN).ToString();
                            else
                                sResult = (dLeft / dRight).ToString();
                            break;

                        case "^":
                            sResult = Math.Pow(dLeft, dRight).ToString();
                            break;

                        case "sign":
                            sResult = (dLeft >= 0 ? 1 : -1).ToString();
                            break;

                        case "abs":
                            sResult = Math.Abs(dLeft).ToString();
                            break;

                        case "neg":
                            sResult = (-1 * dLeft).ToString();
                            break;

                        case "ln":
                            // calcualte the natural log.
                            sResult = Math.Log(dLeft).ToString();
                            break;

                        case "<=":
                            if (dLeft <= dRight)
                                sResult = "true";
                            else
                                sResult = "false";
                            break;

                        case "<":
                            if (dLeft < dRight)
                                sResult = "true";
                            else
                                sResult = "false";
                            break;

                        case ">=":
                            if (dLeft >= dRight)
                                sResult = "true";
                            else
                                sResult = "false";
                            break;

                        case ">":
                            if (dLeft > dRight)
                                sResult = "true";
                            else
                                sResult = "false";
                            break;

                        case "==":
                            if (dLeft == dRight)
                                sResult = "true";
                            else
                                sResult = "false";
                            break;

                        case "!=":
                            if (dLeft != dRight)
                                sResult = "true";
                            else
                                sResult = "false";
                            break;

                        case "||":
                            if (dRight == TRUE || dLeft == TRUE)
                                sResult = "true";
                            else
                                sResult = "false";
                            break;

                        case "&&":
                            if (dRight == TRUE && dLeft == TRUE)
                                sResult = "true";
                            else
                                sResult = "false";
                            break;

                        case "elseif":
                            if (currentConditionalDepth > 0)
                            {
                                // Eat the result.
                                continue;
                            }
                            goto case "if";

                        case "if":
                            if (sLeft == "true")
                            {
                                sResult = sRight;
                                currentConditionalDepth++;
                            }
                            else
                            {
                                // Eat the result.
                                continue;
                            }
                            break;

                        case "else":
                            if (currentConditionalDepth > 0)
                            {
                                currentConditionalDepth--;
                                // Eat the result.
                                continue;
                            }
                            else
                            {
                                sResult = sLeft;
                            }
                            break;
                    }

                    // Push the result on the stack
                    workstack.Push(sResult);
                }
                else 
                {
                    // push the string on the workstack
                    workstack.Push(token);
                }
            }

            return workstack.Peek();
        }

        /// <summary>
        /// Converts a string to its value representation.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-20 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="token">The string to check.</param>
        /// <returns></returns>
        protected double ConvertString(string token)
        {
            try
            {
                return variables[token];
            }
            catch
            {
                if (token == "true")
                    return TRUE;
                else if (token == "false")
                    return FALSE;
                else
                    // Convert the operand
                    return double.Parse(token);
            }
        }

        /// <summary>
        /// Overloads the ToString method.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-20 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="token">The string to check.</param>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append(inFunction);
            int count = 0;
            foreach (KeyValuePair<string,double> keyval in variables)
            {
                if (count++ == 0)
                    ret.Append("; ");
                else
                    ret.Append(", ");
                ret.Append(keyval.Key + "=" + keyval.Value);
            }
            return ret.ToString();
        }

        /// <summary>
        /// Checks to see if a string is a number.
        /// </summary>
        /// <remarks><pre>
        /// 2004-08-11 - Jeremy Roberts
        /// </pre></remarks>
        /// <param name="token">The string to check.</param>
        /// <returns>True if is a number, false otherwise.</returns>
        protected bool IsNumber(string token)
        {
            try 
            {
                double.Parse(token);
                return true;
            }
            catch 
            {
                return false;
            }

        }


        #region compilation

        ///// <summary>
        ///// Compiles the functions.
        ///// </summary>
        ///// <remarks><pre>
        ///// 2005-12-20 - Jeremy Roberts
        ///// </pre></remarks>
        //protected void compile() 
        //{
        //    // Code to set up the object.

        //    // Create a new AppDomain.
        //    // Set up assembly.
        //    //
        //    //NewAppDomain = System.AppDomain.CreateDomain("NewApplicationDomain");
        //    //NewAppDomain = appDomain;

        //    AssemblyName assemblyName = new AssemblyName();
        //    assemblyName.Name = "EmittedAssembly";
        //    AssemblyBuilder assembly = Thread.GetDomain().DefineDynamicAssembly(
        //    //AssemblyBuilder assembly = NewAppDomain.DefineDynamicAssembly(
        //        assemblyName,
        //        //AssemblyBuilderAccess.Save);
        //        AssemblyBuilderAccess.Run);
        //        //AssemblyBuilderAccess.RunAndSave);

        //    // Add Dynamic Module
        //    //
        //    ModuleBuilder module;
        //    module = assembly.DefineDynamicModule("EmittedModule");
        //    TypeBuilder dynamicFunctionClass = module.DefineType(
        //        "DynamicFunction",
        //        TypeAttributes.Public,
        //        typeof(DynamicFunction));

        //    // Define class constructor
        //    //
        //    Type objType = Type.GetType("System.Object");
        //    ConstructorInfo objConstructor = objType.GetConstructor(new Type[0]);
        //    Type[] constructorParams = { };
        //    ConstructorBuilder constructor = dynamicFunctionClass.DefineConstructor(
        //        MethodAttributes.Public,
        //        CallingConventions.Standard,
        //        constructorParams);

        //    // Emit the class constructor.
        //    //
        //    ILGenerator constructorIL = constructor.GetILGenerator();
        //    constructorIL.Emit(OpCodes.Ldarg_0);
        //    constructorIL.Emit(OpCodes.Call, objConstructor);
        //    constructorIL.Emit(OpCodes.Ret);

        //    // Define "EvaluateD" function.
        //    //
        //    Type[] args = { typeof(Dictionary<string, double>) };
        //    MethodBuilder evalMethodD = dynamicFunctionClass.DefineMethod(
        //        "EvaluateD",
        //        MethodAttributes.Public | MethodAttributes.Virtual,
        //        typeof(double),
        //        args);
        //    ILGenerator methodILD;
        //    methodILD = evalMethodD.GetILGenerator();
        //    emitFunction(this.PostFix, methodILD);

        //    // Define "EvaluateB" function.
        //    //
        //    MethodBuilder evalMethodB = dynamicFunctionClass.DefineMethod(
        //        "EvaluateB",
        //        MethodAttributes.Public | MethodAttributes.Virtual,
        //        typeof(bool),
        //        args);
        //    ILGenerator methodILB;
        //    methodILB = evalMethodB.GetILGenerator();
        //    emitFunction(this.PostFix, methodILB);

        //    // Create an object to use.
        //    //
        //    Type dt = dynamicFunctionClass.CreateType();
        //    //assembly.Save("assem.dll");
        //    //assembly.Save("x.exe");
        //    //return (function)Activator.CreateInstance(dt, new Object[] { });
        //    this.dynamicFunction = (DynamicFunction)Activator.CreateInstance(dt, new Object[] { });
        //}

        
        //protected void emitFunction(string function, ILGenerator ilGen) 
        //{
        //    string[] splitFunction = function.Split(new char[] { ' ' });

        //    // Set up two double variables.
        //    ilGen.DeclareLocal(typeof(System.Double));
        //    ilGen.DeclareLocal(typeof(System.Double));


        //    foreach (string token in splitFunction)
        //    {
        //        // If the current string is an operator
        //        if (this.IsOperator(token))
        //        {
        //            // call the operator 
        //            switch (token)
        //            {
        //            case "+":
        //                {
        //                    // Add the operands
        //                    ilGen.Emit(OpCodes.Add);
        //                    break;
        //                }

        //            case "-":
        //                {
        //                    // Subtract the operands
        //                    ilGen.Emit(OpCodes.Sub);
        //                    break;
        //                }

        //            case "*":
        //                {
        //                    // Multiply the operands
        //                    ilGen.Emit(OpCodes.Mul);
        //                    break;
        //                }

        //            case "/":
        //                {
        //                    // Divide the operands
        //                    System.Reflection.Emit.Label pushNaN = ilGen.DefineLabel();
        //                    System.Reflection.Emit.Label exit = ilGen.DefineLabel();

        //                    // Store the two variables.
        //                    ilGen.Emit(OpCodes.Stloc_0); // store b in 0
        //                    ilGen.Emit(OpCodes.Stloc_1); // store a in 1

        //                    // Load the denominator and see if its 0.
        //                    ilGen.Emit(OpCodes.Ldloc_0);
        //                    ilGen.Emit(OpCodes.Ldc_R8, 0.0);
        //                    ilGen.Emit(OpCodes.Ceq);
        //                    ilGen.Emit(OpCodes.Brtrue_S, pushNaN);

        //                    // It is not zero, do the division.
        //                    ilGen.Emit(OpCodes.Ldloc_1);
        //                    ilGen.Emit(OpCodes.Ldloc_0);
        //                    ilGen.Emit(OpCodes.Div);
        //                    ilGen.Emit(OpCodes.Br_S, exit);

        //                    // Push NaN
        //                    ilGen.MarkLabel(pushNaN);
        //                    ilGen.Emit(OpCodes.Ldc_R8, double.NaN);

        //                    ilGen.MarkLabel(exit);

        //                    break;
        //                }

        //            case "^":
        //                {
        //                    // Raise the number to the power.
        //                    ilGen.EmitCall(OpCodes.Callvirt,
        //                        typeof(System.Math).GetMethod("Pow"),
        //                        null);
        //                    break;
        //                }

        //            case "sign":
        //                {
        //                    // Get the sign.
        //                    System.Reflection.Emit.Label pushNeg = ilGen.DefineLabel();
        //                    System.Reflection.Emit.Label exit = ilGen.DefineLabel();

        //                    // Compare to see if the value is less then 0
        //                    ilGen.Emit(OpCodes.Stloc_0); // store
        //                    ilGen.Emit(OpCodes.Ldloc_0);
        //                    ilGen.Emit(OpCodes.Ldc_R8, 0.0);
        //                    ilGen.Emit(OpCodes.Clt);
        //                    ilGen.Emit(OpCodes.Brtrue_S, pushNeg);

        //                    // Push 1
        //                    ilGen.Emit(OpCodes.Ldc_R8, 1.0);
        //                    ilGen.Emit(OpCodes.Br_S, exit);

        //                    // Push Neg
        //                    ilGen.MarkLabel(pushNeg);
        //                    ilGen.Emit(OpCodes.Ldc_R8, -1.0);

        //                    ilGen.MarkLabel(exit);

        //                    break;
        //                }

        //            case "abs":
        //                {
        //                    // Convert to postive.
        //                    Type[] absArgs = { typeof(System.Double) };
        //                    ilGen.EmitCall(OpCodes.Callvirt,
        //                        typeof(System.Math).GetMethod("Abs", absArgs),
        //                        null);
        //                    break;
        //                }

        //            case "neg":
        //                {
        //                    // Change the sign.
        //                    ilGen.Emit(OpCodes.Ldc_R8, -1.0);
        //                    ilGen.Emit(OpCodes.Mul);
        //                    break;
        //                }

        //            case "<=":
        //                {
        //                    // Make the comparison.
        //                    System.Reflection.Emit.Label pushFalse = ilGen.DefineLabel();
        //                    System.Reflection.Emit.Label exit = ilGen.DefineLabel();

        //                    // Compare the two values.
        //                    ilGen.Emit(OpCodes.Cgt);
        //                    ilGen.Emit(OpCodes.Brtrue_S, pushFalse);

        //                    // Otherwise its true
        //                    ilGen.Emit(OpCodes.Ldc_R8, TRUE);
        //                    ilGen.Emit(OpCodes.Br_S, exit);

        //                    // Push NaN
        //                    ilGen.MarkLabel(pushFalse);
        //                    ilGen.Emit(OpCodes.Ldc_R8, FALSE);

        //                    ilGen.MarkLabel(exit);
        //                    break;
        //                }

        //            case "<":
        //                {
        //                    // Make the comparison.
        //                    // Compare the two values.
        //                    ilGen.Emit(OpCodes.Clt);
        //                    break;
        //                }

        //            case ">=":
        //                {
        //                    // Make the comparison.
        //                    System.Reflection.Emit.Label pushFalse = ilGen.DefineLabel();
        //                    System.Reflection.Emit.Label exit = ilGen.DefineLabel();

        //                    // Compare the two values.
        //                    ilGen.Emit(OpCodes.Clt);
        //                    ilGen.Emit(OpCodes.Brtrue_S, pushFalse);

        //                    // Otherwise its true
        //                    ilGen.Emit(OpCodes.Ldc_R8, TRUE);
        //                    ilGen.Emit(OpCodes.Br_S, exit);

        //                    // Push NaN
        //                    ilGen.MarkLabel(pushFalse);
        //                    ilGen.Emit(OpCodes.Ldc_R8, FALSE);

        //                    ilGen.MarkLabel(exit);
        //                    break;
        //                }

        //            case ">":
        //                {
        //                    // Make the comparison.
        //                    ilGen.Emit(OpCodes.Cgt);
        //                    break;
        //                }

        //            case "==":
        //                {
        //                    // Make the comparison.
        //                    ilGen.Emit(OpCodes.Ceq);
        //                    break;
        //                }

        //            case "!=":
        //                {
        //                    // Make the comparison.
        //                    System.Reflection.Emit.Label pushFalse = ilGen.DefineLabel();
        //                    System.Reflection.Emit.Label exit = ilGen.DefineLabel();

        //                    // Compare the two values.
        //                    ilGen.Emit(OpCodes.Ceq);
        //                    ilGen.Emit(OpCodes.Brtrue_S, pushFalse);

        //                    // Otherwise its true
        //                    ilGen.Emit(OpCodes.Ldc_R8, TRUE);
        //                    ilGen.Emit(OpCodes.Br_S, exit);

        //                    // Push NaN
        //                    ilGen.MarkLabel(pushFalse);
        //                    ilGen.Emit(OpCodes.Ldc_R8, FALSE);

        //                    ilGen.MarkLabel(exit);

        //                    break;
        //                }

        //            case "||":
        //                {
        //                    // Make the comparison.
        //                    System.Reflection.Emit.Label pushTrue = ilGen.DefineLabel();
        //                    System.Reflection.Emit.Label exit = ilGen.DefineLabel();

        //                    // Store the two variables.
        //                    ilGen.Emit(OpCodes.Stloc_0);
        //                    ilGen.Emit(OpCodes.Stloc_1);

        //                    // Compare the two values.
        //                    ilGen.Emit(OpCodes.Ldloc_0);
        //                    ilGen.Emit(OpCodes.Brtrue_S, pushTrue);
        //                    ilGen.Emit(OpCodes.Ldloc_1);
        //                    ilGen.Emit(OpCodes.Brtrue_S, pushTrue);

        //                    // Otherwise its false
        //                    ilGen.Emit(OpCodes.Ldc_R8, FALSE);
        //                    ilGen.Emit(OpCodes.Br_S, exit);

        //                    // Push NaN
        //                    ilGen.MarkLabel(pushTrue);
        //                    ilGen.Emit(OpCodes.Ldc_R8, TRUE);

        //                    ilGen.MarkLabel(exit);
        //                    break;
        //                }

        //            case "&&":
        //                {
        //                    // Make the comparison.
        //                    System.Reflection.Emit.Label pushFalse = ilGen.DefineLabel();
        //                    System.Reflection.Emit.Label exit = ilGen.DefineLabel();

        //                    // Store the two variables.
        //                    ilGen.Emit(OpCodes.Stloc_0);
        //                    ilGen.Emit(OpCodes.Stloc_1);

        //                    // Compare the two values.
        //                    ilGen.Emit(OpCodes.Ldloc_0);
        //                    ilGen.Emit(OpCodes.Brfalse_S, pushFalse);
        //                    ilGen.Emit(OpCodes.Ldloc_1);
        //                    ilGen.Emit(OpCodes.Brfalse_S, pushFalse);

        //                    // Otherwise its true
        //                    ilGen.Emit(OpCodes.Ldc_R8, TRUE);
        //                    ilGen.Emit(OpCodes.Br_S, exit);

        //                    // Push NaN
        //                    ilGen.MarkLabel(pushFalse);
        //                    ilGen.Emit(OpCodes.Ldc_R8, FALSE);

        //                    ilGen.MarkLabel(exit);
        //                    break;
        //                }
        //            }

        //        }
        //        else if (IsVariable(token))
        //        {
        //            // push the string on the workstack
        //            ilGen.Emit(OpCodes.Ldarg_1);
        //            ilGen.Emit(OpCodes.Ldstr, token);
        //            ilGen.EmitCall(OpCodes.Callvirt,
        //                typeof(System.Collections.Generic.Dictionary<string, double>).GetMethod("get_Item"),
        //                null);
        //            //ilGen.Emit(OpCodes.Unbox_Any, typeof(System.Double));
        //        }
        //        else if (token.Equals("true"))
        //        {
        //            ilGen.Emit(OpCodes.Ldc_R8, TRUE);
        //        }
        //        else if (token.Equals("false"))
        //        {
        //            ilGen.Emit(OpCodes.Ldc_R8, FALSE);
        //        }
        //        else
        //        {
        //            // Parse the number.
        //            ilGen.Emit(OpCodes.Ldc_R8, double.Parse(token));
        //        }
        //    }
        //    ilGen.Emit(OpCodes.Ret);
        //}

        #endregion

    }
}

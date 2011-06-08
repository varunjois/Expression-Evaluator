/*****************************************************************************************
* Jeremy Roberts                                                           Expression.cs *
* 2004-07-23                                                                     Wfccm2 *
*****************************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Vanderbilt.Biostatistics.Wfccm2
{

    public class Variable<T> : IVariable
    {
        public T Value;
        public Variable(string name, T value)
        {
            _name = name;
            Value = value;
        }

        public string _name;

        public string Name
        {
            get { return _name; }
        }

        public Type Type { get { return typeof(T); } }
    }

    public interface IVariable
    {
        string Name { get; }
        Type Type { get; }
    }

    //public class DoubleVariable : Variable
    //{
    //    public DoubleVariable(double value) { Value = value; }
    //    public double Value;
    //    public override Type Type { get { return typeof(double); } }

    //}

    //public class StringVariable : Variable
    //{
    //    public DoubleVariable(double value) { Value = value; }
    //    public string Value;
    //    public override Type Type { get { return typeof(string); } }
    //}

    //public class DateTimeVariable : Variable
    //{
    //    public DateTime Value;
    //    public override Type Type { get { return typeof(DateTime); } }
    //}

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
        protected DynamicFunction _dynamicFunction;
        //protected AppDomain NewAppDomain;


        #region Member data
        
        /// <summary>
        /// The function.
        /// </summary>
        protected InfixExpression _inFunction;
        protected PostFixExpression _postFunction;
        protected Dictionary<string, IVariable> _variables = new Dictionary<string, IVariable>();
        protected const double TRUE = 1;
        protected const double FALSE = 0;
        protected string[] _splitPostFunction;

        #endregion

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
            get{return _inFunction.Original;}
            set{
                _inFunction = new InfixExpression(value);
                _postFunction = new PostFixExpression(_inFunction);
                ClearVariables();
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
            get { return _postFunction.Expression; }
        }

        /// <summary>
        /// PostFix property
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        public string InFix
        {
            get { return _inFunction.Expression; }
        }

        #endregion

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
            var v = new Variable<double>(name, val);
            _variables[name] = v;
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
            var v = new Variable<bool>(name, val);
            _variables[name] = v;
        }

        public void AddSetVariable(string name, DateTime val)
        {
            var v = new Variable<DateTime>(name, val);
            _variables[name] = v;
        }

        /// <summary>
        /// Clears the variable information.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        public void ClearVariables()
        {
            _variables.Clear();
        }

        /// <summary>
        /// Clears all information.
        /// </summary>
        /// <remarks><pre>
        /// 2004-07-19 - Jeremy Roberts
        /// </pre></remarks>
        public void Clear()
        {
            _inFunction = null;
            _postFunction = null;
            _variables.Clear();
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
            if (token == "true" || token == "false")
                return false;

            if (!ExpressionKeywords.IsOperand(token))
                return false;

            if (IsNumber(token))
                return false;

            return true;
        }

        public ReadOnlyCollection<string> FunctionVariables
        {
            get
            {
                if (_inFunction == null)
                    throw new ExpressionException("Function does not exist");

                // The arraylist to return
                List<string> retVal = new List<string>();

                // Check each token to see if its a variable.
                foreach (string token in _inFunction.Tokens)
                {
                    if (IsVariable(token))
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
                return ((Variable<double>)_variables[token]).Value;
            }
            catch
            {
                return double.NaN;                
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

            if (ConvertString(result) == TRUE)
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

            // loop through the postfix vector
            string token = string.Empty;
            for (int i = 0, numCount = _postFunction.Tokens.Length; i < numCount; i++)
            {
                token = _postFunction.Tokens[i];

                // If the current string is an operator
                if (ExpressionKeywords.IsOperator(token))
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
                            sResult = dRight == 0 ? (double.NaN).ToString() : (dLeft / dRight).ToString();
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
                            sResult = dLeft <= dRight ? "true" : "false";
                            break;

                        case "<":
                            sResult = dLeft < dRight ? "true" : "false";
                            break;

                        case ">=":
                            sResult = dLeft >= dRight ? "true" : "false";
                            break;

                        case ">":
                            sResult = dLeft > dRight ? "true" : "false";
                            break;

                        case "==":
                            sResult = dLeft == dRight ? "true" : "false";
                            break;

                        case "!=":
                            sResult = dLeft != dRight ? "true" : "false";
                            break;

                        case "||":
                            sResult = dRight == TRUE || dLeft == TRUE ? "true" : "false";
                            break;

                        case "&&":
                            sResult = dRight == TRUE && dLeft == TRUE ? "true" : "false";
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
                            sResult = sLeft;
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
                return ((Variable<double>)_variables[token]).Value;
            }
            catch
            {
                if (token == "true")
                    return TRUE;
                
                if (token == "false")
                    return FALSE;
                
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
            ret.Append(_inFunction);
            int count = 0;
            foreach (var keyval in _variables)
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

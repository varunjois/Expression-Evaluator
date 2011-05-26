// ReSharper disable InconsistentNaming
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vanderbilt.Biostatistics.Wfccm2;

namespace PETNet.Olympus.Tests.ExpressionTesting.Interpreted.Functionality
{
    /// <summary>
    /// Summary description for ExpressionTests
    /// </summary>
    [TestClass]
    public class ExpressionTest
    {
        Expression func;

        [TestInitialize]
        public void init()
        { this.func = new Expression(""); }

        [TestCleanup]
        public void clear()
        { func.Clear(); }

        [TestMethod]
        public void ClearVariables_Call_VariableAreCleared()
        {
            func.Function = "a+b";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            func.ClearVariables();
            Assert.AreEqual(true, double.IsNaN(func.GetVariableValue("a")));
            Assert.AreEqual(true, double.IsNaN(func.GetVariableValue("b")));
        }

        [TestMethod]
        public void Variable_SetThenChanged_IsCorrect()
        {
            func.Function = "a+b";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual(2, func.GetVariableValue("a"));
            Assert.AreEqual(3, func.GetVariableValue("b"));

            func.AddSetVariable("a", 3);
            func.AddSetVariable("b", 4);
            Assert.AreEqual(3, func.GetVariableValue("a"));
            Assert.AreEqual(4, func.GetVariableValue("b"));
        }

        [TestMethod]
        public void Variable002()
        {
            func.Function = "a+b";
            Assert.AreEqual(true, double.IsNaN(func.GetVariableValue("a")));
            Assert.AreEqual(true, double.IsNaN(func.GetVariableValue("b")));
        }

        [TestMethod]
        public void ToString001()
        {
            func.Function = "a + b";
            Assert.AreEqual("a + b", func.ToString());
        }

        [TestMethod]
        public void ToString002()
        {
            func.Function = "a + b";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual("a + b; a=2, b=3", func.ToString());
        }

        [TestMethod]
        public void PostFix001()
        {
            func.Function = "a + b";
            Assert.AreEqual("a b +", func.PostFix);
        }

        [TestMethod]
        public void PostFix002()
        {
            func.Function = "a+b";
            Assert.AreEqual("a b +", func.PostFix);
        }

        [TestMethod]
        public void InFix001()
        {
            func.Function = "a+b";
            Assert.AreEqual("a + b", func.InFix);
        }

        [TestMethod]
        public void InFix002()
        {
            func.Function = "a+ b";
            Assert.AreEqual("a + b", func.InFix);
        }

        [TestMethod]
        public void InFix003()
        {
            func.Function = "a +b";
            Assert.AreEqual("a + b", func.InFix);
        }

        [TestMethod]
        public void InFix004()
        {
            func.Function = "a + b";
            Assert.AreEqual("a + b", func.InFix);
        }

        [TestMethod]
        public void InFix005()
        {
            func.Function = "a+b-2*3/66*sign(-3)+abs(-16)^3";
            Assert.AreEqual("a + b - 2 * 3 / 66 * sign ( -3 ) + abs ( -16 ) ^ 3", func.InFix);
        }

        [TestMethod]
        public void PostFix003()
        {
            func.Function = "a+b - 2";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual("a b + 2 -", func.PostFix);
        }

        [TestMethod]
        public void Function001()
        {
            func.Function = "a+b - 2";
            Assert.AreEqual("a+b - 2", func.Function);
        }

        [TestMethod]
        public void Function002()
        {
            func.Function = "a +b - 2";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual("a +b - 2", func.Function);
        }

        [TestMethod]
        public void Function003()
        {
            func.Function = "a + b - 2";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual("a + b - 2", func.Function);
        }

        [TestMethod]
        public void DivideByZero_EvaluateFunction001_IsNotANumber()
        {
            func.Function = "2/0";
            Assert.AreEqual(true, double.IsNaN(func.EvaluateNumeric()));
        }

        [TestMethod]
        public void DivideByZero_EvaluateFunction002_IsNotANumber()
        {
            func.Function = "2/(1-1)";
            Assert.AreEqual(true, double.IsNaN(func.EvaluateNumeric()));
        }

        [TestMethod]
        public void Evaulate_CheckFloatingPointErrors_IsCorrect()
        {
            func.Function = "99.999999999999/100";
            Assert.AreEqual(0.99999999999999, func.EvaluateNumeric());
        }

        #region Expression Errors

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Abs_BadExpression001_ExpressionException()
        {
            Action a = () => func.Function = "abs -165";
            TestHelpers.ExecuteActionExpectException(a, "Abs not formatted correctly. Open and close parenthesis required.");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Abs_NoParenthisis001_ExpressionException()
        {
            Action a = () => func.Function = "abs 8964 ";
            TestHelpers.ExecuteActionExpectException(a, "Abs not formatted correctly. Open and close parenthesis required.");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Abs_NoParenthisis002_ExpressionException()
        {
            Action a = () => func.Function = "abs 0";
            TestHelpers.ExecuteActionExpectException(a, "Abs not formatted correctly. Open and close parenthesis required.");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Abs_NoClosingParenthisis_ExpressionException()
        {
            Action a = () => func.Function = "abs (10";
            TestHelpers.ExecuteActionExpectException(a, "Abs not formatted correctly. Open and close parenthesis required.");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Abs_NoOpeningParenthisis_ExpressionException()
        {
            Action a = () => func.Function = "abs 20)";
            TestHelpers.ExecuteActionExpectException(a, "Abs not formatted correctly. Open and close parenthesis required.");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Addition_BadExpression001_ExpressionException()
        {
            Action a = () => func.Function = "1+";
            TestHelpers.ExecuteActionExpectException(a, "operator error");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void And_BadExpression001_ExpressionException()
        {
            Action a = () => func.Function = " && true";
            TestHelpers.ExecuteActionExpectException(a, "operator error");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void And_BadExpression002_ExpressionException()
        {
            Action a = () => func.Function = "true && ";
            TestHelpers.ExecuteActionExpectException(a, "operator error");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Division_BadExpression001_ExpressionException()
        {
            Action a = () => func.Function = "/73";
            TestHelpers.ExecuteActionExpectException(a, "operator error");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Division_BadExpression002_ExpressionException()
        {
            Action a = () => func.Function = "/9832";
            TestHelpers.ExecuteActionExpectException(a, "operator error");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Equal_BadExpression001_ExpressionException()
        {
            Action a = () => func.Function = "== 5.2";
            TestHelpers.ExecuteActionExpectException(a, "operator error");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Equal_BadExpression002_ExpressionException()
        {
            Action a = () => func.Function = "4 ==";
            TestHelpers.ExecuteActionExpectException(a, "operator error");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void GreaterEqual_BadExpression001_ExpressionException()
        {
            Action a = () => func.Function = "4 >=";
            TestHelpers.ExecuteActionExpectException(a, "operator error");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void GreaterEqual_BadExpression002_ExpressionException()
        {
            Action a = () => func.Function = ">= 4";
            TestHelpers.ExecuteActionExpectException(a, "operator error");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Greater_BadExpression001_ExpressionException()
        {
            func.Function = "> 2";
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Greater_BadExpression002_ExpressionException()
        {
            func.Function = "4 >";
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Less_BadExpression001_ExpressionException()
        {
            func.Function = "< 5.2";
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Less_BadExpression002_ExpressionException()
        {
            func.Function = "4 <";
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void LessEqual_BadExpression001_ExpressionException()
        {
            func.Function = "<= 6";
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void LessEqual_BadExpression002_ExpressionException()
        {
            func.Function = "4 <=";
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Multiplication_BadExpression001_ExpressionException()
        { func.Function = "*2"; }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Multiplication_BadExpression002_ExpressionException()
        { func.Function = "3*"; }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void MultipleBooleanOperators_BadExpression001_ExpressionException()
        {
            func.Function = "true ||  && false || false";
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void MultipleBooleanOperators_BadExpression002_ExpressionException()
        {
            func.Function = "(true || false) && ( || false)";
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void MulitpleOperators_BadExpression001_ExpressionException()
        { func.Function = "1+(2*)"; }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void MulitpleOperators_BadExpression002_ExpressionException()
        { func.Function = "1/2*"; }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void MultipleOperators_BadExpression003_ExpressionException()
        {
            func.Function = "(true || false) && false || ";
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void MultipleOperators_BadExpression004_ExpressionException()
        {
            func.Function = "(true || ) && true";
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void MulitpleOperators_BadExpression005_ExpressionException()
        { func.Function = "1-(2+3)2"; }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void MulitpleOperators_BadExrpession006_ExpressionException()
        { func.Function = "+1/"; }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void MulitpleOperators_BadExpression007_ExpressionException()
        { func.Function = "1-2-3-3-2-"; }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void MulitpleOperators_BadExpression008_ExpressionException()
        {
            func.Function = "4 > abs(neg )";
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void MulitpleOperators_BadExpression009_ExpressionException()
        {
            func.Function = " > abs(neg 3.2)";
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void MulitpleOperators_BadExpression010_ExpressionException()
        {
            func.Function = "4 neg(abs(5.2))";
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void NotEqual_BadExpression001_ExpressionException()
        {
            func.Function = "4 !=";
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void NotEqual_BadExpression002_ExpressionException()
        {
            func.Function = "!= 4";
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Negation_BadExpression001_ExpressionException()
        { func.Function = "9832 neg"; }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Or_BadExpression001_ExpressionException()
        {
            func.Function = "true || ";
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Or_BadExpression002_ExpressionException()
        {
            func.Function = "|| false";
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Power_BadExpression001_ExpressionException()
        { func.Function = "2^"; }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Power_BadExpression002_ExpressionException()
        { func.Function = "^2"; }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Subtraction_BadExpression001_ExpressionException()
        { func.Function = "332-"; }

        #endregion

        #region Grouping Errors

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Braces_MissingClose001_ExpressionException()
        {
            Action a = () => func.Function = "((1+2)";
            TestHelpers.ExecuteActionExpectException(a, "close missing");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Braces_MissingClose002_ExpressionException()
        {
            Action a = () => func.Function = "(1+2";
            TestHelpers.ExecuteActionExpectException(a, "close missing");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Braces_MissingOpen001_ExpressionException()
        {
            Action a = () => func.Function = "1+2)";
            TestHelpers.ExecuteActionExpectException(a, "open missing");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Braces_MissingOpen002_ExpressionException()
        {
            Action a = () => func.Function = ")(1+2)";
            TestHelpers.ExecuteActionExpectException(a, "open missing");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Parenthesis_MissingClose001_ExpressionException()
        {
            Action a = () => func.Function = "((1+2)";
            TestHelpers.ExecuteActionExpectException(a, "close missing");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Parenthesis_MissingClose002_ExpressionException()
        {
            Action a = () => func.Function = "(1+2";
            TestHelpers.ExecuteActionExpectException(a, "close missing");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Parenthesis_MissingOpen001_ExpressionException()
        {
            Action a = () => func.Function = "1+2)";
            TestHelpers.ExecuteActionExpectException(a, "open missing");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Parenthesis_MissingOpen002_ExpressionException()
        {
            Action a = () => func.Function = ")(1+2)";
            TestHelpers.ExecuteActionExpectException(a, "open missing");
        }

        #endregion

        #region Operators

        [TestMethod]
        public void Abs001()
        {
            func.Function = "abs(-165)";
            Assert.AreEqual(165, func.EvaluateNumeric());
        }

        [TestMethod]
        public void Abs002()
        {
            func.Function = "abs(8964)";
            Assert.AreEqual(8964, func.EvaluateNumeric());
        }

        [TestMethod]
        public void Abs003()
        {
            func.Function = "abs(0)";
            Assert.AreEqual(0, func.EvaluateNumeric());
        }

        [TestMethod]
        public void Addition002()
        {
            func.Function = "+2";
            Assert.AreEqual(2, func.EvaluateNumeric(), "Expected 2");
        }

        [TestMethod]
        public void Ln_001()
        {
            func.Function = "ln(5)";
            Assert.AreEqual(1.6094379124341, func.EvaluateNumeric());
        }

        [TestMethod]
        public void Ln_002()
        {
            func.Function = "ln(5) + 1";
            Assert.AreEqual(2.6094379124341, func.EvaluateNumeric());
        }

        [TestMethod]
        public void Ln_003()
        {
            func.Function = "ln(5) * 2";
            Assert.AreEqual(3.2188758248682, func.EvaluateNumeric());
        }

        [TestMethod]
        public void Negation002()
        {
            func.Function = "neg(9832)";
            Assert.AreEqual(-9832, func.EvaluateNumeric());
        }

        [TestMethod]
        public void Sign001()
        {
            func.Function = "sign(-9832)";
            Assert.AreEqual(-1, func.EvaluateNumeric());
        }

        [TestMethod]
        public void Sign002()
        {
            func.Function = "sign(2341)";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [TestMethod]
        public void Sign003()
        {
            func.Function = "sign(0)";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [TestMethod]
        public void Sign004()
        {
            func.Function = "sign(-12)";
            Assert.AreEqual(-1, func.EvaluateNumeric());
        }

        [TestMethod]
        public void Sign005()
        {
            func.Function = "sign(12)";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [TestMethod]
        public void Sign006()
        {
            func.Function = "sign(0)";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [TestMethod]
        public void Subtraction001()
        {
            func.Function = "-23";
            Assert.AreEqual(-23, func.EvaluateNumeric(), "Expected -23");
        }

        [TestMethod]
        public void Subtraction002()
        {
            func.Function = "-22-23";
            Assert.AreEqual(-45, func.EvaluateNumeric(), "Expected -23");
        }

        [TestMethod]
        public void Or_ValidExpression001_IsCorrect()
        {
            func.Function = "true || true";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void Or_ValidExpression002_IsCorrect()
        {

            func.Function = "true || false";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void Or_ValidExpression003_IsCorrect()
        {
            func.Function = "false || true";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void Or_ValidExpression004_IsCorrect()
        {
            func.Function = "false || false";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [TestMethod]
        public void And_ValidExpression001_IsCorrect()
        {
            func.Function = "true && true";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void And_ValidExpression002_IsCorrect()
        {
            func.Function = "true && false";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [TestMethod]
        public void And_ValidExpression003_IsCorrect()
        {
            func.Function = "false && true";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [TestMethod]
        public void And_ValidExpression004_IsCorrect()
        {
            func.Function = "false && false";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [TestMethod]
        public void MixedAndOr_ValidExpression001_IsCorrect()
        {
            func.Function = "true || false && false || false";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void MixedAndOr_ValidExpression002_IsCorrect()
        {
            func.Function = "(true || false) && (false || false)";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [TestMethod]
        public void MixedAndOr_ValidExpression003_IsCorrect()
        {
            func.Function = "(true || false) && false || false";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [TestMethod]
        public void MixedAndOr_ValidExpression004_IsCorrect()
        {
            func.Function = "(true || false) && true";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void GreaterEqual_ValidExpression001_IsCorrect()
        {
            func.Function = "4 >= 2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void GreaterEqual_ValidExpression002_IsCorrect()
        {
            func.Function = "4 >= 4";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void GreaterEqual_ValidExpression003_IsCorrect()
        {
            func.Function = "4 >= 6";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [TestMethod]
        public void LessEqual_ValidExpression001_IsCorrect()
        {
            func.Function = "4 <= 6";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void LessEqual_ValidExpression002_IsCorrect()
        {
            func.Function = "4 <= 4";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void LessEqual_ValidExpression003_IsCorrect()
        {
            func.Function = "4 <= 2";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [TestMethod]
        public void Greater_ValidExpression001_IsCorrect()
        {
            func.Function = "4 > 2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void Greater_ValidExpression002_IsCorrect()
        {
            func.Function = "4 > 5.2";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [TestMethod]
        public void Equal_ValidExpression001_IsCorrect()
        {
            func.Function = "4 == 5.2";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [TestMethod]
        public void Equal_ValidExpression002_IsCorrect()
        {
            func.Function = "4 == 4";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void Less_ValidExpression001_IsCorrect()
        {
            func.Function = "4 < 5.2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void Less_ValidExpression002_IsCorrect()
        {
            func.Function = "4 < 3";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        #endregion

        #region Sciencific Notation

        [TestMethod]
        public void SciNotation_Expression001_IsCorrect()
        {
            func.Function = "1 - 2 - 3 - 4 - 5e-1 - 7";
            Assert.AreEqual(-15.5, func.EvaluateNumeric());
        }

        [TestMethod]
        public void SciNotation_Expression002_IsCorrect()
        {
            func.Function = "1 - 2 - 3E - 1 - 5e - 1 - 7";
            Assert.AreEqual(-8.8, func.EvaluateNumeric());
        }

        [TestMethod]
        public void SciNotation_Expression003_IsCorrect()
        {
            func.Function = "1 + 2 - 3e + 1 - 5e - 1 - 7";
            Assert.AreEqual(-34.5, func.EvaluateNumeric());
        }

        [TestMethod]
        public void SciNotation_Expression004_IsCorrect()
        {
            func.Function = "3e - 4 - 5e - 6";
            Assert.AreEqual(0.000295, func.EvaluateNumeric());
        }

        [TestMethod]
        public void SciNotation_Expression005_IsCorrect()
        {
            func.Function = "3 - - 4 - 5e - 1";
            Assert.AreEqual(6.5, func.EvaluateNumeric());
        }

        [TestMethod]
        public void SciNotation_Expression006_IsCorrect()
        {
            func.Function = "( 3 + 4 ) * - 4 - 5e-2";
            Assert.AreEqual(-28.05, func.EvaluateNumeric());
        }

        [TestMethod]
        public void SciNotation_Expression007_IsCorrect()
        {
            func.Function = "( 3 + 4 ) * - 403 - 5e-2";
            Assert.AreEqual(-2821.05, func.EvaluateNumeric());
        }

        [TestMethod]
        public void SciNotation_Expression008_IsCorrect()
        {
            func.Function = "403 - - 4 + -5";
            Assert.AreEqual(402, func.EvaluateNumeric());
        }

        [TestMethod]
        public void SciNotation_Expression009_IsCorrect()
        {
            func.Function = "( 3 + 4 ) * - 403 - - 5e-1";
            Assert.AreEqual(-2820.5, func.EvaluateNumeric());
        }

        [TestMethod]
        public void SciNotation_Expression010_IsCorrect()
        {
            func.Function = "- 403 + - 3 + - 4";
            Assert.AreEqual(-410, func.EvaluateNumeric());
        }

        [TestMethod]
        public void SciNotation_Expression011_IsCorrect()
        {
            func.Function = "- 403 + - 3e + 2 + - 4";
            Assert.AreEqual(-707, func.EvaluateNumeric());
        }

        [TestMethod]
        public void SciNotation_Expression012_IsCorrect()
        {
            func.Function = "- 403 + - 3e-1 + - 4e+2";
            Assert.AreEqual(-803.3, func.EvaluateNumeric());
        }

        [TestMethod]
        public void SciNotation_Expression013_IsCorrect()
        {
            func.Function = "- 403 + - 3e+2 + - 4e+4";
            Assert.AreEqual(-40703, func.EvaluateNumeric());
        }

        [TestMethod]
        public void SciNotation_Expression014_IsCorrect()
        {
            func.Function = "- 403e-2 + - 3e-6 + - 4e-8";
            Assert.AreEqual(-4.03000304, func.EvaluateNumeric());
        }

        [TestMethod]
        public void SciNotation_Expression015_IsCorrect()
        {
            func.Function = "- 403e+2 + - 3e-2 + - 4e+2";
            Assert.AreEqual(-40700.03, func.EvaluateNumeric());
        }

        [TestMethod]
        public void SciNotation_Expression016_IsCorrect()
        {
            func.Function = "( - 3 + 4 ) * - 403 - - 5e-1";
            Assert.AreEqual(-402.5, func.EvaluateNumeric());
        }

        #endregion

        [TestMethod]
        public void EvaluationWithVariables001()
        {
            func.Function = "a^3";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [TestMethod]
        public void EvaluationWithVariables002()
        {
            func.Function = "a^b";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [TestMethod]
        public void EvaluationWithVariables003()
        {
            func.Function = "a^2";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("a", 3);
            Assert.AreEqual(9, func.EvaluateNumeric());
        }

        [TestMethod]
        public void EvaluationWithVariables004()
        {
            func.Function = "a^b";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("a", 3);
            func.AddSetVariable("b", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual(27, func.EvaluateNumeric());
        }

        [TestMethod]
        public void EvaluationWithVariables005()
        {
            func.Function = "(a^b)/2";
            func.AddSetVariable("a", 4);
            func.AddSetVariable("b", 2);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [TestMethod]
        public void VariableNames_WithNumbers_SetsCorrectly()
        {
            func.Function = "a118+2";
            func.AddSetVariable("a118", 6);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [TestMethod]
        public void VariableNames_ContainsSign_SetsCorrectly()
        {
            func.Function = "signature+2";
            func.AddSetVariable("signature", 6);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [TestMethod]
        public void VariableNames_ContainsAbs_SetsCorrectly()
        {
            func.Function = "absolute+2";
            func.AddSetVariable("absolute", 6);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [TestMethod]
        public void VariableNames_ContainsLn_SetsCorrectly()
        {
            func.Function = "pillname+2";
            func.AddSetVariable("pillname", 6);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [TestMethod]
        public void NumericalBooleanEvaluation013()
        {
            func.Function = "4 > abs(neg (5.2))";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [TestMethod]
        public void NumericalBooleanEvaluation014()
        {
            func.Function = "4 > abs(neg (3.2))";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void NumericalBooleanEvaluation015()
        {
            func.Function = "4 > neg(abs(5.2))";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void NotEqual_ValidExpression001_IsCorrect()
        {
            func.Function = "4 != 5.2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void NotEqual_ValidExpression002_IsCorrect()
        {
            func.Function = "4 != 4";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [TestMethod]
        public void BooleanEvaluationWithVariables001()
        {
            func.Function = "a == 4";
            func.AddSetVariable("a", 4);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void BooleanEvaluationWithVariables002()
        {
            func.Function = "a == b";
            func.AddSetVariable("a", 4);
            func.AddSetVariable("b", 4);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void BooleanEvaluationWithVariables003()
        {
            func.Function = "a != b";
            func.AddSetVariable("a", 4);
            func.AddSetVariable("b", 4);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [TestMethod]
        public void BooleanEvaluationWithVariables004()
        {
            func.Function = "a && b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", true);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void BooleanEvaluationWithVariables005()
        {
            func.Function = "a && b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [TestMethod]
        public void BooleanEvaluationWithVariables006()
        {
            func.Function = "a && b";
            func.AddSetVariable("a", false);
            func.AddSetVariable("b", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [TestMethod]
        public void BooleanEvaluationWithVariables007()
        {
            func.Function = "a && b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [TestMethod]
        public void BooleanEvaluationWithVariables008()
        {
            func.Function = "a || b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", true);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void BooleanEvaluationWithVariables009()
        {
            func.Function = "a || b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void BooleanEvaluationWithVariables010()
        {
            func.Function = "a || b";
            func.AddSetVariable("a", false);
            func.AddSetVariable("b", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [TestMethod]
        public void BooleanEvaluationWithVariables011()
        {
            func.Function = "a || b && c || d";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            func.AddSetVariable("c", true);
            func.AddSetVariable("d", false);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void BooleanEvaluationWithVariables012()
        {
            func.Function = "a || b && c || d";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            func.AddSetVariable("c", false);
            func.AddSetVariable("d", false);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void BooleanEvaluationWithVariables014()
        {
            func.Function = "(a || b) && (c || d)";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            func.AddSetVariable("c", true);
            func.AddSetVariable("d", false);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [TestMethod]
        public void BooleanEvaluationWithVariables015()
        {
            func.Function = "(a || b) && (c || d)";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            func.AddSetVariable("c", false);
            func.AddSetVariable("d", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void IfElse_IfNoOperator_ExpressionException()
        {
            Action a = () => func.Function = @"if  {  } else { 1 }";
            TestHelpers.ExecuteActionExpectException(a, "Operator Error");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void IfElse_IfNoExpression_ExpressionException()
        {
            Action a = () => func.Function = @"if (true)  {  } else { 1 }";
            TestHelpers.ExecuteActionExpectException(a, "Operator Error");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void IfElse_ElseNoOperator_ExpressionException()
        {
            Action a = () => func.Function = @"if (true)  { 1  } else { }";
            TestHelpers.ExecuteActionExpectException(a, "Operator Error");
        }


        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IfElse_IfStringOperator_ExpressionException()
        {
            func.Function = @"if ( val )  { 1 } else { 1 }";

            Action a = () => func.EvaluateNumeric();
            
            TestHelpers.ExecuteActionExpectException(a, "not in a correct format");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void IfElse_OutOfOrder001_ExpressionException()
        {
            Action a = () => func.Function = @"else { 2 } if (true) { 1 }";
            TestHelpers.ExecuteActionExpectException(a, "Conditional Error");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void Grouping_OutOfOrder001_ExpressionException()
        {
            Action a = () => func.Function = @"if (true { ) 2 } else { 1 }";
            TestHelpers.ExecuteActionExpectException(a, "Grouping error");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void IfElse_OutOfOrder003_ExpressionException()
        {
            Action a = () => func.Function = @"if (true) { 2 } if else (true) { 1 }";
            TestHelpers.ExecuteActionExpectException(a, "Conditional Error");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void IfElse_IfElseMismatch001_ExpressionException()
        {
            Action a = () => func.Function = @"if (true) { 2 } else if { 1 }";
            TestHelpers.ExecuteActionExpectException(a, "Conditional Error");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void IfElse_IfElseMismatch002_ExpressionException()
        {
            Action a = () => func.Function = @"if (true) { 2 } else if (true) { 1 }";
            TestHelpers.ExecuteActionExpectException(a, "Conditional Error");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void IfElse_ElseWithBoolean001_ExpressionException()
        {
            Action a = () => func.Function = @"if (true) { 2 } else (true) { 1 }";
            TestHelpers.ExecuteActionExpectException(a, "Conditional Error");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void IfElse_ElseWithBoolean002_ExpressionException()
        {
            Action a = () => func.Function = @"if (true) { 2 } else if (true) { 1 } else (true) { 1 }";
            TestHelpers.ExecuteActionExpectException(a, "Conditional Error");
        }

        [TestMethod]
        [ExpectedException(typeof(ExpressionException))]
        public void IfElse_NestedElseWithBoolean001_ExpressionException()
        {
            Action a = () => func.Function = @"if (true) { if (true) { 3 } else (true) { 2 } } else { 1 }";
            TestHelpers.ExecuteActionExpectException(a, "Conditional Error");
        }

        [TestMethod]
        public void IfElse_CorrectFormat001_IsCorrect()
        {
            func.Function = "if (true) { 1 } else { 2 }";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [TestMethod]
        public void IfElse_CorrectFormat002_IsCorrect()
        {
            func.Function = "if (false) { 1 } else { 2 }";
            Assert.AreEqual(2, func.EvaluateNumeric());
        }

        [TestMethod]
        public void IfElse_CorrectFormat003_IsCorrect()
        {
            func.Function = "5 + if (true) { 1 } else { 2 }";
            // 5 true 1 if 2 else +
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [TestMethod]
        public void IfElse_ToInfix001_IsCorrect()
        {
            func.Function = "5 + if (true) { 1 } else { 2 }";
            Assert.AreEqual("5 true 1 if 2 else +", func.PostFix);
        }

        [TestMethod]
        public void IfElse_CorrectFormat004_IsCorrect()
        {
            func.Function = "5 + if (false) { 1 } else { 2 }";
            Assert.AreEqual(7, func.EvaluateNumeric());
        }

        [TestMethod]
        public void IfElse_WithElseIfCorrectFormat001_IsCorrect()
        {
            func.Function = "if (true) { 1 } else if (true) { 2 } else { 3 }";
            // true 1 if true 2 elseif 3 else 5 +
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [TestMethod]
        public void IfElse_WithElseIfCorrectFormat002_IsCorrect()
        {
            func.Function = "5 + if (true) { 1 } else if (true) { 2 } else { 3 }";
            // true 1 if true 2 elseif 3 else 5 +
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [TestMethod]
        public void IfElse_WithElseIfCorrectFormat003_IsCorrect()
        {
            func.Function = "if (false) { 1 } else if (true) { 2 } else { 3 }";
            Assert.AreEqual(2, func.EvaluateNumeric());
        }

        [TestMethod]
        public void IfElse_WithElseIfCorrectFormat004_IsCorrect()
        {
            func.Function = "5 + if (false) { 1 } else if (true) { 2 } else { 3 }";
            // true 1 if true 2 elseif 3 else 5 +
            Assert.AreEqual(7, func.EvaluateNumeric());
        }

        [TestMethod]
        public void IfElse_WithElseIfCorrectFormat005_IsCorrect()
        {
            func.Function = "if (false) { 1 } else if (false) { 2 } else { 3 }";
            Assert.AreEqual(3, func.EvaluateNumeric());
        }

        [TestMethod]
        public void IfElse_WithElseIfCorrectFormat006_IsCorrect()
        {
            func.Function = "5 + if (false) { 1 } else if (false) { 2 } else { 3 }";
            // true 1 if true 2 elseif 3 else 5 +
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [TestMethod]
        public void IfElse_NestedCorrectFormat001_IsCorrect()
        {
            func.Function = "if (true) { if (true) { 1 } else { 2 } } else { 3 }";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [TestMethod]
        public void IfElse_NestedCorrectFormat002_IsCorrect()
        {
            func.Function = "5 + if (true) { if (false) { 1 } else { 2 } } else { 3 }";
            // 5 true  +
            Assert.AreEqual(7, func.EvaluateNumeric());
        }

        [TestMethod]
        public void IfElse_NestedCorrectFormat003_IsCorrect()
        {
            func.Function = "5 + if (true) { if (true) { 1 } else { 2 } } else { 3 }";
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [TestMethod]
        public void IfElse_NestedBoolean001_IsCorrect()
        {
            func.Function = "5 + if (8 > 1) { 1 } else { 2 }";
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [TestMethod]
        public void IfElse_NestedBoolean002_IsCorrect()
        {
            func.Function = "5 + if (8 > 1 || 8 < 10) { 1 } else { 2 }";
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [TestMethod]
        public void IfElse_NestedBooleanWithVariable001_IsCorrect()
        {
            func.Function = "5 + if (a > 1) { 1 } else { 2 }";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [TestMethod]
        public void IfElse_NestedBooleanWithVariable002_IsCorrect()
        {
            func.Function = "5 + if (a > 1 || a < 10) { 1 } else { 2 }";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [TestMethod]
        public void IfElse_NestedMathmaticalWithVariable001_IsCorrect()
        {
            func.Function = "5 + if (a > 1) { a + 1 } else { 2 }";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [TestMethod]
        public void IfElse_NestedMathmaticalWithVariable002_IsCorrect()
        {
            func.Function = "5 + if (a > 1 || a < 10) { a + 1 } else { a + 2 }";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [TestMethod]
        public void Multiline_ValidExpression001_IsCorrect()
        {
            func.Function =
                "5 +" +
                Environment.NewLine +
                "if (a > 1 || a < 10)" + 
                Environment.NewLine + 
                "{ a + 1 }" + 
                Environment.NewLine +
                "else" +
                Environment.NewLine +
                "{ a + 2 }";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }



        //[TestMethod]
        //public void IfElse_ConvertToPostFix002_IsCorrect()
        //{
        //    func.Function = "if (true) { 1 } else if (true) { 2 } else { 3 }";
        //    Assert.AreEqual("true 1 2 if", func.PostFix);
        //}


    }

}

#region comilation tests

//namespace PETNet.Olympus.Tests.ExpressionTesting.Compiled.Functionality
//{
//    [TestClass]
//    public class OtherFunctionality
//    {
//        ExpressionAppDomain ead;
//        Expression func;

//        [TestInitialize]
//        public void init()
//        {
//            ead = new ExpressionAppDomain();
//            this.func = ead.NewExpression();
//            this.func.Compile = true;
//        }

//        [TestCleanup]
//        public void clear()
//        {
//            func.Clear();
//            ead.Unload();
//        }

//        [TestMethod]
//        public void ClearVariables()
//        {
//            func.Function = "a+b";
//            func.AddSetVariable("a", 2);
//            func.AddSetVariable("b", 3);
//            func.ClearVariables();
//            Assert.AreEqual(true, double.IsNaN(func.GetVariableValue("a")));
//            Assert.AreEqual(true, double.IsNaN(func.GetVariableValue("b")));
//        }

//        [TestMethod]
//        public void Variable001()
//        {
//            func.Function = "a+b";
//            func.AddSetVariable("a", 2);
//            func.AddSetVariable("b", 3);
//            Assert.AreEqual(2, func.GetVariableValue("a"));
//            Assert.AreEqual(3, func.GetVariableValue("b"));
//            func.AddSetVariable("a", 3);
//            func.AddSetVariable("b", 4);
//            Assert.AreEqual(3, func.GetVariableValue("a"));
//            Assert.AreEqual(4, func.GetVariableValue("b"));
//        }

//        [TestMethod]
//        public void Variable002()
//        {
//            func.Function = "a+b";
//            Assert.AreEqual(true, double.IsNaN(func.GetVariableValue("a")));
//            Assert.AreEqual(true, double.IsNaN(func.GetVariableValue("b")));
//        }

//        [TestMethod]
//        public void ToString001()
//        {
//            func.Function = "a + b";
//            Assert.AreEqual("a + b", func.ToString());
//        }

//        [TestMethod]
//        public void ToString002()
//        {
//            func.Function = "a + b";
//            func.AddSetVariable("a", 2);
//            func.AddSetVariable("b", 3);
//            Assert.AreEqual("a + b; a=2, b=3", func.ToString());
//        }

//        [TestMethod]
//        public void PostFix001()
//        {
//            func.Function = "a + b";
//            Assert.AreEqual("a b +", func.PostFix);
//        }

//        [TestMethod]
//        public void PostFix002()
//        {
//            func.Function = "a+b";
//            Assert.AreEqual("a b +", func.PostFix);
//        }

//        [TestMethod]
//        public void InFix001()
//        {
//            func.Function = "a+b";
//            Assert.AreEqual("a + b", func.InFix);
//        }

//        [TestMethod]
//        public void InFix002()
//        {
//            func.Function = "a+ b";
//            Assert.AreEqual("a + b", func.InFix);
//        }

//        [TestMethod]
//        public void InFix003()
//        {
//            func.Function = "a +b";
//            Assert.AreEqual("a + b", func.InFix);
//        }

//        [TestMethod]
//        public void InFix004()
//        {
//            func.Function = "a + b";
//            Assert.AreEqual("a + b", func.InFix);
//        }

//        [TestMethod]
//        public void InFix005()
//        {
//            func.Function = "a+b-2*3/66*sign(-3)+abs(-16)^3";
//            Assert.AreEqual("a + b - 2 * 3 / 66 * sign ( -3 ) + abs ( -16 ) ^ 3", func.InFix);
//        }

//        [TestMethod]
//        public void PostFix003()
//        {
//            func.Function = "a+b - 2";
//            func.AddSetVariable("a", 2);
//            func.AddSetVariable("b", 3);
//            Assert.AreEqual("a b + 2 -", func.PostFix);
//        }

//        [TestMethod]
//        public void Function001()
//        {
//            func.Function = "a+b - 2";
//            Assert.AreEqual("a+b - 2", func.Function);
//        }

//        [TestMethod]
//        public void Function002()
//        {
//            func.Function = "a +b - 2";
//            func.AddSetVariable("a", 2);
//            func.AddSetVariable("b", 3);
//            Assert.AreEqual("a +b - 2", func.Function);
//        }

//        [TestMethod]
//        public void Function003()
//        {
//            func.Function = "a + b - 2";
//            func.AddSetVariable("a", 2);
//            func.AddSetVariable("b", 3);
//            Assert.AreEqual("a + b - 2", func.Function);
//        }

//        //[TestMethod]
//        //public void CopyConstructor001()
//        //{
//        //    func.Function = "a + b - 2";
//        //    func.AddSetVariable("a", 2);
//        //    func.AddSetVariable("b", 3);
//        //    Expression func2 = new Expression(func);
//        //    Assert.AreEqual("a + b - 2", func2.Function);
//        //    Assert.AreEqual(3, func2.EvaluateD());
//        //}

//        //[TestMethod]
//        //public void CopyConstructor002()
//        //{
//        //    func.Function = "4 < 3";
//        //    Expression func2 = new Expression(func);
//        //    Assert.AreEqual(false, func2.EvaluateB());
//        //}

//        //[TestMethod]
//        //public void CopyConstructor003()
//        //{
//        //    func.Function = "false || a";
//        //    func.AddSetVariable("a", true);
//        //    Expression func2 = new Expression(func);
//        //    Assert.AreEqual(true, func2.EvaluateB());
//        //}
//    }
//}

//namespace PETNet.Olympus.Tests.ExpressionTesting.Compiled.Double
//{
//    [TestClass]
//    public class ParenthesisErrors
//    {
//        ExpressionAppDomain ead;
//        Expression func;

//        [TestInitialize]
//        public void init()
//        {
//            ead = new ExpressionAppDomain();
//            this.func = ead.NewExpression();
//            this.func.Compile = true;
//        }

//        [TestCleanup]
//        public void clear()
//        {
//            func.Clear();
//            ead.Unload();
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Parenthesis001()
//        { func.Function = "(1+2"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Parenthesis002()
//        { func.Function = "1+2)"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Parenthesis003()
//        { func.Function = "((1+2)"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Parenthesis004()
//        { func.Function = ")(1+2)"; }
//    }

//    [TestClass]
//    public class OperatorTests
//    {
//        ExpressionAppDomain ead;
//        Expression func;

//        [TestInitialize]
//        public void init()
//        {
//            ead = new ExpressionAppDomain();
//            this.func = ead.NewExpression();
//            this.func.Compile = true;
//        }

//        [TestCleanup]
//        public void clear()
//        { 
//            func.Clear();
//            ead.Unload();
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Addition001()
//        { func.Function = "1+"; }

//        [TestMethod]
//        public void Addition002()
//        {
//            func.Function = "+2";
//            Assert.AreEqual(2, func.EvaluateD(), "Expected 2");
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Subtraction001()
//        { func.Function = "332-"; }

//        [TestMethod]
//        public void Subtraction002()
//        {
//            func.Function = "-23";
//            Assert.AreEqual(-23, func.EvaluateD(), "Expected -23");
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Power001()
//        { func.Function = "2^"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Power002()
//        { func.Function = "^2"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Mult001()
//        { func.Function = "*2"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Mult002()
//        { func.Function = "3*"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Division001()
//        { func.Function = "/73"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Division002()
//        { func.Function = "/9832"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Negation001()
//        { func.Function = "9832 neg"; }

//        [TestMethod]
//        public void Negation002()
//        {
//            func.Function = "neg 9832";
//            Assert.AreEqual(-9832, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Sign001()
//        {
//            func.Function = "sign(-9832)";
//            Assert.AreEqual(-1, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Sign002()
//        {
//            func.Function = "sign(2341)";
//            Assert.AreEqual(1, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Sign003()
//        {
//            func.Function = "sign(0)";
//            Assert.AreEqual(1, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Sign004()
//        {
//            func.Function = "sign -12";
//            Assert.AreEqual(-1, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Sign005()
//        {
//            func.Function = "sign 12";
//            Assert.AreEqual(1, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Sign006()
//        {
//            func.Function = "sign 0";
//            Assert.AreEqual(1, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Abs001()
//        {
//            func.Function = "abs(-165)";
//            Assert.AreEqual(165, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Abs002()
//        {
//            func.Function = "abs(8964)";
//            Assert.AreEqual(8964, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Abs003()
//        {
//            func.Function = "abs(0)";
//            Assert.AreEqual(0, func.EvaluateD());
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Abs004()
//        { func.Function = "abs -165"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Abs005()
//        { func.Function = "abs 8964 "; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Abs006()
//        { func.Function = "abs 0"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Abs007()
//        { func.Function = "abs (10"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Abs008()
//        { func.Function = "abs 20)"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void MulitpleOperators001()
//        { func.Function = "1+(2*)"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void MulitpleOperators002()
//        { func.Function = "1/2*"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void MulitpleOperators003()
//        { func.Function = "+1/"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void MulitpleOperators004()
//        { func.Function = "1-2-3-3-2-"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void MulitpleOperators005()
//        { func.Function = "1-(2+3)2"; }
//    }

//    [TestClass]
//    public class EvaluationWithScientificNotation
//    {
//        ExpressionAppDomain ead;
//        Expression func;

//        [TestInitialize]
//        public void init()
//        {
//            ead = new ExpressionAppDomain();
//            this.func = ead.NewExpression();
//            this.func.Compile = true;
//        }

//        [TestCleanup]
//        public void clear()
//        {
//            func.Clear();
//            ead.Unload();
//        }

//        [TestMethod]
//        public void Expression001()
//        {
//            func.Function = "1 - 2 - 3 - 4 - 5e-1 - 7";
//            Assert.AreEqual(-15.5, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Expression002()
//        {
//            func.Function = "1 - 2 - 3E - 1 - 5e - 1 - 7";
//            Assert.AreEqual(-8.8, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Expression003()
//        {
//            func.Function = "1 + 2 - 3e + 1 - 5e - 1 - 7";
//            Assert.AreEqual(-34.5, func.EvaluateD());
//        }

//        //[TestMethod]
//        //public void Expression004()
//        //{
//        //    func.Function = "3e - 4 - 5e - 6";
//        //    Assert.AreEqual(0.000295, func.EvaluateD());
//        //}

//        [TestMethod]
//        public void Expression005()
//        {
//            func.Function = "3 - - 4 - 5e - 1";
//            Assert.AreEqual(6.5, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Expression006()
//        {
//            func.Function = "( 3 + 4 ) * - 4 - 5e-2";
//            Assert.AreEqual(-28.05, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Expression007()
//        {
//            func.Function = "( 3 + 4 ) * - 403 - 5e-2";
//            Assert.AreEqual(-2821.05, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Expression008()
//        {
//            func.Function = "403 - - 4 + -5";
//            Assert.AreEqual(402, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Expression009()
//        {
//            func.Function = "( 3 + 4 ) * - 403 - - 5e-1";
//            Assert.AreEqual(-2820.5, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Expression010()
//        {
//            func.Function = "- 403 + - 3 + - 4";
//            Assert.AreEqual(-410, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Expression011()
//        {
//            func.Function = "- 403 + - 3e + 2 + - 4";
//            Assert.AreEqual(-707, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Expression012()
//        {
//            func.Function = "- 403 + - 3e-1 + - 4e+2";
//            Assert.AreEqual(-803.3, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Expression013()
//        {
//            func.Function = "- 403 + - 3e+2 + - 4e+4";
//            Assert.AreEqual(-40703, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Expression014()
//        {
//            func.Function = "- 403e-2 + - 3e-6 + - 4e-8";
//            Assert.AreEqual(-4.03000304, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Expression015()
//        {
//            func.Function = "- 403e+2 + - 3e-2 + - 4e+2";
//            Assert.AreEqual(-40700.03, func.EvaluateD());
//        }

//        [TestMethod]
//        public void Expression016()
//        {
//            func.Function = "( - 3 + 4 ) * - 403 - - 5e-1";
//            Assert.AreEqual(-402.5, func.EvaluateD());
//        }


//    }

//    [TestClass]
//    public class MathmaticalErrors
//    {
//        ExpressionAppDomain ead;
//        Expression func;

//        [TestInitialize]
//        public void init()
//        {
//            ead = new ExpressionAppDomain();
//            this.func = ead.NewExpression();
//            this.func.Compile = true;
//        }

//        [TestCleanup]
//        public void clear()
//        {
//            func.Clear();
//            ead.Unload();
//        }

//        [TestMethod]
//        public void DivideByZero002()
//        {
//            func.Function = "2/(1-1)";
//            Assert.AreEqual(true, double.IsNaN(func.EvaluateD()));
//        }
//    }

//    [TestClass]
//    public class EvaluationWithVariables
//    {
//        ExpressionAppDomain ead;
//        Expression func;

//        [TestInitialize]
//        public void init()
//        {
//            ead = new ExpressionAppDomain();
//            this.func = ead.NewExpression();
//            this.func.Compile = true;
//        }

//        [TestCleanup]
//        public void clear()
//        {
//            func.Clear();
//            ead.Unload();
//        }

//        [TestMethod]
//        public void EvaluationWithVariables001()
//        {
//            func.Function = "a^3";
//            func.AddSetVariable("a", 2);
//            Assert.AreEqual(8, func.EvaluateD());
//        }

//        [TestMethod]
//        public void EvaluationWithVariables002()
//        {
//            func.Function = "a^b";
//            func.AddSetVariable("a", 2);
//            func.AddSetVariable("b", 3);
//            Assert.AreEqual(8, func.EvaluateD());
//        }

//        [TestMethod]
//        public void EvaluationWithVariables003()
//        {
//            func.Function = "a^2";
//            func.AddSetVariable("a", 2);
//            func.AddSetVariable("a", 3);
//            Assert.AreEqual(9, func.EvaluateD());
//        }

//        [TestMethod]
//        public void EvaluationWithVariables004()
//        {
//            func.Function = "a^b";
//            func.AddSetVariable("a", 2);
//            func.AddSetVariable("a", 3);
//            func.AddSetVariable("b", 2);
//            func.AddSetVariable("b", 3);
//            Assert.AreEqual(27, func.EvaluateD());
//        }

//        [TestMethod]
//        public void EvaluationWithVariables005()
//        {
//            func.Function = "(a^b)/2";
//            func.AddSetVariable("a", 4);
//            func.AddSetVariable("b", 2);
//            Assert.AreEqual(8, func.EvaluateD());
//        }

//    }

//}

//namespace PETNet.Olympus.Tests.ExpressionTesting.Compiled.Boolean
//{
//    [TestClass]
//    public class BooleanEvaluation
//    {
//        ExpressionAppDomain ead;
//        Expression func;

//        [TestInitialize]
//        public void init()
//        {
//            ead = new ExpressionAppDomain();
//            this.func = ead.NewExpression();
//            this.func.Compile = true;
//        }

//        [TestCleanup]
//        public void clear()
//        {
//            func.Clear();
//            ead.Unload();
//        }

//        [TestMethod]
//        public void BooleanEvaluation001()
//        {
//            func.Function = "true || true";
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void BooleanEvaluation002()
//        {

//            func.Function = "true || false";
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void BooleanEvaluation003()
//        {
//            func.Function = "false || true";
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void BooleanEvaluation004()
//        {
//            func.Function = "false || false";
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//        [TestMethod]
//        public void BooleanEvaluation005()
//        {
//            func.Function = "true && true";
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void BooleanEvaluation006()
//        {
//            func.Function = "true && false";
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//        [TestMethod]
//        public void BooleanEvaluation007()
//        {
//            func.Function = "false && true";
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//        [TestMethod]
//        public void BooleanEvaluation008()
//        {
//            func.Function = "false && false";
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//        [TestMethod]
//        public void BooleanEvaluation009()
//        {
//            func.Function = "true || false && false || false";
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void BooleanEvaluation010()
//        {
//            func.Function = "(true || false) && (false || false)";
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//        [TestMethod]
//        public void BooleanEvaluation011()
//        {
//            func.Function = "(true || false) && false || false";
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//        [TestMethod]
//        public void BooleanEvaluation012()
//        {
//            func.Function = "(true || false) && true";
//            Assert.AreEqual(true, func.EvaluateB());
//        }
//    }

//    [TestClass]
//    public class NumericalBooleanEvaluation
//    {
//        ExpressionAppDomain ead;
//        Expression func;

//        [TestInitialize]
//        public void init()
//        {
//            ead = new ExpressionAppDomain();
//            this.func = ead.NewExpression();
//            this.func.Compile = true;
//        }

//        [TestCleanup]
//        public void clear()
//        {
//            func.Clear();
//            ead.Unload();
//        }

//        [TestMethod]
//        public void NumericalBooleanEvaluation001()
//        {
//            func.Function = "4 >= 2";
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void NumericalBooleanEvaluation002()
//        {
//            func.Function = "4 >= 4";
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void NumericalBooleanEvaluation003()
//        {
//            func.Function = "4 >= 6";
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//        [TestMethod]
//        public void NumericalBooleanEvaluation004()
//        {
//            func.Function = "4 <= 6";
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void NumericalBooleanEvaluation005()
//        {
//            func.Function = "4 <= 4";
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void NumericalBooleanEvaluation006()
//        {
//            func.Function = "4 <= 2";
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//        [TestMethod]
//        public void NumericalBooleanEvaluation007()
//        {
//            func.Function = "4 > 2";
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void NumericalBooleanEvaluation008()
//        {
//            func.Function = "4 > 5.2";
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//        [TestMethod]
//        public void NumericalBooleanEvaluation009()
//        {
//            func.Function = "4 == 5.2";
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//        [TestMethod]
//        public void NumericalBooleanEvaluation010()
//        {
//            func.Function = "4 == 4";
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void NumericalBooleanEvaluation011()
//        {
//            func.Function = "4 < 5.2";
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void NumericalBooleanEvaluation012()
//        {
//            func.Function = "4 < 3";
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//        [TestMethod]
//        public void NumericalBooleanEvaluation013()
//        {
//            func.Function = "4 > abs(neg 5.2)";
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//        [TestMethod]
//        public void NumericalBooleanEvaluation014()
//        {
//            func.Function = "4 > abs(neg 3.2)";
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void NumericalBooleanEvaluation015()
//        {
//            func.Function = "4 > neg(abs(5.2))";
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void NumericalBooleanEvaluation016()
//        {
//            func.Function = "4 != 5.2";
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void NumericalBooleanEvaluation017()
//        {
//            func.Function = "4 != 4";
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//    }

//    [TestClass]
//    public class OperatorError
//    {
//        ExpressionAppDomain ead;
//        Expression func;

//        [TestInitialize]
//        public void init()
//        {
//            ead = new ExpressionAppDomain();
//            this.func = ead.NewExpression();
//            this.func.Compile = true;
//        }

//        [TestCleanup]
//        public void clear()
//        {
//            func.Clear();
//            ead.Unload();
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Or001()
//        { func.Function = "true || "; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Or002()
//        { func.Function = "|| false"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void And001()
//        { func.Function = " && true"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void And002()
//        { func.Function = "true && "; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void MultipleBooleanOperators001()
//        { func.Function = "true ||  && false || false"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void MultipleBooleanOperators002()
//        { func.Function = "(true || false) && ( || false)"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void MultipleOperators003()
//        { func.Function = "(true || false) && false || "; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void MultipleOperators004()
//        { func.Function = "(true || ) && true"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void GreaterEqual001()
//        { func.Function = "4 >="; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void GreaterEqual002()
//        { func.Function = ">= 4"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void LessEqual001()
//        { func.Function = "<= 6"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void LessEqual002()
//        { func.Function = "4 <="; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Greater001()
//        { func.Function = "> 2"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Greater002()
//        { func.Function = "4 >"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Equal001()
//        { func.Function = "== 5.2"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Equal002()
//        { func.Function = "4 =="; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Less001()
//        { func.Function = "< 5.2"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void Less002()
//        { func.Function = "4 <"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void MulitpleOperators001()
//        { func.Function = "4 > abs(neg )"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void MulitpleOperators002()
//        { func.Function = " > abs(neg 3.2)"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void MulitpleOperators003()
//        { func.Function = "4 neg(abs(5.2))"; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void NotEqual001()
//        { func.Function = "4 !="; }

//        [TestMethod]
//        [ExpectedException(typeof(ExpressionException))]
//        public void NotEqual002()
//        { func.Function = "!= 4"; }
//    }

//    [TestClass]
//    public class EvaluationWithVariables
//    {
//        ExpressionAppDomain ead;
//        Expression func;

//        [TestInitialize]
//        public void init()
//        {
//            ead = new ExpressionAppDomain();
//            this.func = ead.NewExpression();
//            this.func.Compile = true;
//        }

//        [TestCleanup]
//        public void clear()
//        {
//            func.Clear();
//            ead.Unload();
//        }

//        [TestMethod]
//        public void EvaluationWithVariables002()
//        {
//            func.Function = "a == b";
//            func.AddSetVariable("a", 4);
//            func.AddSetVariable("b", 4);
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void EvaluationWithVariables003()
//        {
//            func.Function = "a != b";
//            func.AddSetVariable("a", 4);
//            func.AddSetVariable("b", 4);
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//        [TestMethod]
//        public void EvaluationWithVariables004()
//        {
//            func.Function = "a && b";
//            func.AddSetVariable("a", true);
//            func.AddSetVariable("b", true);
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void EvaluationWithVariables005()
//        {
//            func.Function = "a && b";
//            func.AddSetVariable("a", true);
//            func.AddSetVariable("b", false);
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//        [TestMethod]
//        public void EvaluationWithVariables006()
//        {
//            func.Function = "a && b";
//            func.AddSetVariable("a", false);
//            func.AddSetVariable("b", false);
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//        [TestMethod]
//        public void EvaluationWithVariables007()
//        {
//            func.Function = "a && b";
//            func.AddSetVariable("a", true);
//            func.AddSetVariable("b", false);
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//        [TestMethod]
//        public void EvaluationWithVariables008()
//        {
//            func.Function = "a || b";
//            func.AddSetVariable("a", true);
//            func.AddSetVariable("b", true);
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void EvaluationWithVariables009()
//        {
//            func.Function = "a || b";
//            func.AddSetVariable("a", true);
//            func.AddSetVariable("b", false);
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void EvaluationWithVariables010()
//        {
//            func.Function = "a || b";
//            func.AddSetVariable("a", false);
//            func.AddSetVariable("b", false);
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//        [TestMethod]
//        public void EvaluationWithVariables011()
//        {
//            func.Function = "a || b && c || d";
//            func.AddSetVariable("a", true);
//            func.AddSetVariable("b", false);
//            func.AddSetVariable("c", true);
//            func.AddSetVariable("d", false);
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void EvaluationWithVariables012()
//        {
//            func.Function = "a || b && c || d";
//            func.AddSetVariable("a", true);
//            func.AddSetVariable("b", false);
//            func.AddSetVariable("c", false);
//            func.AddSetVariable("d", false);
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void EvaluationWithVariables014()
//        {
//            func.Function = "(a || b) && (c || d)";
//            func.AddSetVariable("a", true);
//            func.AddSetVariable("b", false);
//            func.AddSetVariable("c", true);
//            func.AddSetVariable("d", false);
//            Assert.AreEqual(true, func.EvaluateB());
//        }

//        [TestMethod]
//        public void EvaluationWithVariables015()
//        {
//            func.Function = "(a || b) && (c || d)";
//            func.AddSetVariable("a", true);
//            func.AddSetVariable("b", false);
//            func.AddSetVariable("c", false);
//            func.AddSetVariable("d", false);
//            Assert.AreEqual(false, func.EvaluateB());
//        }

//    }

//}

#endregion 

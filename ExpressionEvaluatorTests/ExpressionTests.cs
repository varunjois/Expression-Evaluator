// ReSharper disable InconsistentNaming
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Vanderbilt.Biostatistics.Wfccm2;
using NUnit.Framework;

namespace PETNet.Olympus.Tests.ExpressionTesting.Interpreted.Functionality
{
    /// <summary>
    /// Summary description for ExpressionTests
    /// </summary>
    [TestFixture]
    public class ExpressionTest
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void ClearVariables_Call_VariableAreCleared()
        {
            func.Function = "a+b";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            func.ClearVariables();
            Assert.AreEqual(true, double.IsNaN(func.GetVariableValue("a")));
            Assert.AreEqual(true, double.IsNaN(func.GetVariableValue("b")));
        }

        [Test]
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

        [Test]
        public void Variable002()
        {
            func.Function = "a+b";
            Assert.AreEqual(true, double.IsNaN(func.GetVariableValue("a")));
            Assert.AreEqual(true, double.IsNaN(func.GetVariableValue("b")));
        }

        [Test]
        public void ToString001()
        {
            func.Function = "a + b";
            Assert.AreEqual("a + b", func.ToString());
        }

        [Test]
        public void ToString002()
        {
            func.Function = "a + b";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual("a + b; a=2, b=3", func.ToString());
        }

        [Test]
        public void PostFix001()
        {
            func.Function = "a + b";
            Assert.AreEqual("a b +", func.PostFix);
        }

        [Test]
        public void PostFix002()
        {
            func.Function = "a+b";
            Assert.AreEqual("a b +", func.PostFix);
        }

        [Test]
        public void InFix001()
        {
            func.Function = "a+b";
            Assert.AreEqual("a + b", func.InFix);
        }

        [Test]
        public void InFix002()
        {
            func.Function = "a+ b";
            Assert.AreEqual("a + b", func.InFix);
        }

        [Test]
        public void InFix003()
        {
            func.Function = "a +b";
            Assert.AreEqual("a + b", func.InFix);
        }

        [Test]
        public void InFix004()
        {
            func.Function = "a + b";
            Assert.AreEqual("a + b", func.InFix);
        }

        [Test]
        public void InFix005()
        {
            func.Function = "a+b-2*3/66*sign(-3)+abs(-16)^3";
            Assert.AreEqual("a + b - 2 * 3 / 66 * sign ( -3 ) + abs ( -16 ) ^ 3", func.InFix);
        }

        [Test]
        public void PostFix003()
        {
            func.Function = "a+b - 2";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual("a b + 2 -", func.PostFix);
        }

        [Test]
        public void Function001()
        {
            func.Function = "a+b - 2";
            Assert.AreEqual("a+b - 2", func.Function);
        }

        [Test]
        public void Function002()
        {
            func.Function = "a +b - 2";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual("a +b - 2", func.Function);
        }

        [Test]
        public void Function003()
        {
            func.Function = "a + b - 2";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual("a + b - 2", func.Function);
        }

        [Test]
        public void DivideByZero_EvaluateFunction001_IsNotANumber()
        {
            func.Function = "2/0";
            Assert.AreEqual(true, double.IsNaN(func.EvaluateNumeric()));
        }

        [Test]
        public void DivideByZero_EvaluateFunction002_IsNotANumber()
        {
            func.Function = "2/(1-1)";
            Assert.AreEqual(true, double.IsNaN(func.EvaluateNumeric()));
        }

        [Test]
        public void Evaulate_CheckFloatingPointErrors_IsCorrect()
        {
            func.Function = "99.999999999999/100";
            Assert.AreEqual(0.99999999999999, func.EvaluateNumeric());
        }

        #region Expression Errors

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "abs not formatted correctly. Open and close parenthesis required.", MatchType = MessageMatch.Contains)]
        public void Abs_BadExpression001_ExpressionException()
        {
            func.Function = "abs -165";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "abs not formatted correctly. Open and close parenthesis required.", MatchType = MessageMatch.Contains)]
        public void Abs_NoParenthisis001_ExpressionException()
        {
            func.Function = "abs 8964 ";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "abs not formatted correctly. Open and close parenthesis required.", MatchType = MessageMatch.Contains)]
        public void Abs_NoParenthisis002_ExpressionException()
        {
            func.Function = "abs 0";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "abs not formatted correctly. Open and close parenthesis required.", MatchType = MessageMatch.Contains)]
        public void Abs_NoClosingParenthisis_ExpressionException()
        {
            func.Function = "abs (10";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "abs not formatted correctly. Open and close parenthesis required.", MatchType = MessageMatch.Contains)]
        public void Abs_NoOpeningParenthisis_ExpressionException()
        {
            func.Function = "abs 20)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void Addition_BadExpression001_ExpressionException()
        {
            func.Function = "1+";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void And_BadExpression001_ExpressionException()
        {
            func.Function = " && true";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void And_BadExpression002_ExpressionException()
        {
            func.Function = "true && ";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void Division_BadExpression001_ExpressionException()
        {
            func.Function = "/73";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void Division_BadExpression002_ExpressionException()
        {
            func.Function = "/9832";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void Equal_BadExpression001_ExpressionException()
        {
            func.Function = "== 5.2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void Equal_BadExpression002_ExpressionException()
        {
            func.Function = "4 ==";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void GreaterEqual_BadExpression001_ExpressionException()
        {
            func.Function = "4 >=";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void GreaterEqual_BadExpression002_ExpressionException()
        {
            func.Function = ">= 4";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void Greater_BadExpression001_ExpressionException()
        {
            func.Function = "> 2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void Greater_BadExpression002_ExpressionException()
        {
            func.Function = "4 >";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void Less_BadExpression001_ExpressionException()
        {
            func.Function = "< 5.2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void Less_BadExpression002_ExpressionException()
        {
            func.Function = "4 <";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void LessEqual_BadExpression001_ExpressionException()
        {
            func.Function = "<= 6";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void LessEqual_BadExpression002_ExpressionException()
        {
            func.Function = "4 <=";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void Multiplication_BadExpression001_ExpressionException()
        { func.Function = "*2"; }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void Multiplication_BadExpression002_ExpressionException()
        { func.Function = "3*"; }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MultipleBooleanOperators_BadExpression001_ExpressionException()
        {
            func.Function = "true ||  && false || false";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MultipleBooleanOperators_BadExpression002_ExpressionException()
        {
            func.Function = "(true || false) && ( || false)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MulitpleOperators_BadExpression001_ExpressionException()
        { func.Function = "1+(2*)"; }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MulitpleOperators_BadExpression002_ExpressionException()
        { func.Function = "1/2*"; }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MultipleOperators_BadExpression003_ExpressionException()
        {
            func.Function = "(true || false) && false || ";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MultipleOperators_BadExpression004_ExpressionException()
        {
            func.Function = "(true || ) && true";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Expression formatted incorrecty", MatchType = MessageMatch.Contains)]
        public void MulitpleOperators_BadExpression005_ExpressionException()
        { func.Function = "1-(2+3)2"; }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MulitpleOperators_BadExrpession006_ExpressionException()
        { func.Function = "+1/"; }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MulitpleOperators_BadExpression007_ExpressionException()
        { func.Function = "1-2-3-3-2-"; }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MulitpleOperators_BadExpression008_ExpressionException()
        {
            func.Function = "4 > abs(neg )";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MulitpleOperators_BadExpression009_ExpressionException()
        {
            func.Function = " > abs(neg 3.2)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MulitpleOperators_BadExpression010_ExpressionException()
        {
            func.Function = "4 neg(abs(5.2))";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void NotEqual_BadExpression001_ExpressionException()
        {
            func.Function = "4 !=";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void NotEqual_BadExpression002_ExpressionException()
        {
            func.Function = "!= 4";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void Negation_BadExpression001_ExpressionException()
        { func.Function = "9832 neg"; }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void Or_BadExpression001_ExpressionException()
        {
            func.Function = "true || ";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void Or_BadExpression002_ExpressionException()
        {
            func.Function = "|| false";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void Power_BadExpression001_ExpressionException()
        { func.Function = "2^"; }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void Power_BadExpression002_ExpressionException()
        { func.Function = "^2"; }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void Subtraction_BadExpression001_ExpressionException()
        { func.Function = "332-"; }

        #endregion

        #region Grouping Errors

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Close missing", MatchType = MessageMatch.Contains)]
        public void Braces_MissingClose001_ExpressionException()
        {
            func.Function = "((1+2)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Close missing", MatchType = MessageMatch.Contains)]
        public void Braces_MissingClose002_ExpressionException()
        {
            func.Function = "(1+2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open missing", MatchType = MessageMatch.Contains)]
        public void Braces_MissingOpen001_ExpressionException()
        {
            func.Function = "1+2)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open missing", MatchType = MessageMatch.Contains)]
        public void Braces_MissingOpen002_ExpressionException()
        {
            func.Function = ")(1+2)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Close missing", MatchType = MessageMatch.Contains)]
        public void Parenthesis_MissingClose001_ExpressionException()
        {
            func.Function = "((1+2)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Close missing", MatchType = MessageMatch.Contains)]
        public void Parenthesis_MissingClose002_ExpressionException()
        {
            func.Function = "(1+2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open missing", MatchType = MessageMatch.Contains)]
        public void Parenthesis_MissingOpen001_ExpressionException()
        {
            func.Function = "1+2)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open missing", MatchType = MessageMatch.Contains)]
        public void Parenthesis_MissingOpen002_ExpressionException()
        {
            func.Function = ")(1+2)";
        }

        #endregion

        #region Operators

        [Test]
        public void Abs001()
        {
            func.Function = "abs(-165)";
            Assert.AreEqual(165, func.EvaluateNumeric());
        }

        [Test]
        public void Abs002()
        {
            func.Function = "abs(8964)";
            Assert.AreEqual(8964, func.EvaluateNumeric());
        }

        [Test]
        public void Abs003()
        {
            func.Function = "abs(0)";
            Assert.AreEqual(0, func.EvaluateNumeric());
        }

        [Test]
        public void Addition002()
        {
            func.Function = "+2";
            Assert.AreEqual(2, func.EvaluateNumeric(), "Expected 2");
        }

        [Test]
        public void Ln_001()
        {
            func.Function = "ln(5)";
            Assert.AreEqual(1.6094379124341, func.EvaluateNumeric());
        }

        [Test]
        public void Ln_002()
        {
            func.Function = "ln(5) + 1";
            Assert.AreEqual(2.6094379124341, func.EvaluateNumeric());
        }

        [Test]
        public void Ln_003()
        {
            func.Function = "ln(5) * 2";
            Assert.AreEqual(3.2188758248682, func.EvaluateNumeric());
        }

        [Test]
        public void Negation002()
        {
            func.Function = "neg(9832)";
            Assert.AreEqual(-9832, func.EvaluateNumeric());
        }

        [Test]
        public void Sign001()
        {
            func.Function = "sign(-9832)";
            Assert.AreEqual(-1, func.EvaluateNumeric());
        }

        [Test]
        public void Sign002()
        {
            func.Function = "sign(2341)";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [Test]
        public void Sign003()
        {
            func.Function = "sign(0)";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [Test]
        public void Sign004()
        {
            func.Function = "sign(-12)";
            Assert.AreEqual(-1, func.EvaluateNumeric());
        }

        [Test]
        public void Sign005()
        {
            func.Function = "sign(12)";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [Test]
        public void Sign006()
        {
            func.Function = "sign(0)";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [Test]
        public void Subtraction001()
        {
            func.Function = "-23";
            Assert.AreEqual(-23, func.EvaluateNumeric(), "Expected -23");
        }

        [Test]
        public void Subtraction002()
        {
            func.Function = "-22-23";
            Assert.AreEqual(-45, func.EvaluateNumeric(), "Expected -23");
        }

        [Test]
        public void Or_ValidExpression001_IsCorrect()
        {
            func.Function = "true || true";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void Or_ValidExpression002_IsCorrect()
        {

            func.Function = "true || false";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void Or_ValidExpression003_IsCorrect()
        {
            func.Function = "false || true";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void Or_ValidExpression004_IsCorrect()
        {
            func.Function = "false || false";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void And_ValidExpression001_IsCorrect()
        {
            func.Function = "true && true";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void And_ValidExpression002_IsCorrect()
        {
            func.Function = "true && false";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void And_ValidExpression003_IsCorrect()
        {
            func.Function = "false && true";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void And_ValidExpression004_IsCorrect()
        {
            func.Function = "false && false";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void MixedAndOr_ValidExpression001_IsCorrect()
        {
            func.Function = "true || false && false || false";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void MixedAndOr_ValidExpression002_IsCorrect()
        {
            func.Function = "(true || false) && (false || false)";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void MixedAndOr_ValidExpression003_IsCorrect()
        {
            func.Function = "(true || false) && false || false";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void MixedAndOr_ValidExpression004_IsCorrect()
        {
            func.Function = "(true || false) && true";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_ValidExpression001_IsCorrect()
        {
            func.Function = "4 >= 2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_ValidExpression002_IsCorrect()
        {
            func.Function = "4 >= 4";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_ValidExpression003_IsCorrect()
        {
            func.Function = "4 >= 6";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LessEqual_ValidExpression001_IsCorrect()
        {
            func.Function = "4 <= 6";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LessEqual_ValidExpression002_IsCorrect()
        {
            func.Function = "4 <= 4";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LessEqual_ValidExpression003_IsCorrect()
        {
            func.Function = "4 <= 2";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void Greater_ValidExpression001_IsCorrect()
        {
            func.Function = "4 > 2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void Greater_ValidExpression002_IsCorrect()
        {
            func.Function = "4 > 5.2";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void Equal_ValidExpression001_IsCorrect()
        {
            func.Function = "4 == 5.2";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void Equal_ValidExpression002_IsCorrect()
        {
            func.Function = "4 == 4";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void Less_ValidExpression001_IsCorrect()
        {
            func.Function = "4 < 5.2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void Less_ValidExpression002_IsCorrect()
        {
            func.Function = "4 < 3";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        #endregion

        #region Sciencific Notation

        [Test]
        public void SciNotation_Expression001_IsCorrect()
        {
            func.Function = "1 - 2 - 3 - 4 - 5e-1 - 7";
            Assert.AreEqual(-15.5, func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression002_IsCorrect()
        {
            func.Function = "1 - 2 - 3E - 1 - 5e - 1 - 7";
            Assert.AreEqual(-8.8, func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression003_IsCorrect()
        {
            func.Function = "1 + 2 - 3e + 1 - 5e - 1 - 7";
            Assert.AreEqual(-34.5, func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression004_IsCorrect()
        {
            func.Function = "3e - 4 - 5e - 6";
            Assert.AreEqual(0.000295, func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression005_IsCorrect()
        {
            func.Function = "3 - - 4 - 5e - 1";
            Assert.AreEqual(6.5, func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression006_IsCorrect()
        {
            func.Function = "( 3 + 4 ) * - 4 - 5e-2";
            Assert.AreEqual(-28.05, func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression007_IsCorrect()
        {
            func.Function = "( 3 + 4 ) * - 403 - 5e-2";
            Assert.AreEqual(-2821.05, func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression008_IsCorrect()
        {
            func.Function = "403 - - 4 + -5";
            Assert.AreEqual(402, func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression009_IsCorrect()
        {
            func.Function = "( 3 + 4 ) * - 403 - - 5e-1";
            Assert.AreEqual(-2820.5, func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression010_IsCorrect()
        {
            func.Function = "- 403 + - 3 + - 4";
            Assert.AreEqual(-410, func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression011_IsCorrect()
        {
            func.Function = "- 403 + - 3e + 2 + - 4";
            Assert.AreEqual(-707, func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression012_IsCorrect()
        {
            func.Function = "- 403 + - 3e-1 + - 4e+2";
            Assert.AreEqual(-803.3, func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression013_IsCorrect()
        {
            func.Function = "- 403 + - 3e+2 + - 4e+4";
            Assert.AreEqual(-40703, func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression014_IsCorrect()
        {
            func.Function = "- 403e-2 + - 3e-6 + - 4e-8";
            Assert.AreEqual(-4.03000304, func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression015_IsCorrect()
        {
            func.Function = "- 403e+2 + - 3e-2 + - 4e+2";
            Assert.AreEqual(-40700.03, func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression016_IsCorrect()
        {
            func.Function = "( - 3 + 4 ) * - 403 - - 5e-1";
            Assert.AreEqual(-402.5, func.EvaluateNumeric());
        }

        #endregion

        [Test]
        public void EvaluationWithVariables001()
        {
            func.Function = "a^3";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void EvaluationWithVariables002()
        {
            func.Function = "a^b";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void EvaluationWithVariables003()
        {
            func.Function = "a^2";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("a", 3);
            Assert.AreEqual(9, func.EvaluateNumeric());
        }

        [Test]
        public void EvaluationWithVariables004()
        {
            func.Function = "a^b";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("a", 3);
            func.AddSetVariable("b", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual(27, func.EvaluateNumeric());
        }

        [Test]
        public void EvaluationWithVariables005()
        {
            func.Function = "(a^b)/2";
            func.AddSetVariable("a", 4);
            func.AddSetVariable("b", 2);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void VariableNames_WithNumbers_SetsCorrectly()
        {
            func.Function = "a118+2";
            func.AddSetVariable("a118", 6);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void VariableNames_ContainsSign_SetsCorrectly()
        {
            func.Function = "signature+2";
            func.AddSetVariable("signature", 6);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void VariableNames_ContainsAbs_SetsCorrectly()
        {
            func.Function = "absolute+2";
            func.AddSetVariable("absolute", 6);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void VariableNames_ContainsLn_SetsCorrectly()
        {
            func.Function = "pillname+2";
            func.AddSetVariable("pillname", 6);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void NumericalBooleanEvaluation013()
        {
            func.Function = "4 > abs(neg (5.2))";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NumericalBooleanEvaluation014()
        {
            func.Function = "4 > abs(neg (3.2))";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NumericalBooleanEvaluation015()
        {
            func.Function = "4 > neg(abs(5.2))";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqual_ValidExpression001_IsCorrect()
        {
            func.Function = "4 != 5.2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqual_ValidExpression002_IsCorrect()
        {
            func.Function = "4 != 4";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables001()
        {
            func.Function = "a == 4";
            func.AddSetVariable("a", 4);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables002()
        {
            func.Function = "a == b";
            func.AddSetVariable("a", 4);
            func.AddSetVariable("b", 4);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables003()
        {
            func.Function = "a != b";
            func.AddSetVariable("a", 4);
            func.AddSetVariable("b", 4);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables004()
        {
            func.Function = "a && b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", true);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables005()
        {
            func.Function = "a && b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables006()
        {
            func.Function = "a && b";
            func.AddSetVariable("a", false);
            func.AddSetVariable("b", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables007()
        {
            func.Function = "a && b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables008()
        {
            func.Function = "a || b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", true);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables009()
        {
            func.Function = "a || b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables010()
        {
            func.Function = "a || b";
            func.AddSetVariable("a", false);
            func.AddSetVariable("b", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables011()
        {
            func.Function = "a || b && c || d";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            func.AddSetVariable("c", true);
            func.AddSetVariable("d", false);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables012()
        {
            func.Function = "a || b && c || d";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            func.AddSetVariable("c", false);
            func.AddSetVariable("d", false);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables014()
        {
            func.Function = "(a || b) && (c || d)";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            func.AddSetVariable("c", true);
            func.AddSetVariable("d", false);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables015()
        {
            func.Function = "(a || b) && (c || d)";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            func.AddSetVariable("c", false);
            func.AddSetVariable("d", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void IfElse_IfNoOperator_ExpressionException()
        {
            func.Function = @"if  {  } else { 1 }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void IfElse_IfNoExpression_ExpressionException()
        {
            func.Function = @"if (true)  {  } else { 1 }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void IfElse_ElseNoOperator_ExpressionException()
        {
            func.Function = @"if (true)  { 1  } else { }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "not in a correct format", MatchType = MessageMatch.Contains)]
        public void IfElse_IfStringOperator_ExpressionException()
        {
            func.Function = @"if ( val )  { 1 } else { 1 }";
            func.EvaluateNumeric();
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Conditional Error", MatchType = MessageMatch.Contains)]
        public void IfElse_OutOfOrder001_ExpressionException()
        {
            func.Function = @"else { 2 } if (true) { 1 }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException))]
        public void Grouping_OutOfOrder001_ExpressionException()
        {
            func.Function = @"if (true { ) 2 } else { 1 }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Conditional Error", MatchType = MessageMatch.Contains)]
        public void IfElse_OutOfOrder003_ExpressionException()
        {
            func.Function = @"if (true) { 2 } if else (true) { 1 }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Conditional Error", MatchType = MessageMatch.Contains)]
        public void IfElse_IfElseMismatch001_ExpressionException()
        {
            func.Function = @"if (true) { 2 } else if { 1 }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Conditional Error", MatchType = MessageMatch.Contains)]
        public void IfElse_IfElseMismatch002_ExpressionException()
        {
            func.Function = @"if (true) { 2 } else if (true) { 1 }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Conditional Error", MatchType = MessageMatch.Contains)]
        public void IfElse_ElseWithBoolean001_ExpressionException()
        {
            func.Function = @"if (true) { 2 } else (true) { 1 }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Conditional Error", MatchType = MessageMatch.Contains)]
        public void IfElse_ElseWithBoolean002_ExpressionException()
        {
            func.Function = @"if (true) { 2 } else if (true) { 1 } else (true) { 1 }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Conditional Error", MatchType = MessageMatch.Contains)]
        public void IfElse_NestedElseWithBoolean001_ExpressionException()
        {
            func.Function = @"if (true) { if (true) { 3 } else (true) { 2 } } else { 1 }";
        }

        [Test]
        public void IfElse_CorrectFormat001_IsCorrect()
        {
            func.Function = "if (true) { 1 } else { 2 }";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_CorrectFormat002_IsCorrect()
        {
            func.Function = "if (false) { 1 } else { 2 }";
            Assert.AreEqual(2, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_CorrectFormat003_IsCorrect()
        {
            func.Function = "5 + if (true) { 1 } else { 2 }";
            // 5 true 1 if 2 else +
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_ToInfix001_IsCorrect()
        {
            func.Function = "5 + if (true) { 1 } else { 2 }";
            Assert.AreEqual("5 true 1 if 2 else +", func.PostFix);
        }

        [Test]
        public void IfElse_CorrectFormat004_IsCorrect()
        {
            func.Function = "5 + if (false) { 1 } else { 2 }";
            Assert.AreEqual(7, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_WithElseIfCorrectFormat001_IsCorrect()
        {
            func.Function = "if (true) { 1 } else if (true) { 2 } else { 3 }";
            // true 1 if true 2 elseif 3 else 5 +
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_WithElseIfCorrectFormat002_IsCorrect()
        {
            func.Function = "5 + if (true) { 1 } else if (true) { 2 } else { 3 }";
            // true 1 if true 2 elseif 3 else 5 +
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_WithElseIfCorrectFormat003_IsCorrect()
        {
            func.Function = "if (false) { 1 } else if (true) { 2 } else { 3 }";
            Assert.AreEqual(2, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_WithElseIfCorrectFormat004_IsCorrect()
        {
            func.Function = "5 + if (false) { 1 } else if (true) { 2 } else { 3 }";
            // true 1 if true 2 elseif 3 else 5 +
            Assert.AreEqual(7, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_WithElseIfCorrectFormat005_IsCorrect()
        {
            func.Function = "if (false) { 1 } else if (false) { 2 } else { 3 }";
            Assert.AreEqual(3, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_WithElseIfCorrectFormat006_IsCorrect()
        {
            func.Function = "5 + if (false) { 1 } else if (false) { 2 } else { 3 }";
            // true 1 if true 2 elseif 3 else 5 +
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedCorrectFormat001_IsCorrect()
        {
            func.Function = "if (true) { if (true) { 1 } else { 2 } } else { 3 }";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedCorrectFormat002_IsCorrect()
        {
            func.Function = "5 + if (true) { if (false) { 1 } else { 2 } } else { 3 }";
            // 5 true  +
            Assert.AreEqual(7, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedCorrectFormat003_IsCorrect()
        {
            func.Function = "5 + if (true) { if (true) { 1 } else { 2 } } else { 3 }";
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedBoolean001_IsCorrect()
        {
            func.Function = "5 + if (8 > 1) { 1 } else { 2 }";
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedBoolean002_IsCorrect()
        {
            func.Function = "5 + if (8 > 1 || 8 < 10) { 1 } else { 2 }";
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedBooleanWithVariable001_IsCorrect()
        {
            func.Function = "5 + if (a > 1) { 1 } else { 2 }";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedBooleanWithVariable002_IsCorrect()
        {
            func.Function = "5 + if (a > 1 || a < 10) { 1 } else { 2 }";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedMathmaticalWithVariable001_IsCorrect()
        {
            func.Function = "5 + if (a > 1) { a + 1 } else { 2 }";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedMathmaticalWithVariable002_IsCorrect()
        {
            func.Function = "5 + if (a > 1 || a < 10) { a + 1 } else { a + 2 }";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
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

    }

}


// ReSharper disable InconsistentNaming
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class OperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(); }

        [TearDown]
        public void clear()
        { func.Clear(); }

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
        public void Ln_001()
        {
            func.Function = "ln(5)";
            Assert.AreEqual(1.6094379124341003, func.EvaluateNumeric());
        }

        [Test]
        public void Ln_002()
        {
            func.Function = "ln(5) + 1";
            Assert.AreEqual(2.6094379124341005, func.EvaluateNumeric());
        }

        [Test]
        public void Ln_003()
        {
            func.Function = "ln(5) * 2";
            Assert.AreEqual(3.2188758248682006, func.EvaluateNumeric());
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
            Assert.AreEqual(-23, func.EvaluateNumeric());
        }

        [Test]
        public void Subtraction002()
        {
            func.Function = "-22-23";
            Assert.AreEqual(-45, func.EvaluateNumeric());
        }

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
        public void MulitpleOperators_BadExpression001_ExpressionException()
        {
            func.Function = "1+(2*)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MulitpleOperators_BadExpression002_ExpressionException()
        {
            func.Function = "1/2*";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Expression formatted incorrecty", MatchType = MessageMatch.Contains)]
        public void MulitpleOperators_BadExpression005_ExpressionException()
        {
            func.Function = "1-(2+3)2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MulitpleOperators_BadExrpession006_ExpressionException()
        {
            func.Function = "+1/";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MulitpleOperators_BadExpression007_ExpressionException()
        {
            func.Function = "1-2-3-3-2-";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Function error", MatchType = MessageMatch.Contains)]
        public void Negation_BadExpression001_ExpressionException()
        {
            func.Function = "9832 neg";
        }

    }
}

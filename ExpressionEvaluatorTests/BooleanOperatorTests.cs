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
    public class BooleanOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

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

    }
}

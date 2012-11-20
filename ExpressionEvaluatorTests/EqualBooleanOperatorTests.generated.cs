// ReSharper disable InconsistentNaming
using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class EqualBooleanOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void EqualBooleanOperator_BooleanTrueWithBooleanTrue_IsCorrect()
        {
            func.Function = "True == True";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanTrueWithBooleanFalse_IsCorrect()
        {
            func.Function = "True == False";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanFalseWithBooleanTrue_IsCorrect()
        {
            func.Function = "False == True";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanFalseWithBooleanFalse_IsCorrect()
        {
            func.Function = "False == False";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanTrueWithBooleanTrueWithLeftVariable_IsCorrect()
        {
            func.Function = "a == True";
            func.AddSetVariable("a", true);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanTrueWithBooleanFalseWithLeftVariable_IsCorrect()
        {
            func.Function = "a == False";
            func.AddSetVariable("a", true);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanFalseWithBooleanTrueWithLeftVariable_IsCorrect()
        {
            func.Function = "a == True";
            func.AddSetVariable("a", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanFalseWithBooleanFalseWithLeftVariable_IsCorrect()
        {
            func.Function = "a == False";
            func.AddSetVariable("a", false);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanTrueWithBooleanTrueWithRightVariable_IsCorrect()
        {
            func.Function = "True == a";
            func.AddSetVariable("a", true);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanTrueWithBooleanFalseWithRightVariable_IsCorrect()
        {
            func.Function = "True == a";
            func.AddSetVariable("a", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanFalseWithBooleanTrueWithRightVariable_IsCorrect()
        {
            func.Function = "False == a";
            func.AddSetVariable("a", true);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanFalseWithBooleanFalseWithRightVariable_IsCorrect()
        {
            func.Function = "False == a";
            func.AddSetVariable("a", false);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanTrueWithBooleanTrueWithVariable_IsCorrect()
        {
            func.Function = "a == b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", true);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanTrueWithBooleanFalseWithVariable_IsCorrect()
        {
            func.Function = "a == b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanFalseWithBooleanTrueWithVariable_IsCorrect()
        {
            func.Function = "a == b";
            func.AddSetVariable("a", false);
            func.AddSetVariable("b", true);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualBooleanOperator_BooleanFalseWithBooleanFalseWithVariable_IsCorrect()
        {
            func.Function = "a == b";
            func.AddSetVariable("a", false);
            func.AddSetVariable("b", false);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void EqualBooleanOperator_MalformedExpressionBooleanTrueLeftOfOperator_ThrowsException()
        {
            func.Function = "True ==";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void EqualBooleanOperator_MalformedExpressionBooleanFalseLeftOfOperator_ThrowsException()
        {
            func.Function = "False ==";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void EqualBooleanOperator_MalformedExpressionBooleanTrueRightOfOperator_ThrowsException()
        {
            func.Function = "== True";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void EqualBooleanOperator_MalformedExpressionBooleanFalseRightOfOperator_ThrowsException()
        {
            func.Function = "== False";
        }

    }
}

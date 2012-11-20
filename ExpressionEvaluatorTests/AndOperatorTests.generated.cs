// ReSharper disable InconsistentNaming
using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class AndOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void AndOperator_BooleanTrueWithBooleanTrue_IsCorrect()
        {
            func.Function = "True && True";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanTrueWithBooleanFalse_IsCorrect()
        {
            func.Function = "True && False";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanFalseWithBooleanTrue_IsCorrect()
        {
            func.Function = "False && True";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanFalseWithBooleanFalse_IsCorrect()
        {
            func.Function = "False && False";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanTrueWithBooleanTrueWithLeftVariable_IsCorrect()
        {
            func.Function = "a && True";
            func.AddSetVariable("a", true);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanTrueWithBooleanFalseWithLeftVariable_IsCorrect()
        {
            func.Function = "a && False";
            func.AddSetVariable("a", true);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanFalseWithBooleanTrueWithLeftVariable_IsCorrect()
        {
            func.Function = "a && True";
            func.AddSetVariable("a", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanFalseWithBooleanFalseWithLeftVariable_IsCorrect()
        {
            func.Function = "a && False";
            func.AddSetVariable("a", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanTrueWithBooleanTrueWithRightVariable_IsCorrect()
        {
            func.Function = "True && a";
            func.AddSetVariable("a", true);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanTrueWithBooleanFalseWithRightVariable_IsCorrect()
        {
            func.Function = "True && a";
            func.AddSetVariable("a", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanFalseWithBooleanTrueWithRightVariable_IsCorrect()
        {
            func.Function = "False && a";
            func.AddSetVariable("a", true);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanFalseWithBooleanFalseWithRightVariable_IsCorrect()
        {
            func.Function = "False && a";
            func.AddSetVariable("a", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanTrueWithBooleanTrueWithVariable_IsCorrect()
        {
            func.Function = "a && b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", true);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanTrueWithBooleanFalseWithVariable_IsCorrect()
        {
            func.Function = "a && b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanFalseWithBooleanTrueWithVariable_IsCorrect()
        {
            func.Function = "a && b";
            func.AddSetVariable("a", false);
            func.AddSetVariable("b", true);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void AndOperator_BooleanFalseWithBooleanFalseWithVariable_IsCorrect()
        {
            func.Function = "a && b";
            func.AddSetVariable("a", false);
            func.AddSetVariable("b", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AndOperator_MalformedExpressionBooleanTrueLeftOfOperator_ThrowsException()
        {
            func.Function = "True &&";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AndOperator_MalformedExpressionBooleanFalseLeftOfOperator_ThrowsException()
        {
            func.Function = "False &&";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AndOperator_MalformedExpressionBooleanTrueRightOfOperator_ThrowsException()
        {
            func.Function = "&& True";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AndOperator_MalformedExpressionBooleanFalseRightOfOperator_ThrowsException()
        {
            func.Function = "&& False";
        }

    }
}

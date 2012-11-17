// ReSharper disable InconsistentNaming
using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class OrOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }
        
        [Test]
        public void OrOperator_BooleanTrueWithBooleanTrue_IsCorrect()
        {
            func.Function = "True || True";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void OrOperator_BooleanTrueWithBooleanFalse_IsCorrect()
        {
            func.Function = "True || False";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void OrOperator_BooleanFalseWithBooleanTrue_IsCorrect()
        {
            func.Function = "False || True";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void OrOperator_BooleanFalseWithBooleanFalse_IsCorrect()
        {
            func.Function = "False || False";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void OrOperator_BooleanTrueWithBooleanTrueWithLeftVariable_IsCorrect()
        {
            func.Function = "a || True";
			func.AddSetVariable("a", true);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void OrOperator_BooleanTrueWithBooleanFalseWithLeftVariable_IsCorrect()
        {
            func.Function = "a || False";
			func.AddSetVariable("a", true);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void OrOperator_BooleanFalseWithBooleanTrueWithLeftVariable_IsCorrect()
        {
            func.Function = "a || True";
			func.AddSetVariable("a", false);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void OrOperator_BooleanFalseWithBooleanFalseWithLeftVariable_IsCorrect()
        {
            func.Function = "a || False";
			func.AddSetVariable("a", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void OrOperator_BooleanTrueWithBooleanTrueWithRightVariable_IsCorrect()
        {
            func.Function = "True || a";
			func.AddSetVariable("a", true);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void OrOperator_BooleanTrueWithBooleanFalseWithRightVariable_IsCorrect()
        {
            func.Function = "True || a";
			func.AddSetVariable("a", false);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void OrOperator_BooleanFalseWithBooleanTrueWithRightVariable_IsCorrect()
        {
            func.Function = "False || a";
			func.AddSetVariable("a", true);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void OrOperator_BooleanFalseWithBooleanFalseWithRightVariable_IsCorrect()
        {
            func.Function = "False || a";
			func.AddSetVariable("a", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void OrOperator_BooleanTrueWithBooleanTrueWithVariable_IsCorrect()
        {
            func.Function = "a || b";
			func.AddSetVariable("a", true);
			func.AddSetVariable("b", true);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void OrOperator_BooleanTrueWithBooleanFalseWithVariable_IsCorrect()
        {
            func.Function = "a || b";
			func.AddSetVariable("a", true);
			func.AddSetVariable("b", false);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void OrOperator_BooleanFalseWithBooleanTrueWithVariable_IsCorrect()
        {
            func.Function = "a || b";
			func.AddSetVariable("a", false);
			func.AddSetVariable("b", true);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void OrOperator_BooleanFalseWithBooleanFalseWithVariable_IsCorrect()
        {
            func.Function = "a || b";
			func.AddSetVariable("a", false);
			func.AddSetVariable("b", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void OrOperator_MalformedExpressionBooleanTrueLeftOfOperator_ThrowsException()
        {
            func.Function = "True ||";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void OrOperator_MalformedExpressionBooleanFalseLeftOfOperator_ThrowsException()
        {
            func.Function = "False ||";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void OrOperator_MalformedExpressionBooleanTrueRightOfOperator_ThrowsException()
        {
            func.Function = "|| True";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void OrOperator_MalformedExpressionBooleanFalseRightOfOperator_ThrowsException()
        {
            func.Function = "|| False";
        }

    }
}

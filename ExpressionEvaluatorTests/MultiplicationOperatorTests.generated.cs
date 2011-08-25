// ReSharper disable InconsistentNaming
using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class MultiplicationOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }
        
        [Test]
        public void MultiplicationOperator_PositiveWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "2 * 2";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "2 * 0.5";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "2 * -2";
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "2 * -0.5";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "0.5 * 2";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "0.5 * 0.5";
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "0.5 * -2";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "0.5 * -0.5";
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-2 * 2";
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-2 * 0.5";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-2 * -2";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-2 * -0.5";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-0.5 * 2";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-0.5 * 0.5";
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-0.5 * -2";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-0.5 * -0.5";
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a * 2";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a * 0.5";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a * -2";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a * -0.5";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a * 2";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a * 0.5";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a * -2";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a * -0.5";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a * 2";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a * 0.5";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a * -2";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a * -0.5";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a * 2";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a * 0.5";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a * -2";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a * -0.5";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 * a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 * a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 * a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 * a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 * a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 * a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 * a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 * a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 * a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 * a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 * a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 * a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 * a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 * a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 * a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 * a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a * b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a * b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a * b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a * b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", -0.5);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a * b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a * b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a * b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a * b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", -0.5);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a * b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a * b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a * b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a * b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", -0.5);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a * b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a * b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a * b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a * b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", -0.5);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MultiplicationOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "2 *";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MultiplicationOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "0.5 *";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MultiplicationOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "-2 *";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MultiplicationOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "-0.5 *";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MultiplicationOperator_MalformedExpressionPositiveWholeRightOfOperator_ThrowsException()
        {
            func.Function = "* 2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MultiplicationOperator_MalformedExpressionPositiveFractionRightOfOperator_ThrowsException()
        {
            func.Function = "* 0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MultiplicationOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            func.Function = "* -2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MultiplicationOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            func.Function = "* -0.5";
        }

    }
}

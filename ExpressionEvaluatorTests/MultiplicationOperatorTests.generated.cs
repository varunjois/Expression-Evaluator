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
        public void MultiplicationOperator_PositiveWholeWithPositiveWhole_IsCorrect()
        {
            func.Function = "2 * 2";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithPositiveFraction_IsCorrect()
        {
            func.Function = "2 * 0.5";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithNegativeWhole_IsCorrect()
        {
            func.Function = "2 * -2";
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithNegativeFraction_IsCorrect()
        {
            func.Function = "2 * -0.5";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithPositiveWhole_IsCorrect()
        {
            func.Function = "0.5 * 2";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithPositiveFraction_IsCorrect()
        {
            func.Function = "0.5 * 0.5";
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithNegativeWhole_IsCorrect()
        {
            func.Function = "0.5 * -2";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithNegativeFraction_IsCorrect()
        {
            func.Function = "0.5 * -0.5";
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithPositiveWhole_IsCorrect()
        {
            func.Function = "-2 * 2";
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithPositiveFraction_IsCorrect()
        {
            func.Function = "-2 * 0.5";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithNegativeWhole_IsCorrect()
        {
            func.Function = "-2 * -2";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithNegativeFraction_IsCorrect()
        {
            func.Function = "-2 * -0.5";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithPositiveWhole_IsCorrect()
        {
            func.Function = "-0.5 * 2";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithPositiveFraction_IsCorrect()
        {
            func.Function = "-0.5 * 0.5";
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithNegativeWhole_IsCorrect()
        {
            func.Function = "-0.5 * -2";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithNegativeFraction_IsCorrect()
        {
            func.Function = "-0.5 * -0.5";
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a * 2";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a * 0.5";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a * -2";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a * -0.5";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a * 2";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a * 0.5";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a * -2";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a * -0.5";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a * 2";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a * 0.5";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a * -2";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a * -0.5";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a * 2";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a * 0.5";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a * -2";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a * -0.5";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 * a";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 * a";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 * a";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 * a";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 * a";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 * a";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 * a";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 * a";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 * a";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 * a";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 * a";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 * a";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 * a";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 * a";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 * a";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 * a";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a * b";
            func.AddSetVariable("a", 2d);
            func.AddSetVariable("b", 2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a * b";
            func.AddSetVariable("a", 2d);
            func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a * b";
            func.AddSetVariable("a", 2d);
            func.AddSetVariable("b", -2d);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a * b";
            func.AddSetVariable("a", 2d);
            func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a * b";
            func.AddSetVariable("a", 0.5d);
            func.AddSetVariable("b", 2d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a * b";
            func.AddSetVariable("a", 0.5d);
            func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a * b";
            func.AddSetVariable("a", 0.5d);
            func.AddSetVariable("b", -2d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_PositiveFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a * b";
            func.AddSetVariable("a", 0.5d);
            func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a * b";
            func.AddSetVariable("a", -2d);
            func.AddSetVariable("b", 2d);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a * b";
            func.AddSetVariable("a", -2d);
            func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a * b";
            func.AddSetVariable("a", -2d);
            func.AddSetVariable("b", -2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a * b";
            func.AddSetVariable("a", -2d);
            func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a * b";
            func.AddSetVariable("a", -0.5d);
            func.AddSetVariable("b", 2d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a * b";
            func.AddSetVariable("a", -0.5d);
            func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a * b";
            func.AddSetVariable("a", -0.5d);
            func.AddSetVariable("b", -2d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void MultiplicationOperator_NegativeFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a * b";
            func.AddSetVariable("a", -0.5d);
            func.AddSetVariable("b", -0.5d);
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

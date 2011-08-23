// ReSharper disable InconsistentNaming
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

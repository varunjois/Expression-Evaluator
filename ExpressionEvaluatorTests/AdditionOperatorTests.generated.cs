// ReSharper disable InconsistentNaming
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class AdditionOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }
        
        [Test]
        public void AdditionOperator_PositiveWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "2 + 2";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }
		
        [Test]
        public void AdditionOperator_PositiveWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "2 + 0.5";
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }
		
        [Test]
        public void AdditionOperator_PositiveWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "2 + -2";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }
		
        [Test]
        public void AdditionOperator_PositiveWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "2 + -0.5";
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }
		
        [Test]
        public void AdditionOperator_PositiveFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "0.5 + 2";
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }
		
        [Test]
        public void AdditionOperator_PositiveFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "0.5 + 0.5";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }
		
        [Test]
        public void AdditionOperator_PositiveFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "0.5 + -2";
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }
		
        [Test]
        public void AdditionOperator_PositiveFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "0.5 + -0.5";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }
		
        [Test]
        public void AdditionOperator_NegativeWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-2 + 2";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }
		
        [Test]
        public void AdditionOperator_NegativeWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-2 + 0.5";
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }
		
        [Test]
        public void AdditionOperator_NegativeWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-2 + -2";
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }
		
        [Test]
        public void AdditionOperator_NegativeWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-2 + -0.5";
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }
		
        [Test]
        public void AdditionOperator_NegativeFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-0.5 + 2";
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }
		
        [Test]
        public void AdditionOperator_NegativeFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-0.5 + 0.5";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }
		
        [Test]
        public void AdditionOperator_NegativeFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-0.5 + -2";
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }
		
        [Test]
        public void AdditionOperator_NegativeFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-0.5 + -0.5";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }
		
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AdditionOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "2 +";
        }
		
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AdditionOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "0.5 +";
        }
		
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AdditionOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "-2 +";
        }
		
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AdditionOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "-0.5 +";
        }
		
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AdditionOperator_MalformedExpressionPositiveWholeRightOfOperator_ThrowsException()
        {
            func.Function = "+ 2";
        }
		
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AdditionOperator_MalformedExpressionPositiveFractionRightOfOperator_ThrowsException()
        {
            func.Function = "+ 0.5";
        }
		
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AdditionOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            func.Function = "+ -2";
        }
		
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AdditionOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            func.Function = "+ -0.5";
        }
		
    }
}

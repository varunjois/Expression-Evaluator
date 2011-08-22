// ReSharper disable InconsistentNaming
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class DivisionOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }
        
        [Test]
        public void DivisionOperator_PositiveWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "2 / 2";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_PositiveWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "2 / 0.5";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_PositiveWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "2 / -2";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_PositiveWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "2 / -0.5";
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_PositiveFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "0.5 / 2";
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_PositiveFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "0.5 / 0.5";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_PositiveFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "0.5 / -2";
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_PositiveFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "0.5 / -0.5";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_NegativeWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-2 / 2";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_NegativeWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-2 / 0.5";
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_NegativeWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-2 / -2";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_NegativeWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-2 / -0.5";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_NegativeFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-0.5 / 2";
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_NegativeFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-0.5 / 0.5";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_NegativeFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-0.5 / -2";
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_NegativeFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-0.5 / -0.5";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }
		
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void DivisionOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "2 /";
        }
		
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void DivisionOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "0.5 /";
        }
		
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void DivisionOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "-2 /";
        }
		
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void DivisionOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "-0.5 /";
        }
		
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void DivisionOperator_MalformedExpressionPositiveWholeRightOfOperator_ThrowsException()
        {
            func.Function = "/ 2";
        }
		
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void DivisionOperator_MalformedExpressionPositiveFractionRightOfOperator_ThrowsException()
        {
            func.Function = "/ 0.5";
        }
		
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void DivisionOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            func.Function = "/ -2";
        }
		
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void DivisionOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            func.Function = "/ -0.5";
        }
		
    }
}

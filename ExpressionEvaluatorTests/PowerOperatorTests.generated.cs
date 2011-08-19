// ReSharper disable InconsistentNaming
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class PowerOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }
        
        [Test]
        public void PowerOperator_PositiveWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "2 ^ 2";
            Assert.AreEqual(4, func.EvaluateNumeric());
        }
		
        [Test]
        public void PowerOperator_PositiveWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "2 ^ 0.5";
            Assert.AreEqual(1.4142135623731, func.EvaluateNumeric());
        }
		
        [Test]
        public void PowerOperator_PositiveWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "2 ^ -2";
            Assert.AreEqual(0.25, func.EvaluateNumeric());
        }
		
        [Test]
        public void PowerOperator_PositiveWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "2 ^ -0.5";
            Assert.AreEqual(0.707106781186548, func.EvaluateNumeric());
        }
		
        [Test]
        public void PowerOperator_PositiveFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "0.5 ^ 2";
            Assert.AreEqual(0.25, func.EvaluateNumeric());
        }
		
        [Test]
        public void PowerOperator_PositiveFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "0.5 ^ 0.5";
            Assert.AreEqual(0.707106781186548, func.EvaluateNumeric());
        }
		
        [Test]
        public void PowerOperator_PositiveFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "0.5 ^ -2";
            Assert.AreEqual(4, func.EvaluateNumeric());
        }
		
        [Test]
        public void PowerOperator_PositiveFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "0.5 ^ -0.5";
            Assert.AreEqual(1.4142135623731, func.EvaluateNumeric());
        }
		
        [Test]
        public void PowerOperator_NegativeWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-2 ^ 2";
            Assert.AreEqual(4, func.EvaluateNumeric());
        }
		
        [Test]
        public void PowerOperator_NegativeWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-2 ^ 0.5";
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }
		
        [Test]
        public void PowerOperator_NegativeWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-2 ^ -2";
            Assert.AreEqual(0.25, func.EvaluateNumeric());
        }
		
        [Test]
        public void PowerOperator_NegativeWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-2 ^ -0.5";
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }
		
        [Test]
        public void PowerOperator_NegativeFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-0.5 ^ 2";
            Assert.AreEqual(0.25, func.EvaluateNumeric());
        }
		
        [Test]
        public void PowerOperator_NegativeFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-0.5 ^ 0.5";
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }
		
        [Test]
        public void PowerOperator_NegativeFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-0.5 ^ -2";
            Assert.AreEqual(4, func.EvaluateNumeric());
        }
		
        [Test]
        public void PowerOperator_NegativeFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-0.5 ^ -0.5";
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }
		
    }
}

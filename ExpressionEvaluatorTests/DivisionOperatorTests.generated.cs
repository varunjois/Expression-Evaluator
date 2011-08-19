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
            Assert.AreEqual(1, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_PositiveWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "2 / 0.5";
            Assert.AreEqual(4, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_PositiveWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "2 / -2";
            Assert.AreEqual(-1, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_PositiveWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "2 / -0.5";
            Assert.AreEqual(-4, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_PositiveFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "0.5 / 2";
            Assert.AreEqual(0.25, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_PositiveFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "0.5 / 0.5";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_PositiveFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "0.5 / -2";
            Assert.AreEqual(-0.25, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_PositiveFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "0.5 / -0.5";
            Assert.AreEqual(-1, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_NegativeWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-2 / 2";
            Assert.AreEqual(-1, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_NegativeWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-2 / 0.5";
            Assert.AreEqual(-4, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_NegativeWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-2 / -2";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_NegativeWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-2 / -0.5";
            Assert.AreEqual(4, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_NegativeFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-0.5 / 2";
            Assert.AreEqual(-0.25, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_NegativeFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-0.5 / 0.5";
            Assert.AreEqual(-1, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_NegativeFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-0.5 / -2";
            Assert.AreEqual(0.25, func.EvaluateNumeric());
        }
		
        [Test]
        public void DivisionOperator_NegativeFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-0.5 / -0.5";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }
		
    }
}

// ReSharper disable InconsistentNaming
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class SubtractionOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }
        
        [Test]
        public void SubtractionOperator_PositiveWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "2 - 2";
            Assert.AreEqual(0, func.EvaluateNumeric());
        }
		
        [Test]
        public void SubtractionOperator_PositiveWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "2 - 0.5";
            Assert.AreEqual(1.5, func.EvaluateNumeric());
        }
		
        [Test]
        public void SubtractionOperator_PositiveWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "2 - -2";
            Assert.AreEqual(4, func.EvaluateNumeric());
        }
		
        [Test]
        public void SubtractionOperator_PositiveWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "2 - -0.5";
            Assert.AreEqual(2.5, func.EvaluateNumeric());
        }
		
        [Test]
        public void SubtractionOperator_PositiveFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "0.5 - 2";
            Assert.AreEqual(-1.5, func.EvaluateNumeric());
        }
		
        [Test]
        public void SubtractionOperator_PositiveFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "0.5 - 0.5";
            Assert.AreEqual(0, func.EvaluateNumeric());
        }
		
        [Test]
        public void SubtractionOperator_PositiveFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "0.5 - -2";
            Assert.AreEqual(2.5, func.EvaluateNumeric());
        }
		
        [Test]
        public void SubtractionOperator_PositiveFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "0.5 - -0.5";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }
		
        [Test]
        public void SubtractionOperator_NegativeWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-2 - 2";
            Assert.AreEqual(-4, func.EvaluateNumeric());
        }
		
        [Test]
        public void SubtractionOperator_NegativeWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-2 - 0.5";
            Assert.AreEqual(-2.5, func.EvaluateNumeric());
        }
		
        [Test]
        public void SubtractionOperator_NegativeWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-2 - -2";
            Assert.AreEqual(0, func.EvaluateNumeric());
        }
		
        [Test]
        public void SubtractionOperator_NegativeWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-2 - -0.5";
            Assert.AreEqual(-1.5, func.EvaluateNumeric());
        }
		
        [Test]
        public void SubtractionOperator_NegativeFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-0.5 - 2";
            Assert.AreEqual(-2.5, func.EvaluateNumeric());
        }
		
        [Test]
        public void SubtractionOperator_NegativeFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-0.5 - 0.5";
            Assert.AreEqual(-1, func.EvaluateNumeric());
        }
		
        [Test]
        public void SubtractionOperator_NegativeFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-0.5 - -2";
            Assert.AreEqual(1.5, func.EvaluateNumeric());
        }
		
        [Test]
        public void SubtractionOperator_NegativeFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-0.5 - -0.5";
            Assert.AreEqual(0, func.EvaluateNumeric());
        }
		
    }
}

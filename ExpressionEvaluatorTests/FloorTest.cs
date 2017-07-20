using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class FloorTest
    {
        private Expression func;

        [SetUp]
        public void init() { func = new Expression(""); }

        [TearDown]
        public void clear() { func.Clear(); }

        [Test]
        public void Floor_InnerCalclationAdd_CorrectValue()
        {
            func.Function = @"floor(3+1.5)";
            Assert.AreEqual(4, func.EvaluateNumeric());
        }

        [Test]
        public void Floor_InnerCalculation_CorrectValue()
        {
            func.Function = @"floor(3.1)";
            Assert.AreEqual(3, func.EvaluateNumeric());
        }

        [Test]
        public void Floor_InnerCalculationDevide_CorrectValue()
        {
            func.Function = @"floor(5/3)";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [Test]
        public void Floor_InnerCalculationMulti_CorrectValue()
        {
            func.Function = @"floor(5*1.5)";
            Assert.AreEqual(7, func.EvaluateNumeric());
        }

        [Test]
        public void Floor_InnerCalculationNegative_CorrectValue()
        {
            func.Function = @"floor(-0.12 )";
            Assert.AreEqual(-1, func.EvaluateNumeric());
        }

        [Test]
        public void Floor_InnerCalculationNegativeRound_CorrectValue()
        {
            func.Function = @"floor(-7.12 )";
            Assert.AreEqual(-8, func.EvaluateNumeric());
        }

        [Test]
        public void Floor_InnerCalculationSubstract_CorrectValue()
        {
            func.Function = @"floor(2.56 -1.5)";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [Test]
        public void Floor_MidPoint001_CorrectValue()
        {
            func.Function = @"floor(1.5*0)";
            Assert.AreEqual(0, func.EvaluateNumeric());
        }
    }
}

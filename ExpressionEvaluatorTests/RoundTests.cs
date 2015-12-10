using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class RoundTests
    {
        private Expression func;

        [SetUp]
        public void init() { func = new Expression(""); }

        [TearDown]
        public void clear() { func.Clear(); }

        [Test]
        public void Round_MidPoint001_CorrectValue()
        {
            func.Function = @"round(1.5, 0)";
            Assert.AreEqual(2m, func.EvaluateNumeric());
        }

        [Test]
        public void Round_MidPoint002_CorrectValue()
        {
            func.Function = @"round(2.5, 0)";
            Assert.AreEqual(3m, func.EvaluateNumeric());
        }

        [Test]
        public void Round_ValidParameters001_CorrectValue()
        {
            func.Function = @"round(1.2, 1)";
            Assert.AreEqual(1.2m, func.EvaluateNumeric());
        }

        [Test]
        public void Round_ValidParameters002_CorrectValue()
        {
            func.Function = @"round(1.2, 0)";
            Assert.AreEqual(1m, func.EvaluateNumeric());
        }

        [Test]
        public void Round_ValidParameters003_CorrectValue()
        {
            func.Function = @"round(1.6, 0)";
            Assert.AreEqual(2m, func.EvaluateNumeric());
        }
    }
}

using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class SumTests
    {
        private Expression func;

        [SetUp]
        public void init() { func = new Expression(""); }

        [TearDown]
        public void clear() { func.Clear(); }

        [Test]
        public void Sum_NestedSumFunctions_CorrectValue()
        {
            func.Function = @"Sum(1, Sum(1, 2, Sum(1,2,3)), 3)";
            Assert.AreEqual(13, func.EvaluateNumeric());
        }

        [Test]
        public void Sum_NumbersAndLetter_LetterIgnored()
        {
            func.Function = @"Sum(a, 2, 3, 4)";
            Assert.AreEqual(9, func.EvaluateNumeric());
        }

        [Test]
        public void Sum_Numbers_IsCorrect()
        {
            func.Function = @"Sum(1, 2, 3, 4)";
            Assert.AreEqual(10, func.EvaluateNumeric());
        }

        [Test]
        public void Sum_TwoSumFunctions001_CorrectValue()
        {
            func.Function = @"Sum(1) + Sum(1)";
            Assert.AreEqual(2, func.EvaluateNumeric());
        }

        [Test]
        public void Sum_TwoSumFunctions_NoException()
        {
            try {
                func.Function = @"Sum(1) + Sum(1)";
            }
            catch {}
            func.Function = @"Sum(1) + Sum(1)";
        }

        [Test]
        public void Sum_WithVariable001_CorrectValue()
        {
            func.Function = @"Sum(a, b)";
            func.AddSetVariable("a", 1);
            func.AddSetVariable("b", 2);
            Assert.AreEqual(3, func.EvaluateNumeric());
        }
    }
}

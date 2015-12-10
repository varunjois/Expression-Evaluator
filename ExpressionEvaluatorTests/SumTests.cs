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
        public void Sum_NumbersAndVariable_EmptyVariableIgnored()
        {
            func.Function = @"Sum(a, 2, 3, 4)";
            Assert.AreEqual(9, func.EvaluateNumeric());
        }

        [Test]
        public void Sum_Numbers_Add_IsCorrect()
        {
            func.Function = @"sum(5,6)+Sum(1, 2, 3, 4)";
            Assert.AreEqual(21, func.EvaluateNumeric());
        }

        [Test]
        public void Sum_Numbers_IsCorrect()
        {
            func.Function = @"Sum(1, 2, 3, 4)";
            Assert.AreEqual(10, func.EvaluateNumeric());
        }

        [Test]
        public void Sum_Numbers_Multiply_1_IsCorrect()
        {
            func.Function = @"sum(5,6)*Sum(1, 2, 3, 4)";
            Assert.AreEqual(110, func.EvaluateNumeric());
        }

        [Test]
        public void Sum_Numbers_Multiply_Post_IsCorrect()
        {
            func.Function = @"Sum(5, 2, 3, 4)*2";
            Assert.AreEqual(28, func.EvaluateNumeric());
        }

        [Test]
        public void Sum_Numbers_subtract_IsCorrect()
        {
            func.Function = @"sum(5,6)-Sum(1, 2, 3, 4)";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [Test]
        public void Sum_Numbers_subtract_decimal_Devide_IsCorrect()
        {
            func.Function = @"(sum(6.5,6)-Sum(1.5, 2, 3, 4))/2";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [Test]
        public void Sum_Numbers_subtract_decimal_IsCorrect()
        {
            func.Function = @"sum(5.5,6)-Sum(1.5, 2, 3, 4)";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [Test]
        public void Sum_Numbers_subtract_decimal_Multiply_Both_IsCorrect()
        {
            func.Function = @"4*sum(5,6)";
            Assert.AreEqual(44, func.EvaluateNumeric());
        }

        [Test]
        public void Sum_Numbers_subtract_decimal_Multiply_IsCorrect()
        {
            func.Function = @"(sum(6.5,6)-Sum(1.5, 2, 3, 4))*2";
            Assert.AreEqual(4, func.EvaluateNumeric());
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

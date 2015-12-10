using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class ModuloTests
    {
        private Expression func;

        [SetUp]
        public void init() { func = new Expression(""); }

        [TearDown]
        public void clear() { func.Clear(); }

        [Test]
        public void Modulo_ValidValues001_CorrectValue()
        {
            func.Function = @"5 % 2";
            Assert.AreEqual(1m, func.EvaluateNumeric());
        }

        [Test]
        public void Modulo_ValidValues002_CorrectValue()
        {
            func.Function = @"2 * 5 % 3";
            Assert.AreEqual(1m, func.EvaluateNumeric());
        }

        [Test]
        public void Modulo_ValidValues003_CorrectValue()
        {
            func.Function = @"5 % 3 * 2";
            Assert.AreEqual(4m, func.EvaluateNumeric());
        }
    }
}

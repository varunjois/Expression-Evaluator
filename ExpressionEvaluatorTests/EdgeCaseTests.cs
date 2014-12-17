using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class DoubleToDecimalTests
    {
        private Expression _func;

        [SetUp]
        public void Init() { _func = new Expression(); }

        [TearDown]
        public void Clear() { _func.Clear(); }

        [Test]
        public void AbsoluteValue()
        {
            _func.Function = "abs(0.000001)";
            Assert.AreEqual(0.000001, _func.EvaluateNumeric());
        }

        [Test]
        public void NaturalLog()
        {
            _func.Function = "ln(0.999999)";
            Assert.AreEqual(-0.0000010000005000290891, _func.EvaluateNumeric());
        }

        [Test]
        public void Power()
        {
            _func.Function = "0.001^2";
            Assert.AreEqual(0.000001, _func.EvaluateNumeric());
        }
    }
}

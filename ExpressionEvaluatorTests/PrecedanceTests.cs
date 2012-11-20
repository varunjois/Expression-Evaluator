using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class PrecedanceTests
    {
        Expression _func;

        [SetUp]
        public void init()
        { this._func = new Expression(); }

        [TearDown]
        public void clear()
        { _func.Clear(); }

        [Test]
        public void Precedance_AdditionSubtraction_IsCorrect()
        {
            _func.Function = "2 + 3 - 2";
            Assert.AreEqual(3, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedance_SubtractionAddition_IsCorrect()
        {
            _func.Function = "3 - 2 + 2";
            Assert.AreEqual(3, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedance_AdditionMultiplication_IsCorrect()
        {
            _func.Function = "2 * 3 - 2";
            Assert.AreEqual(4, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedance_MultiplicationAddition_IsCorrect()
        {
            _func.Function = "8 - 2 * 3";
            Assert.AreEqual(2, _func.EvaluateNumeric());
        }
    }
}
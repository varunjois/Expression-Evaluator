using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class ScientificNotationTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void SciNotation_Expression001_IsCorrect()
        {
            _func.Function = "1 - 2 - 3 - 4 - 5e-1 - 7";
            Assert.AreEqual(-15.5, _func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression002_IsCorrect()
        {
            _func.Function = "1 - 2 - 3E - 1 - 5e - 1 - 7";
            Assert.AreEqual(-8.8, _func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression003_IsCorrect()
        {
            _func.Function = "1 + 2 - 3e + 1 - 5e - 1 - 7";
            Assert.AreEqual(-34.5, _func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression004_IsCorrect()
        {
            _func.Function = "3e - 4 - 5e - 6";
            Assert.AreEqual(0.00029499999999999996, _func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression005_IsCorrect()
        {
            _func.Function = "3 - - 4 - 5e - 1";
            Assert.AreEqual(6.5, _func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression006_IsCorrect()
        {
            _func.Function = "( 3 + 4 ) * - 4 - 5e-2";
            Assert.AreEqual(-28.05, _func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression007_IsCorrect()
        {
            _func.Function = "( 3 + 4 ) * - 403 - 5e-2";
            Assert.AreEqual(-2821.05, _func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression008_IsCorrect()
        {
            _func.Function = "403 - - 4 + -5";
            Assert.AreEqual(402, _func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression009_IsCorrect()
        {
            _func.Function = "( 3 + 4 ) * - 403 - - 5e-1";
            Assert.AreEqual(-2820.5, _func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression010_IsCorrect()
        {
            _func.Function = "- 403 + - 3 + - 4";
            Assert.AreEqual(-410, _func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression011_IsCorrect()
        {
            _func.Function = "- 403 + - 3e + 2 + - 4";
            Assert.AreEqual(-707, _func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression012_IsCorrect()
        {
            _func.Function = "- 403 + - 3e-1 + - 4e+2";
            Assert.AreEqual(-803.3, _func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression013_IsCorrect()
        {
            _func.Function = "- 403 + - 3e+2 + - 4e+4";
            Assert.AreEqual(-40703, _func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression014_IsCorrect()
        {
            _func.Function = "- 403e-2 + - 3e-6 + - 4e-8";
            Assert.AreEqual(-4.03000304, _func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression015_IsCorrect()
        {
            _func.Function = "- 403e+2 + - 3e-2 + - 4e+2";
            Assert.AreEqual(-40700.03, _func.EvaluateNumeric());
        }

        [Test]
        public void SciNotation_Expression016_IsCorrect()
        {
            _func.Function = "( - 3 + 4 ) * - 403 - - 5e-1";
            Assert.AreEqual(-402.5, _func.EvaluateNumeric());
        }

    }
}

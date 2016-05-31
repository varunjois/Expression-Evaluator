using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    class EdgeCaseNestedToNumber
    {
        private Expression _func;

        [SetUp]
        public void Init()
        {
            _func = new Expression();
        }

        [TearDown]
        public void Clear()
        {
            _func.Clear();
        }

        [Test]
        public void Greater_BadToNumber_ShouldReturnNaN()
        {
            _func.Function = "tonumber(substring(a, 1, length(a) - 1)) > 25";
            _func.AddSetVariable("a", "3");
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void Lesser_BadToNumber_ShouldReturnNaN()
        {
            _func.Function = "tonumber(substring(a, 1, length(a) - 1)) < 25";
            _func.AddSetVariable("a", "3");
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void LesserThan_BadToNumber_ShouldReturnNaN()
        {
            _func.Function = "tonumber(substring(a, 1, length(a) - 1)) <= 25";
            _func.AddSetVariable("a", "3");
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void NestedToNumber_FailingBranch_ShouldPass()
        {
            _func.Function =
                "if(substring(a, 0, 1) == '<') {tonumber(substring(a, 1, length(a) - 1)) <= 21.875} else {tonumber(a) <= 21.875}";

            _func.AddSetVariable("a", "3");
            Assert.AreEqual(true, _func.EvaluateBoolean());

            _func.AddSetVariable("a", "3.0");
            Assert.AreEqual(true, _func.EvaluateBoolean());

            _func.AddSetVariable("a", "<3.0");
            Assert.AreEqual(true, _func.EvaluateBoolean());

            _func.AddSetVariable("a", "<3");
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        public void Equal_BadToNumber_ShouldReturnNaN()
        {
            _func.Function = "tonumber(substring(a, 1, length(a) - 1)) == 25";
            _func.AddSetVariable("a", "3");
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        public void GreaterEqual_BadToNumber_ShouldReturnNaN()
        {
            _func.Function = "tonumber(substring(a, 1, length(a) - 1)) >= 25";
            _func.AddSetVariable("a", "3");
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        public void NotEqual_BadToNumber_ShouldReturnNaN()
        {
            _func.Function = "tonumber(substring(a, 1, length(a) - 1)) != 25";
            _func.AddSetVariable("a", "3");
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }
    }
}

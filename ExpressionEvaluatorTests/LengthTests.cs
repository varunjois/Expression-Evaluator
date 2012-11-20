using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class LengthTests
    {
        Expression _func;

        [SetUp]
        public void init()
        { this._func = new Expression(""); }

        [TearDown]
        public void clear()
        { _func.Clear(); }

        [Test]
        public void Length_ValidSTring_IsCorrect()
        {
            _func.Function = @"Length('abcd')";
            Assert.AreEqual(4, _func.EvaluateNumeric());
        }

        [Test]
        public void Contains_StringIsASubstring_True()
        {
            _func.Function = @"substring(a, 1, Length(a) - 1)";
            _func.AddSetVariable("a", "abcd");
            Assert.AreEqual("bcd", _func.Evaluate<string>());
        }
    }
}
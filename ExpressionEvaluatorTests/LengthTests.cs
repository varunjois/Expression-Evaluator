using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class LengthTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void Length_ValidSTring_IsCorrect()
        {
            func.Function = @"Length('abcd')";
            Assert.AreEqual(4, func.EvaluateNumeric());
        }

        [Test]
        public void Contains_StringIsASubstring_True()
        {
            func.Function = @"substring(a, 1, Length(a) - 1)";
            func.AddSetVariable("a", "abcd");
            Assert.AreEqual("bcd", func.Evaluate<string>());
        }
    }
}
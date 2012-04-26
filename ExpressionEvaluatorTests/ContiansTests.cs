using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class ContiansTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void Contains_StringIsASubstring_True()
        {
            func.Function = @"Contains('abcd','bc')";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void Contains_StringBegins_True()
        {
            func.Function = @"Contains('abcd','ab')";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void Contains_StringEnds_True()
        {
            func.Function = @"Contains('abcd','cd')";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }
    }
}
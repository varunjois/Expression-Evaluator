using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class StringTests
    {
        private Expression func;

        [SetUp]
        public void init()
        {
            this.func = new Expression("");
        }

        [TearDown]
        public void clear()
        {
            func.Clear();
        }

        [Test]
        public void String_ValidNoSpaces_IsCorrect()
        {
            func.Function = "'a'";
            Assert.AreEqual("a", func.Evaluate<string>());
        }

        [Test]
        public void String_ValidFrontSpace_IsCorrect()
        {
            func.Function = "' a'";
            Assert.AreEqual(" a", func.Evaluate<string>());
        }

        [Test]
        public void String_ValidBackSSpace_IsCorrect()
        {
            func.Function = "'a '";
            Assert.AreEqual("a ", func.Evaluate<string>());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "String grouping error", MatchType = MessageMatch.Contains)]
        public void String_TooManySeperators_Exception()
        {
            func.Function = "'aoeu ''";
            func.Evaluate<string>();
        }
    }
}
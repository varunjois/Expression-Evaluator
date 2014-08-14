using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class StringTests
    {
        private Expression _func;

        [SetUp]
        public void Init()
        {
            _func = new Expression("");
        }

        [TearDown]
        public void Clear()
        {
            _func.Clear();
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "String grouping error",
            MatchType = MessageMatch.Contains)]
        public void String_TooManySeperators_Exception()
        {
            _func.Function = "'aoeu ''";
            _func.Evaluate<string>();
        }

        [Test]
        public void String_ValidBackSSpace_IsCorrect()
        {
            _func.Function = "'a '";
            Assert.AreEqual("a ", _func.Evaluate<string>());
        }

        [Test]
        public void String_ValidFrontSpace_IsCorrect()
        {
            _func.Function = "' a'";
            Assert.AreEqual(" a", _func.Evaluate<string>());
        }

        [Test]
        public void String_ValidNoSpaces_IsCorrect()
        {
            _func.Function = "'a'";
            Assert.AreEqual("a", _func.Evaluate<string>());
        }
    }
}

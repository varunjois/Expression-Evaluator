// ReSharper disable InconsistentNaming
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class SignOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }
        
        [Test]
        public void SignOperator_CalledWithPositiveWhole_IsCorrect()
        {
            func.Function = "sign(2)";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }
        
        [Test]
        public void SignOperator_CalledWithPositiveFraction_IsCorrect()
        {
            func.Function = "sign(0.5)";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }
        
        [Test]
        public void SignOperator_CalledWithNegativeWhole_IsCorrect()
        {
            func.Function = "sign(-2)";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }
        
        [Test]
        public void SignOperator_CalledWithNegativeFraction_IsCorrect()
        {
            func.Function = "sign(-0.5)";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void SignOperator_MalformedExpressionMissingRightParenPositiveWholeArgument_ThrowsException()
        {
            func.Function = "sign(2";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void SignOperator_MalformedExpressionMissingRightParenPositiveFractionArgument_ThrowsException()
        {
            func.Function = "sign(0.5";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void SignOperator_MalformedExpressionMissingRightParenNegativeWholeArgument_ThrowsException()
        {
            func.Function = "sign(-2";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void SignOperator_MalformedExpressionMissingRightParenNegativeFractionArgument_ThrowsException()
        {
            func.Function = "sign(-0.5";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void SignOperator_MalformedExpressionMissingLeftParenPositiveWholeArgument_ThrowsException()
        {
            func.Function = "sign 2)";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void SignOperator_MalformedExpressionMissingLeftParenPositiveFractionArgument_ThrowsException()
        {
            func.Function = "sign 0.5)";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void SignOperator_MalformedExpressionMissingLeftParenNegativeWholeArgument_ThrowsException()
        {
            func.Function = "sign -2)";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void SignOperator_MalformedExpressionMissingLeftParenNegativeFractionArgument_ThrowsException()
        {
            func.Function = "sign -0.5)";
        }
        
    }
}

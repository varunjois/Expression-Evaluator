// ReSharper disable InconsistentNaming
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class NegFunctionTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }
        
        [Test]
        public void NegOperator_CalledWithPositiveWhole_IsCorrect()
        {
            func.Function = "neg(2)";
            Assert.AreEqual(-2d, func.EvaluateNumeric());
        }
        
        [Test]
        public void NegOperator_CalledWithPositiveFraction_IsCorrect()
        {
            func.Function = "neg(0.5)";
            Assert.AreEqual(-0.5d, func.EvaluateNumeric());
        }
        
        [Test]
        public void NegOperator_CalledWithNegativeWhole_IsCorrect()
        {
            func.Function = "neg(-2)";
            Assert.AreEqual(2d, func.EvaluateNumeric());
        }
        
        [Test]
        public void NegOperator_CalledWithNegativeFraction_IsCorrect()
        {
            func.Function = "neg(-0.5)";
            Assert.AreEqual(0.5d, func.EvaluateNumeric());
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void NegOperator_MalformedExpressionMissingRightParenPositiveWholeArgument_ThrowsException()
        {
            func.Function = "neg(2";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void NegOperator_MalformedExpressionMissingRightParenPositiveFractionArgument_ThrowsException()
        {
            func.Function = "neg(0.5";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void NegOperator_MalformedExpressionMissingRightParenNegativeWholeArgument_ThrowsException()
        {
            func.Function = "neg(-2";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void NegOperator_MalformedExpressionMissingRightParenNegativeFractionArgument_ThrowsException()
        {
            func.Function = "neg(-0.5";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void NegOperator_MalformedExpressionMissingLeftParenPositiveWholeArgument_ThrowsException()
        {
            func.Function = "neg 2)";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void NegOperator_MalformedExpressionMissingLeftParenPositiveFractionArgument_ThrowsException()
        {
            func.Function = "neg 0.5)";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void NegOperator_MalformedExpressionMissingLeftParenNegativeWholeArgument_ThrowsException()
        {
            func.Function = "neg -2)";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void NegOperator_MalformedExpressionMissingLeftParenNegativeFractionArgument_ThrowsException()
        {
            func.Function = "neg -0.5)";
        }
        
    }
}

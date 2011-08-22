// ReSharper disable InconsistentNaming
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class LnOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }
        
        [Test]
        public void LnOperator_CalledWithPositiveWhole_IsCorrect()
        {
            func.Function = "ln(2)";
            Assert.AreEqual(0.69314718055994529d, func.EvaluateNumeric());
        }
        
        [Test]
        public void LnOperator_CalledWithPositiveFraction_IsCorrect()
        {
            func.Function = "ln(0.5)";
            Assert.AreEqual(-0.69314718055994529d, func.EvaluateNumeric());
        }
        
        [Test]
        public void LnOperator_CalledWithNegativeWhole_IsCorrect()
        {
            func.Function = "ln(-2)";
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }
        
        [Test]
        public void LnOperator_CalledWithNegativeFraction_IsCorrect()
        {
            func.Function = "ln(-0.5)";
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void LnOperator_MalformedExpressionMissingRightParenPositiveWholeArgument_ThrowsException()
        {
            func.Function = "ln(2";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void LnOperator_MalformedExpressionMissingRightParenPositiveFractionArgument_ThrowsException()
        {
            func.Function = "ln(0.5";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void LnOperator_MalformedExpressionMissingRightParenNegativeWholeArgument_ThrowsException()
        {
            func.Function = "ln(-2";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void LnOperator_MalformedExpressionMissingRightParenNegativeFractionArgument_ThrowsException()
        {
            func.Function = "ln(-0.5";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void LnOperator_MalformedExpressionMissingLeftParenPositiveWholeArgument_ThrowsException()
        {
            func.Function = "ln 2)";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void LnOperator_MalformedExpressionMissingLeftParenPositiveFractionArgument_ThrowsException()
        {
            func.Function = "ln 0.5)";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void LnOperator_MalformedExpressionMissingLeftParenNegativeWholeArgument_ThrowsException()
        {
            func.Function = "ln -2)";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void LnOperator_MalformedExpressionMissingLeftParenNegativeFractionArgument_ThrowsException()
        {
            func.Function = "ln -0.5)";
        }
        
    }
}

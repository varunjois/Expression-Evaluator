// ReSharper disable InconsistentNaming
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class AbsFunctionTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }
        
        [Test]
        public void AbsOperator_CalledWithPositiveWhole_IsCorrect()
        {
            func.Function = "abs(2)";
            Assert.AreEqual(2d, func.EvaluateNumeric());
        }
        
        [Test]
        public void AbsOperator_CalledWithPositiveFraction_IsCorrect()
        {
            func.Function = "abs(0.5)";
            Assert.AreEqual(0.5d, func.EvaluateNumeric());
        }
        
        [Test]
        public void AbsOperator_CalledWithNegativeWhole_IsCorrect()
        {
            func.Function = "abs(-2)";
            Assert.AreEqual(2d, func.EvaluateNumeric());
        }
        
        [Test]
        public void AbsOperator_CalledWithNegativeFraction_IsCorrect()
        {
            func.Function = "abs(-0.5)";
            Assert.AreEqual(0.5d, func.EvaluateNumeric());
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingRightParenPositiveWholeArgument_ThrowsException()
        {
            func.Function = "abs(2";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingRightParenPositiveFractionArgument_ThrowsException()
        {
            func.Function = "abs(0.5";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingRightParenNegativeWholeArgument_ThrowsException()
        {
            func.Function = "abs(-2";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingRightParenNegativeFractionArgument_ThrowsException()
        {
            func.Function = "abs(-0.5";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingLeftParenPositiveWholeArgument_ThrowsException()
        {
            func.Function = "abs 2)";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingLeftParenPositiveFractionArgument_ThrowsException()
        {
            func.Function = "abs 0.5)";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingLeftParenNegativeWholeArgument_ThrowsException()
        {
            func.Function = "abs -2)";
        }
        
        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingLeftParenNegativeFractionArgument_ThrowsException()
        {
            func.Function = "abs -0.5)";
        }
        
    }
}

using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class AbsFunctionTests
    {
        Expression _func;

        [SetUp]
        public void init()
        { this._func = new Expression(""); }

        [TearDown]
        public void clear()
        { _func.Clear(); }

        [Test]
        public void AbsOperator_CalledWithPositiveWhole_IsCorrect()
        {
            _func.Function = "abs(2)";
            Assert.AreEqual(2d, _func.EvaluateNumeric());
        }

        [Test]
        public void AbsOperator_CalledWithPositiveFraction_IsCorrect()
        {
            _func.Function = "abs(0.5)";
            Assert.AreEqual(0.5d, _func.EvaluateNumeric());
        }

        [Test]
        public void AbsOperator_CalledWithNegativeWhole_IsCorrect()
        {
            _func.Function = "abs(-2)";
            Assert.AreEqual(2d, _func.EvaluateNumeric());
        }

        [Test]
        public void AbsOperator_CalledWithNegativeFraction_IsCorrect()
        {
            _func.Function = "abs(-0.5)";
            Assert.AreEqual(0.5d, _func.EvaluateNumeric());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingRightParenPositiveWholeArgument_ThrowsException()
        {
            _func.Function = "abs(2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingRightParenPositiveFractionArgument_ThrowsException()
        {
            _func.Function = "abs(0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingRightParenNegativeWholeArgument_ThrowsException()
        {
            _func.Function = "abs(-2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingRightParenNegativeFractionArgument_ThrowsException()
        {
            _func.Function = "abs(-0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingLeftParenPositiveWholeArgument_ThrowsException()
        {
            _func.Function = "abs 2)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingLeftParenPositiveFractionArgument_ThrowsException()
        {
            _func.Function = "abs 0.5)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingLeftParenNegativeWholeArgument_ThrowsException()
        {
            _func.Function = "abs -2)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingLeftParenNegativeFractionArgument_ThrowsException()
        {
            _func.Function = "abs -0.5)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingBothParenthesisPositiveWholeArgument_ThrowsException()
        {
            _func.Function = "abs 2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingBothParenthesisPositiveFractionArgument_ThrowsException()
        {
            _func.Function = "abs 0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingBothParenthesisNegativeWholeArgument_ThrowsException()
        {
            _func.Function = "abs -2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void AbsOperator_MalformedExpressionMissingBothParenthesisNegativeFractionArgument_ThrowsException()
        {
            _func.Function = "abs -0.5";
        }

    }
}

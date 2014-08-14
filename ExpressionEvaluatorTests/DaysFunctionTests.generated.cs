using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class DaysFunctionTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void DaysOperator_CalledWithPositiveWhole_IsCorrect()
        {
            _func.Function = "days(2)";
            Assert.AreEqual(new TimeSpan(1728000000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void DaysOperator_CalledWithPositiveFraction_IsCorrect()
        {
            _func.Function = "days(0.5)";
            Assert.AreEqual(new TimeSpan(432000000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void DaysOperator_CalledWithNegativeWhole_IsCorrect()
        {
            _func.Function = "days(-2)";
            Assert.AreEqual(new TimeSpan(-1728000000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void DaysOperator_CalledWithNegativeFraction_IsCorrect()
        {
            _func.Function = "days(-0.5)";
            Assert.AreEqual(new TimeSpan(-432000000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingRightParenPositiveWholeArgument_ThrowsException()
        {
            _func.Function = "days(2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingRightParenPositiveFractionArgument_ThrowsException()
        {
            _func.Function = "days(0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingRightParenNegativeWholeArgument_ThrowsException()
        {
            _func.Function = "days(-2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingRightParenNegativeFractionArgument_ThrowsException()
        {
            _func.Function = "days(-0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingLeftParenPositiveWholeArgument_ThrowsException()
        {
            _func.Function = "days 2)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingLeftParenPositiveFractionArgument_ThrowsException()
        {
            _func.Function = "days 0.5)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingLeftParenNegativeWholeArgument_ThrowsException()
        {
            _func.Function = "days -2)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingLeftParenNegativeFractionArgument_ThrowsException()
        {
            _func.Function = "days -0.5)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingBothParenthesisPositiveWholeArgument_ThrowsException()
        {
            _func.Function = "days 2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingBothParenthesisPositiveFractionArgument_ThrowsException()
        {
            _func.Function = "days 0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingBothParenthesisNegativeWholeArgument_ThrowsException()
        {
            _func.Function = "days -2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingBothParenthesisNegativeFractionArgument_ThrowsException()
        {
            _func.Function = "days -0.5";
        }

    }
}

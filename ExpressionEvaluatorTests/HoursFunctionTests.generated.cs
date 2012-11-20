using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class HoursFunctionTests
    {
        Expression _func;

        [SetUp]
        public void init()
        { this._func = new Expression(""); }

        [TearDown]
        public void clear()
        { _func.Clear(); }

        [Test]
        public void HoursOperator_CalledWithPositiveWhole_IsCorrect()
        {
            _func.Function = "hours(2)";
            Assert.AreEqual(new TimeSpan(72000000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void HoursOperator_CalledWithPositiveFraction_IsCorrect()
        {
            _func.Function = "hours(0.5)";
            Assert.AreEqual(new TimeSpan(18000000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void HoursOperator_CalledWithNegativeWhole_IsCorrect()
        {
            _func.Function = "hours(-2)";
            Assert.AreEqual(new TimeSpan(-72000000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        public void HoursOperator_CalledWithNegativeFraction_IsCorrect()
        {
            _func.Function = "hours(-0.5)";
            Assert.AreEqual(new TimeSpan(-18000000000L), _func.Evaluate<TimeSpan>());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void HoursOperator_MalformedExpressionMissingRightParenPositiveWholeArgument_ThrowsException()
        {
            _func.Function = "hours(2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void HoursOperator_MalformedExpressionMissingRightParenPositiveFractionArgument_ThrowsException()
        {
            _func.Function = "hours(0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void HoursOperator_MalformedExpressionMissingRightParenNegativeWholeArgument_ThrowsException()
        {
            _func.Function = "hours(-2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void HoursOperator_MalformedExpressionMissingRightParenNegativeFractionArgument_ThrowsException()
        {
            _func.Function = "hours(-0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void HoursOperator_MalformedExpressionMissingLeftParenPositiveWholeArgument_ThrowsException()
        {
            _func.Function = "hours 2)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void HoursOperator_MalformedExpressionMissingLeftParenPositiveFractionArgument_ThrowsException()
        {
            _func.Function = "hours 0.5)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void HoursOperator_MalformedExpressionMissingLeftParenNegativeWholeArgument_ThrowsException()
        {
            _func.Function = "hours -2)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void HoursOperator_MalformedExpressionMissingLeftParenNegativeFractionArgument_ThrowsException()
        {
            _func.Function = "hours -0.5)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void HoursOperator_MalformedExpressionMissingBothParenthesisPositiveWholeArgument_ThrowsException()
        {
            _func.Function = "hours 2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void HoursOperator_MalformedExpressionMissingBothParenthesisPositiveFractionArgument_ThrowsException()
        {
            _func.Function = "hours 0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void HoursOperator_MalformedExpressionMissingBothParenthesisNegativeWholeArgument_ThrowsException()
        {
            _func.Function = "hours -2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void HoursOperator_MalformedExpressionMissingBothParenthesisNegativeFractionArgument_ThrowsException()
        {
            _func.Function = "hours -0.5";
        }

    }
}

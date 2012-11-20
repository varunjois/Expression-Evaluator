// ReSharper disable InconsistentNaming
using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class DaysFunctionTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void DaysOperator_CalledWithPositiveWhole_IsCorrect()
        {
            func.Function = "days(2)";
            Assert.AreEqual(new TimeSpan(1728000000000L), func.Evaluate<TimeSpan>());
        }

        [Test]
        public void DaysOperator_CalledWithPositiveFraction_IsCorrect()
        {
            func.Function = "days(0.5)";
            Assert.AreEqual(new TimeSpan(432000000000L), func.Evaluate<TimeSpan>());
        }

        [Test]
        public void DaysOperator_CalledWithNegativeWhole_IsCorrect()
        {
            func.Function = "days(-2)";
            Assert.AreEqual(new TimeSpan(-1728000000000L), func.Evaluate<TimeSpan>());
        }

        [Test]
        public void DaysOperator_CalledWithNegativeFraction_IsCorrect()
        {
            func.Function = "days(-0.5)";
            Assert.AreEqual(new TimeSpan(-432000000000L), func.Evaluate<TimeSpan>());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingRightParenPositiveWholeArgument_ThrowsException()
        {
            func.Function = "days(2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingRightParenPositiveFractionArgument_ThrowsException()
        {
            func.Function = "days(0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingRightParenNegativeWholeArgument_ThrowsException()
        {
            func.Function = "days(-2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingRightParenNegativeFractionArgument_ThrowsException()
        {
            func.Function = "days(-0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingLeftParenPositiveWholeArgument_ThrowsException()
        {
            func.Function = "days 2)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingLeftParenPositiveFractionArgument_ThrowsException()
        {
            func.Function = "days 0.5)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingLeftParenNegativeWholeArgument_ThrowsException()
        {
            func.Function = "days -2)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingLeftParenNegativeFractionArgument_ThrowsException()
        {
            func.Function = "days -0.5)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingBothParenthesisPositiveWholeArgument_ThrowsException()
        {
            func.Function = "days 2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingBothParenthesisPositiveFractionArgument_ThrowsException()
        {
            func.Function = "days 0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingBothParenthesisNegativeWholeArgument_ThrowsException()
        {
            func.Function = "days -2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open and close parenthesis required", MatchType = MessageMatch.Contains)]
        public void DaysOperator_MalformedExpressionMissingBothParenthesisNegativeFractionArgument_ThrowsException()
        {
            func.Function = "days -0.5";
        }

    }
}

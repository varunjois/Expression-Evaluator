// ReSharper disable InconsistentNaming
using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class DivisionOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }
        
        [Test]
        public void DivisionOperator_PositiveWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "2 / 2";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "2 / 0.5";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "2 / -2";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "2 / -0.5";
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "0.5 / 2";
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "0.5 / 0.5";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "0.5 / -2";
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "0.5 / -0.5";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-2 / 2";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-2 / 0.5";
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-2 / -2";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-2 / -0.5";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-0.5 / 2";
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-0.5 / 0.5";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-0.5 / -2";
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-0.5 / -0.5";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a / 2";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a / 0.5";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a / -2";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a / -0.5";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a / 2";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a / 0.5";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a / -2";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a / -0.5";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a / 2";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a / 0.5";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a / -2";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a / -0.5";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a / 2";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a / 0.5";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a / -2";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a / -0.5";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 / a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 / a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 / a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 / a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 / a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 / a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 / a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 / a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 / a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 / a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 / a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 / a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 / a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 / a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 / a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 / a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", -0.5);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", -0.5);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", -0.5);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", -0.5);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void DivisionOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "2 /";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void DivisionOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "0.5 /";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void DivisionOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "-2 /";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void DivisionOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "-0.5 /";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void DivisionOperator_MalformedExpressionPositiveWholeRightOfOperator_ThrowsException()
        {
            func.Function = "/ 2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void DivisionOperator_MalformedExpressionPositiveFractionRightOfOperator_ThrowsException()
        {
            func.Function = "/ 0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void DivisionOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            func.Function = "/ -2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void DivisionOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            func.Function = "/ -0.5";
        }

    }
}

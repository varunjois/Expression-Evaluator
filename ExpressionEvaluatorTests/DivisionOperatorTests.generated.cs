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
        public void DivisionOperator_PositiveWholeWithPositiveWhole_IsCorrect()
        {
            func.Function = "2 / 2";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithPositiveFraction_IsCorrect()
        {
            func.Function = "2 / 0.5";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithNegativeWhole_IsCorrect()
        {
            func.Function = "2 / -2";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithNegativeFraction_IsCorrect()
        {
            func.Function = "2 / -0.5";
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithPositiveWhole_IsCorrect()
        {
            func.Function = "0.5 / 2";
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithPositiveFraction_IsCorrect()
        {
            func.Function = "0.5 / 0.5";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithNegativeWhole_IsCorrect()
        {
            func.Function = "0.5 / -2";
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithNegativeFraction_IsCorrect()
        {
            func.Function = "0.5 / -0.5";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithPositiveWhole_IsCorrect()
        {
            func.Function = "-2 / 2";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithPositiveFraction_IsCorrect()
        {
            func.Function = "-2 / 0.5";
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithNegativeWhole_IsCorrect()
        {
            func.Function = "-2 / -2";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithNegativeFraction_IsCorrect()
        {
            func.Function = "-2 / -0.5";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithPositiveWhole_IsCorrect()
        {
            func.Function = "-0.5 / 2";
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithPositiveFraction_IsCorrect()
        {
            func.Function = "-0.5 / 0.5";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithNegativeWhole_IsCorrect()
        {
            func.Function = "-0.5 / -2";
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithNegativeFraction_IsCorrect()
        {
            func.Function = "-0.5 / -0.5";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a / 2";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a / 0.5";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a / -2";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a / -0.5";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a / 2";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a / 0.5";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a / -2";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a / -0.5";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a / 2";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a / 0.5";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a / -2";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a / -0.5";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a / 2";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a / 0.5";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a / -2";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a / -0.5";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 / a";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 / a";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 / a";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 / a";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 / a";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 / a";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 / a";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 / a";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 / a";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 / a";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 / a";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 / a";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 / a";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 / a";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 / a";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 / a";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", 2d);
			func.AddSetVariable("b", 2d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", 2d);
			func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", 2d);
			func.AddSetVariable("b", -2d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", 2d);
			func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", 0.5d);
			func.AddSetVariable("b", 2d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", 0.5d);
			func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", 0.5d);
			func.AddSetVariable("b", -2d);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_PositiveFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", 0.5d);
			func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", -2d);
			func.AddSetVariable("b", 2d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", -2d);
			func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", -2d);
			func.AddSetVariable("b", -2d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", -2d);
			func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", -0.5d);
			func.AddSetVariable("b", 2d);
            Assert.AreEqual(-0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", -0.5d);
			func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", -0.5d);
			func.AddSetVariable("b", -2d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void DivisionOperator_NegativeFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a / b";
			func.AddSetVariable("a", -0.5d);
			func.AddSetVariable("b", -0.5d);
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

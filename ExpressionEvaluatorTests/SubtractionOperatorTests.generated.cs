// ReSharper disable InconsistentNaming
using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class SubtractionOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void SubtractionOperator_PositiveWholeWithPositiveWhole_IsCorrect()
        {
            func.Function = "2 - 2";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithPositiveFraction_IsCorrect()
        {
            func.Function = "2 - 0.5";
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithNegativeWhole_IsCorrect()
        {
            func.Function = "2 - -2";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithNegativeFraction_IsCorrect()
        {
            func.Function = "2 - -0.5";
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithPositiveWhole_IsCorrect()
        {
            func.Function = "0.5 - 2";
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithPositiveFraction_IsCorrect()
        {
            func.Function = "0.5 - 0.5";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithNegativeWhole_IsCorrect()
        {
            func.Function = "0.5 - -2";
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithNegativeFraction_IsCorrect()
        {
            func.Function = "0.5 - -0.5";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithPositiveWhole_IsCorrect()
        {
            func.Function = "-2 - 2";
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithPositiveFraction_IsCorrect()
        {
            func.Function = "-2 - 0.5";
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithNegativeWhole_IsCorrect()
        {
            func.Function = "-2 - -2";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithNegativeFraction_IsCorrect()
        {
            func.Function = "-2 - -0.5";
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithPositiveWhole_IsCorrect()
        {
            func.Function = "-0.5 - 2";
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithPositiveFraction_IsCorrect()
        {
            func.Function = "-0.5 - 0.5";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithNegativeWhole_IsCorrect()
        {
            func.Function = "-0.5 - -2";
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithNegativeFraction_IsCorrect()
        {
            func.Function = "-0.5 - -0.5";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a - 2";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a - 0.5";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a - -2";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a - -0.5";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a - 2";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a - 0.5";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a - -2";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a - -0.5";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a - 2";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a - 0.5";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a - -2";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a - -0.5";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a - 2";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a - 0.5";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a - -2";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a - -0.5";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 - a";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 - a";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 - a";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 - a";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 - a";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 - a";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 - a";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 - a";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 - a";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 - a";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 - a";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 - a";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 - a";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 - a";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 - a";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 - a";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a - b";
            func.AddSetVariable("a", 2d);
            func.AddSetVariable("b", 2d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a - b";
            func.AddSetVariable("a", 2d);
            func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a - b";
            func.AddSetVariable("a", 2d);
            func.AddSetVariable("b", -2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a - b";
            func.AddSetVariable("a", 2d);
            func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a - b";
            func.AddSetVariable("a", 0.5d);
            func.AddSetVariable("b", 2d);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a - b";
            func.AddSetVariable("a", 0.5d);
            func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a - b";
            func.AddSetVariable("a", 0.5d);
            func.AddSetVariable("b", -2d);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a - b";
            func.AddSetVariable("a", 0.5d);
            func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a - b";
            func.AddSetVariable("a", -2d);
            func.AddSetVariable("b", 2d);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a - b";
            func.AddSetVariable("a", -2d);
            func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a - b";
            func.AddSetVariable("a", -2d);
            func.AddSetVariable("b", -2d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a - b";
            func.AddSetVariable("a", -2d);
            func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a - b";
            func.AddSetVariable("a", -0.5d);
            func.AddSetVariable("b", 2d);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a - b";
            func.AddSetVariable("a", -0.5d);
            func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a - b";
            func.AddSetVariable("a", -0.5d);
            func.AddSetVariable("b", -2d);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a - b";
            func.AddSetVariable("a", -0.5d);
            func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void SubtractionOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "2 -";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void SubtractionOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "0.5 -";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void SubtractionOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "-2 -";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void SubtractionOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "-0.5 -";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void SubtractionOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            func.Function = "- -2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void SubtractionOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            func.Function = "- -0.5";
        }

    }
}

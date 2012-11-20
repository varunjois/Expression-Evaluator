using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class PowerOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void PowerOperator_PositiveWholeWithPositiveWhole_IsCorrect()
        {
            func.Function = "2 ^ 2";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithPositiveFraction_IsCorrect()
        {
            func.Function = "2 ^ 0.5";
            Assert.AreEqual(1.4142135623730952d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithNegativeWhole_IsCorrect()
        {
            func.Function = "2 ^ -2";
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithNegativeFraction_IsCorrect()
        {
            func.Function = "2 ^ -0.5";
            Assert.AreEqual(0.70710678118654757d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithPositiveWhole_IsCorrect()
        {
            func.Function = "0.5 ^ 2";
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithPositiveFraction_IsCorrect()
        {
            func.Function = "0.5 ^ 0.5";
            Assert.AreEqual(0.70710678118654757d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithNegativeWhole_IsCorrect()
        {
            func.Function = "0.5 ^ -2";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithNegativeFraction_IsCorrect()
        {
            func.Function = "0.5 ^ -0.5";
            Assert.AreEqual(1.4142135623730952d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithPositiveWhole_IsCorrect()
        {
            func.Function = "-2 ^ 2";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithPositiveFraction_IsCorrect()
        {
            func.Function = "-2 ^ 0.5";
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithNegativeWhole_IsCorrect()
        {
            func.Function = "-2 ^ -2";
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithNegativeFraction_IsCorrect()
        {
            func.Function = "-2 ^ -0.5";
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithPositiveWhole_IsCorrect()
        {
            func.Function = "-0.5 ^ 2";
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithPositiveFraction_IsCorrect()
        {
            func.Function = "-0.5 ^ 0.5";
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithNegativeWhole_IsCorrect()
        {
            func.Function = "-0.5 ^ -2";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithNegativeFraction_IsCorrect()
        {
            func.Function = "-0.5 ^ -0.5";
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ 2";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ 0.5";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(1.4142135623730952d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ -2";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ -0.5";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(0.70710678118654757d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ 2";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ 0.5";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0.70710678118654757d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ -2";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ -0.5";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1.4142135623730952d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ 2";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ 0.5";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ -2";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ -0.5";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ 2";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ 0.5";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ -2";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ -0.5";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 ^ a";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 ^ a";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1.4142135623730952d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 ^ a";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 ^ a";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(0.70710678118654757d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 ^ a";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 ^ a";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0.70710678118654757d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 ^ a";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 ^ a";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(1.4142135623730952d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 ^ a";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 ^ a";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 ^ a";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 ^ a";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 ^ a";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 ^ a";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 ^ a";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 ^ a";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
            func.AddSetVariable("a", 2d);
            func.AddSetVariable("b", 2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
            func.AddSetVariable("a", 2d);
            func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(1.4142135623730952d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
            func.AddSetVariable("a", 2d);
            func.AddSetVariable("b", -2d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
            func.AddSetVariable("a", 2d);
            func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(0.70710678118654757d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
            func.AddSetVariable("a", 0.5d);
            func.AddSetVariable("b", 2d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
            func.AddSetVariable("a", 0.5d);
            func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(0.70710678118654757d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
            func.AddSetVariable("a", 0.5d);
            func.AddSetVariable("b", -2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
            func.AddSetVariable("a", 0.5d);
            func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(1.4142135623730952d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
            func.AddSetVariable("a", -2d);
            func.AddSetVariable("b", 2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
            func.AddSetVariable("a", -2d);
            func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
            func.AddSetVariable("a", -2d);
            func.AddSetVariable("b", -2d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
            func.AddSetVariable("a", -2d);
            func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
            func.AddSetVariable("a", -0.5d);
            func.AddSetVariable("b", 2d);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
            func.AddSetVariable("a", -0.5d);
            func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
            func.AddSetVariable("a", -0.5d);
            func.AddSetVariable("b", -2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
            func.AddSetVariable("a", -0.5d);
            func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void PowerOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "2 ^";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void PowerOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "0.5 ^";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void PowerOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "-2 ^";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void PowerOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "-0.5 ^";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void PowerOperator_MalformedExpressionPositiveWholeRightOfOperator_ThrowsException()
        {
            func.Function = "^ 2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void PowerOperator_MalformedExpressionPositiveFractionRightOfOperator_ThrowsException()
        {
            func.Function = "^ 0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void PowerOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            func.Function = "^ -2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void PowerOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            func.Function = "^ -0.5";
        }

    }
}

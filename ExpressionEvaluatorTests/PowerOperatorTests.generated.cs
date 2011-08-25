// ReSharper disable InconsistentNaming
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
        public void PowerOperator_PositiveWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "2 ^ 2";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "2 ^ 0.5";
            Assert.AreEqual(1.4142135623730952d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "2 ^ -2";
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "2 ^ -0.5";
            Assert.AreEqual(0.70710678118654757d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "0.5 ^ 2";
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "0.5 ^ 0.5";
            Assert.AreEqual(0.70710678118654757d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "0.5 ^ -2";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "0.5 ^ -0.5";
            Assert.AreEqual(1.4142135623730952d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-2 ^ 2";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-2 ^ 0.5";
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-2 ^ -2";
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-2 ^ -0.5";
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-0.5 ^ 2";
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-0.5 ^ 0.5";
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-0.5 ^ -2";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-0.5 ^ -0.5";
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ 2";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ 0.5";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(1.4142135623730952d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ -2";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ -0.5";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(0.70710678118654757d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ 2";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ 0.5";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(0.70710678118654757d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ -2";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ -0.5";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(1.4142135623730952d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ 2";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ 0.5";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ -2";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ -0.5";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ 2";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ 0.5";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ -2";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a ^ -0.5";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 ^ a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 ^ a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(1.4142135623730952d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 ^ a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 ^ a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(0.70710678118654757d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 ^ a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 ^ a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(0.70710678118654757d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 ^ a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 ^ a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(1.4142135623730952d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 ^ a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 ^ a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 ^ a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 ^ a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 ^ a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 ^ a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 ^ a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 ^ a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(1.4142135623730952d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveWholeAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", -0.5);
            Assert.AreEqual(0.70710678118654757d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(0.70710678118654757d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_PositiveFractionAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", -0.5);
            Assert.AreEqual(1.4142135623730952d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeWholeAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", -0.5);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(0.25d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void PowerOperator_NegativeFractionAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a ^ b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", -0.5);
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

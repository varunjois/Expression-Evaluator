// ReSharper disable InconsistentNaming
using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class AdditionOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }
        
        [Test]
        public void AdditionOperator_PositiveWholeWithPositiveWhole_IsCorrect()
        {
            func.Function = "2 + 2";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithPositiveFraction_IsCorrect()
        {
            func.Function = "2 + 0.5";
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithNegativeWhole_IsCorrect()
        {
            func.Function = "2 + -2";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithNegativeFraction_IsCorrect()
        {
            func.Function = "2 + -0.5";
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithPositiveWhole_IsCorrect()
        {
            func.Function = "0.5 + 2";
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithPositiveFraction_IsCorrect()
        {
            func.Function = "0.5 + 0.5";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithNegativeWhole_IsCorrect()
        {
            func.Function = "0.5 + -2";
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithNegativeFraction_IsCorrect()
        {
            func.Function = "0.5 + -0.5";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithPositiveWhole_IsCorrect()
        {
            func.Function = "-2 + 2";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithPositiveFraction_IsCorrect()
        {
            func.Function = "-2 + 0.5";
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithNegativeWhole_IsCorrect()
        {
            func.Function = "-2 + -2";
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithNegativeFraction_IsCorrect()
        {
            func.Function = "-2 + -0.5";
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithPositiveWhole_IsCorrect()
        {
            func.Function = "-0.5 + 2";
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithPositiveFraction_IsCorrect()
        {
            func.Function = "-0.5 + 0.5";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithNegativeWhole_IsCorrect()
        {
            func.Function = "-0.5 + -2";
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithNegativeFraction_IsCorrect()
        {
            func.Function = "-0.5 + -0.5";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a + 2";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a + 0.5";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a + -2";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a + -0.5";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a + 2";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a + 0.5";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a + -2";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a + -0.5";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a + 2";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a + 0.5";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a + -2";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a + -0.5";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a + 2";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a + 0.5";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a + -2";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a + -0.5";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 + a";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 + a";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 + a";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 + a";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 + a";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 + a";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 + a";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 + a";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 + a";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 + a";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 + a";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 + a";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 + a";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 + a";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 + a";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 + a";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", 2d);
			func.AddSetVariable("b", 2d);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", 2d);
			func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", 2d);
			func.AddSetVariable("b", -2d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", 2d);
			func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", 0.5d);
			func.AddSetVariable("b", 2d);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", 0.5d);
			func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", 0.5d);
			func.AddSetVariable("b", -2d);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", 0.5d);
			func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", -2d);
			func.AddSetVariable("b", 2d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", -2d);
			func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", -2d);
			func.AddSetVariable("b", -2d);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", -2d);
			func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", -0.5d);
			func.AddSetVariable("b", 2d);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", -0.5d);
			func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", -0.5d);
			func.AddSetVariable("b", -2d);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", -0.5d);
			func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AdditionOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "2 +";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AdditionOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "0.5 +";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AdditionOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "-2 +";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AdditionOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "-0.5 +";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AdditionOperator_MalformedExpressionPositiveWholeRightOfOperator_ThrowsException()
        {
            func.Function = "+ 2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AdditionOperator_MalformedExpressionPositiveFractionRightOfOperator_ThrowsException()
        {
            func.Function = "+ 0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AdditionOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            func.Function = "+ -2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void AdditionOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            func.Function = "+ -0.5";
        }

    }
}

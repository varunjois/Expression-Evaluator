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
        public void AdditionOperator_PositiveWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "2 + 2";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "2 + 0.5";
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "2 + -2";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "2 + -0.5";
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "0.5 + 2";
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "0.5 + 0.5";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "0.5 + -2";
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "0.5 + -0.5";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-2 + 2";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-2 + 0.5";
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-2 + -2";
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-2 + -0.5";
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-0.5 + 2";
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-0.5 + 0.5";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-0.5 + -2";
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-0.5 + -0.5";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a + 2";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a + 0.5";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a + -2";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a + -0.5";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a + 2";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a + 0.5";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a + -2";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a + -0.5";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a + 2";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a + 0.5";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a + -2";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a + -0.5";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a + 2";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a + 0.5";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a + -2";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a + -0.5";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 + a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 + a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 + a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 + a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 + a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 + a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 + a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 + a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 + a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 + a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 + a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 + a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 + a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 + a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 + a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 + a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveWholeAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", -0.5);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_PositiveFractionAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", -0.5);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeWholeAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", -0.5);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void AdditionOperator_NegativeFractionAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a + b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", -0.5);
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

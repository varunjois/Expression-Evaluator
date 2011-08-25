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
        public void SubtractionOperator_PositiveWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "2 - 2";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "2 - 0.5";
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "2 - -2";
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "2 - -0.5";
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "0.5 - 2";
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "0.5 - 0.5";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "0.5 - -2";
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "0.5 - -0.5";
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-2 - 2";
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-2 - 0.5";
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-2 - -2";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-2 - -0.5";
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionAddedToPositiveWhole_IsCorrect()
        {
            func.Function = "-0.5 - 2";
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionAddedToPositiveFraction_IsCorrect()
        {
            func.Function = "-0.5 - 0.5";
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionAddedToNegativeWhole_IsCorrect()
        {
            func.Function = "-0.5 - -2";
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionAddedToNegativeFraction_IsCorrect()
        {
            func.Function = "-0.5 - -0.5";
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a - 2";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a - 0.5";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a - -2";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a - -0.5";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a - 2";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a - 0.5";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a - -2";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a - -0.5";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a - 2";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a - 0.5";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a - -2";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a - -0.5";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionAddedToPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a - 2";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionAddedToPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a - 0.5";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionAddedToNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a - -2";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionAddedToNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a - -0.5";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 - a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 - a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 - a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 - a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 - a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 - a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 - a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 - a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 - a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 - a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 - a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 - a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionAddedToPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 - a";
			func.AddSetVariable("a", 2);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionAddedToPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 - a";
			func.AddSetVariable("a", 0.5);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionAddedToNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 - a";
			func.AddSetVariable("a", -2);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionAddedToNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 - a";
			func.AddSetVariable("a", -0.5);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a - b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a - b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a - b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(4d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveWholeAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a - b";
			func.AddSetVariable("a", 2);
			func.AddSetVariable("b", -0.5);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a - b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a - b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a - b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_PositiveFractionAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a - b";
			func.AddSetVariable("a", 0.5);
			func.AddSetVariable("b", -0.5);
            Assert.AreEqual(1d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a - b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(-4d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a - b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a - b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(0d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeWholeAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a - b";
			func.AddSetVariable("a", -2);
			func.AddSetVariable("b", -0.5);
            Assert.AreEqual(-1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionAddedToPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a - b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", 2);
            Assert.AreEqual(-2.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionAddedToPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a - b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", 0.5);
            Assert.AreEqual(-1d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionAddedToNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a - b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", -2);
            Assert.AreEqual(1.5d, func.EvaluateNumeric());
        }

        [Test]
        public void SubtractionOperator_NegativeFractionAddedToNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a - b";
			func.AddSetVariable("a", -0.5);
			func.AddSetVariable("b", -0.5);
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

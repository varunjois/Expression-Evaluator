// ReSharper disable InconsistentNaming
using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class LesserEqualOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithPositiveWhole_IsCorrect()
        {
            func.Function = "2 <= 2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithPositiveFraction_IsCorrect()
        {
            func.Function = "2 <= 0.5";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithNegativeWhole_IsCorrect()
        {
            func.Function = "2 <= -2";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithNegativeFraction_IsCorrect()
        {
            func.Function = "2 <= -0.5";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithPositiveWhole_IsCorrect()
        {
            func.Function = "0.5 <= 2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithPositiveFraction_IsCorrect()
        {
            func.Function = "0.5 <= 0.5";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithNegativeWhole_IsCorrect()
        {
            func.Function = "0.5 <= -2";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithNegativeFraction_IsCorrect()
        {
            func.Function = "0.5 <= -0.5";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithPositiveWhole_IsCorrect()
        {
            func.Function = "-2 <= 2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithPositiveFraction_IsCorrect()
        {
            func.Function = "-2 <= 0.5";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithNegativeWhole_IsCorrect()
        {
            func.Function = "-2 <= -2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithNegativeFraction_IsCorrect()
        {
            func.Function = "-2 <= -0.5";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithPositiveWhole_IsCorrect()
        {
            func.Function = "-0.5 <= 2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithPositiveFraction_IsCorrect()
        {
            func.Function = "-0.5 <= 0.5";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithNegativeWhole_IsCorrect()
        {
            func.Function = "-0.5 <= -2";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithNegativeFraction_IsCorrect()
        {
            func.Function = "-0.5 <= -0.5";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a <= 2";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a <= 0.5";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a <= -2";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a <= -0.5";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a <= 2";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a <= 0.5";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a <= -2";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a <= -0.5";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a <= 2";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a <= 0.5";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a <= -2";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a <= -0.5";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a <= 2";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a <= 0.5";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a <= -2";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a <= -0.5";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 <= a";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 <= a";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 <= a";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 <= a";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 <= a";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 <= a";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 <= a";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 <= a";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 <= a";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 <= a";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 <= a";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 <= a";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 <= a";
            func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 <= a";
            func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 <= a";
            func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 <= a";
            func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", 2d);
            func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", 2d);
            func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", 2d);
            func.AddSetVariable("b", -2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", 2d);
            func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", 0.5d);
            func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", 0.5d);
            func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", 0.5d);
            func.AddSetVariable("b", -2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_PositiveFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", 0.5d);
            func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", -2d);
            func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", -2d);
            func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", -2d);
            func.AddSetVariable("b", -2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", -2d);
            func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", -0.5d);
            func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", -0.5d);
            func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", -0.5d);
            func.AddSetVariable("b", -2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqualOperator_NegativeFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", -0.5d);
            func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void LesserEqualOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "2 <=";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void LesserEqualOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "0.5 <=";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void LesserEqualOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "-2 <=";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void LesserEqualOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "-0.5 <=";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void LesserEqualOperator_MalformedExpressionPositiveWholeRightOfOperator_ThrowsException()
        {
            func.Function = "<= 2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void LesserEqualOperator_MalformedExpressionPositiveFractionRightOfOperator_ThrowsException()
        {
            func.Function = "<= 0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void LesserEqualOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            func.Function = "<= -2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void LesserEqualOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            func.Function = "<= -0.5";
        }

    }
}

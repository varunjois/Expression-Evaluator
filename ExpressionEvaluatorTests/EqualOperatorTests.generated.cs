// ReSharper disable InconsistentNaming
using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class EqualOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }
        
        [Test]
        public void EqualOperator_PositiveWholeWithPositiveWhole_IsCorrect()
        {
            func.Function = "2 == 2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveWholeWithPositiveFraction_IsCorrect()
        {
            func.Function = "2 == 0.5";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveWholeWithNegativeWhole_IsCorrect()
        {
            func.Function = "2 == -2";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveWholeWithNegativeFraction_IsCorrect()
        {
            func.Function = "2 == -0.5";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveFractionWithPositiveWhole_IsCorrect()
        {
            func.Function = "0.5 == 2";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveFractionWithPositiveFraction_IsCorrect()
        {
            func.Function = "0.5 == 0.5";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveFractionWithNegativeWhole_IsCorrect()
        {
            func.Function = "0.5 == -2";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveFractionWithNegativeFraction_IsCorrect()
        {
            func.Function = "0.5 == -0.5";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeWholeWithPositiveWhole_IsCorrect()
        {
            func.Function = "-2 == 2";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeWholeWithPositiveFraction_IsCorrect()
        {
            func.Function = "-2 == 0.5";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeWholeWithNegativeWhole_IsCorrect()
        {
            func.Function = "-2 == -2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeWholeWithNegativeFraction_IsCorrect()
        {
            func.Function = "-2 == -0.5";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeFractionWithPositiveWhole_IsCorrect()
        {
            func.Function = "-0.5 == 2";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeFractionWithPositiveFraction_IsCorrect()
        {
            func.Function = "-0.5 == 0.5";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeFractionWithNegativeWhole_IsCorrect()
        {
            func.Function = "-0.5 == -2";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeFractionWithNegativeFraction_IsCorrect()
        {
            func.Function = "-0.5 == -0.5";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a == 2";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a == 0.5";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a == -2";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a == -0.5";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a == 2";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a == 0.5";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a == -2";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a == -0.5";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a == 2";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a == 0.5";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a == -2";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a == -0.5";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a == 2";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a == 0.5";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a == -2";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a == -0.5";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 == a";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 == a";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 == a";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 == a";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 == a";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 == a";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 == a";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 == a";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 == a";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 == a";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 == a";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 == a";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 == a";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 == a";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 == a";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 == a";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", 2d);
			func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", 2d);
			func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", 2d);
			func.AddSetVariable("b", -2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", 2d);
			func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", 0.5d);
			func.AddSetVariable("b", 2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", 0.5d);
			func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", 0.5d);
			func.AddSetVariable("b", -2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_PositiveFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", 0.5d);
			func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", -2d);
			func.AddSetVariable("b", 2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", -2d);
			func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", -2d);
			func.AddSetVariable("b", -2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", -2d);
			func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", -0.5d);
			func.AddSetVariable("b", 2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", -0.5d);
			func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", -0.5d);
			func.AddSetVariable("b", -2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualOperator_NegativeFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", -0.5d);
			func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void EqualOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "2 ==";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void EqualOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "0.5 ==";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void EqualOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "-2 ==";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void EqualOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "-0.5 ==";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void EqualOperator_MalformedExpressionPositiveWholeRightOfOperator_ThrowsException()
        {
            func.Function = "== 2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void EqualOperator_MalformedExpressionPositiveFractionRightOfOperator_ThrowsException()
        {
            func.Function = "== 0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void EqualOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            func.Function = "== -2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void EqualOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            func.Function = "== -0.5";
        }

    }
}

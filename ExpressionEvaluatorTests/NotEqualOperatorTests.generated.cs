// ReSharper disable InconsistentNaming
using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class NotEqualOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }
        
        [Test]
        public void NotEqualOperator_PositiveWholeWithPositiveWhole_IsCorrect()
        {
            func.Function = "2 != 2";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveWholeWithPositiveFraction_IsCorrect()
        {
            func.Function = "2 != 0.5";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveWholeWithNegativeWhole_IsCorrect()
        {
            func.Function = "2 != -2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveWholeWithNegativeFraction_IsCorrect()
        {
            func.Function = "2 != -0.5";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveFractionWithPositiveWhole_IsCorrect()
        {
            func.Function = "0.5 != 2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveFractionWithPositiveFraction_IsCorrect()
        {
            func.Function = "0.5 != 0.5";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveFractionWithNegativeWhole_IsCorrect()
        {
            func.Function = "0.5 != -2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveFractionWithNegativeFraction_IsCorrect()
        {
            func.Function = "0.5 != -0.5";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeWholeWithPositiveWhole_IsCorrect()
        {
            func.Function = "-2 != 2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeWholeWithPositiveFraction_IsCorrect()
        {
            func.Function = "-2 != 0.5";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeWholeWithNegativeWhole_IsCorrect()
        {
            func.Function = "-2 != -2";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeWholeWithNegativeFraction_IsCorrect()
        {
            func.Function = "-2 != -0.5";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeFractionWithPositiveWhole_IsCorrect()
        {
            func.Function = "-0.5 != 2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeFractionWithPositiveFraction_IsCorrect()
        {
            func.Function = "-0.5 != 0.5";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeFractionWithNegativeWhole_IsCorrect()
        {
            func.Function = "-0.5 != -2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeFractionWithNegativeFraction_IsCorrect()
        {
            func.Function = "-0.5 != -0.5";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a != 2";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a != 0.5";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a != -2";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a != -0.5";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a != 2";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a != 0.5";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a != -2";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a != -0.5";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeWholeWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a != 2";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeWholeWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a != 0.5";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeWholeWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a != -2";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeWholeWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a != -0.5";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeFractionWithPositiveWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a != 2";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeFractionWithPositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a != 0.5";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeFractionWithNegativeWholeWithLeftVariable_IsCorrect()
        {
            func.Function = "a != -2";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeFractionWithNegativeFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "a != -0.5";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 != a";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 != a";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "2 != a";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "2 != a";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 != a";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 != a";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 != a";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "0.5 != a";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeWholeWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 != a";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeWholeWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 != a";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeWholeWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-2 != a";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeWholeWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-2 != a";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeFractionWithPositiveWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 != a";
			func.AddSetVariable("a", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeFractionWithPositiveFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 != a";
			func.AddSetVariable("a", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeFractionWithNegativeWholeWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 != a";
			func.AddSetVariable("a", -2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeFractionWithNegativeFractionWithRightVariable_IsCorrect()
        {
            func.Function = "-0.5 != a";
			func.AddSetVariable("a", -0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a != b";
			func.AddSetVariable("a", 2d);
			func.AddSetVariable("b", 2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a != b";
			func.AddSetVariable("a", 2d);
			func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a != b";
			func.AddSetVariable("a", 2d);
			func.AddSetVariable("b", -2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a != b";
			func.AddSetVariable("a", 2d);
			func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a != b";
			func.AddSetVariable("a", 0.5d);
			func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a != b";
			func.AddSetVariable("a", 0.5d);
			func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a != b";
			func.AddSetVariable("a", 0.5d);
			func.AddSetVariable("b", -2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_PositiveFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a != b";
			func.AddSetVariable("a", 0.5d);
			func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeWholeWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a != b";
			func.AddSetVariable("a", -2d);
			func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeWholeWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a != b";
			func.AddSetVariable("a", -2d);
			func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeWholeWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a != b";
			func.AddSetVariable("a", -2d);
			func.AddSetVariable("b", -2d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeWholeWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a != b";
			func.AddSetVariable("a", -2d);
			func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeFractionWithPositiveWholeWithVariable_IsCorrect()
        {
            func.Function = "a != b";
			func.AddSetVariable("a", -0.5d);
			func.AddSetVariable("b", 2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeFractionWithPositiveFractionWithVariable_IsCorrect()
        {
            func.Function = "a != b";
			func.AddSetVariable("a", -0.5d);
			func.AddSetVariable("b", 0.5d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeFractionWithNegativeWholeWithVariable_IsCorrect()
        {
            func.Function = "a != b";
			func.AddSetVariable("a", -0.5d);
			func.AddSetVariable("b", -2d);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualOperator_NegativeFractionWithNegativeFractionWithVariable_IsCorrect()
        {
            func.Function = "a != b";
			func.AddSetVariable("a", -0.5d);
			func.AddSetVariable("b", -0.5d);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void NotEqualOperator_MalformedExpressionPositiveWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "2 !=";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void NotEqualOperator_MalformedExpressionPositiveFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "0.5 !=";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void NotEqualOperator_MalformedExpressionNegativeWholeLeftOfOperator_ThrowsException()
        {
            func.Function = "-2 !=";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void NotEqualOperator_MalformedExpressionNegativeFractionLeftOfOperator_ThrowsException()
        {
            func.Function = "-0.5 !=";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void NotEqualOperator_MalformedExpressionPositiveWholeRightOfOperator_ThrowsException()
        {
            func.Function = "!= 2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void NotEqualOperator_MalformedExpressionPositiveFractionRightOfOperator_ThrowsException()
        {
            func.Function = "!= 0.5";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void NotEqualOperator_MalformedExpressionNegativeWholeRightOfOperator_ThrowsException()
        {
            func.Function = "!= -2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void NotEqualOperator_MalformedExpressionNegativeFractionRightOfOperator_ThrowsException()
        {
            func.Function = "!= -0.5";
        }

    }
}

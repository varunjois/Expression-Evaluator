using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class NotEqualStringOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void NotEqualStringOperator_StringFirstWithStringFirst_IsCorrect()
        {
            func.Function = "'first' != 'first'";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringFirstWithStringSecond_IsCorrect()
        {
            func.Function = "'first' != '1sec.ond'";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringSecondWithStringFirst_IsCorrect()
        {
            func.Function = "'1sec.ond' != 'first'";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringSecondWithStringSecond_IsCorrect()
        {
            func.Function = "'1sec.ond' != '1sec.ond'";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringFirstWithStringFirstWithLeftVariable_IsCorrect()
        {
            func.Function = "a != 'first'";
            func.AddSetVariable("a", "first");
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringFirstWithStringSecondWithLeftVariable_IsCorrect()
        {
            func.Function = "a != '1sec.ond'";
            func.AddSetVariable("a", "first");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringSecondWithStringFirstWithLeftVariable_IsCorrect()
        {
            func.Function = "a != 'first'";
            func.AddSetVariable("a", "1sec.ond");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringSecondWithStringSecondWithLeftVariable_IsCorrect()
        {
            func.Function = "a != '1sec.ond'";
            func.AddSetVariable("a", "1sec.ond");
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringFirstWithStringFirstWithRightVariable_IsCorrect()
        {
            func.Function = "'first' != a";
            func.AddSetVariable("a", "first");
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringFirstWithStringSecondWithRightVariable_IsCorrect()
        {
            func.Function = "'first' != a";
            func.AddSetVariable("a", "1sec.ond");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringSecondWithStringFirstWithRightVariable_IsCorrect()
        {
            func.Function = "'1sec.ond' != a";
            func.AddSetVariable("a", "first");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringSecondWithStringSecondWithRightVariable_IsCorrect()
        {
            func.Function = "'1sec.ond' != a";
            func.AddSetVariable("a", "1sec.ond");
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringFirstWithStringFirstWithVariable_IsCorrect()
        {
            func.Function = "a != b";
            func.AddSetVariable("a", "first");
            func.AddSetVariable("b", "first");
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringFirstWithStringSecondWithVariable_IsCorrect()
        {
            func.Function = "a != b";
            func.AddSetVariable("a", "first");
            func.AddSetVariable("b", "1sec.ond");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringSecondWithStringFirstWithVariable_IsCorrect()
        {
            func.Function = "a != b";
            func.AddSetVariable("a", "1sec.ond");
            func.AddSetVariable("b", "first");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringSecondWithStringSecondWithVariable_IsCorrect()
        {
            func.Function = "a != b";
            func.AddSetVariable("a", "1sec.ond");
            func.AddSetVariable("b", "1sec.ond");
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void NotEqualStringOperator_MalformedExpressionStringFirstLeftOfOperator_ThrowsException()
        {
            func.Function = "'first' !=";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void NotEqualStringOperator_MalformedExpressionStringSecondLeftOfOperator_ThrowsException()
        {
            func.Function = "'1sec.ond' !=";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void NotEqualStringOperator_MalformedExpressionStringFirstRightOfOperator_ThrowsException()
        {
            func.Function = "!= 'first'";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void NotEqualStringOperator_MalformedExpressionStringSecondRightOfOperator_ThrowsException()
        {
            func.Function = "!= '1sec.ond'";
        }

    }
}

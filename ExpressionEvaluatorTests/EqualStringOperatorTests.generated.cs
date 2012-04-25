// ReSharper disable InconsistentNaming
using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class EqualStringOperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }
        
        [Test]
        public void EqualStringOperator_StringFirstWithStringFirst_IsCorrect()
        {
            func.Function = "'first' == 'first'";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringFirstWithStringSecond_IsCorrect()
        {
            func.Function = "'first' == 'second'";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringFirst_IsCorrect()
        {
            func.Function = "'second' == 'first'";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringSecond_IsCorrect()
        {
            func.Function = "'second' == 'second'";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringFirstWithStringFirstWithLeftVariable_IsCorrect()
        {
            func.Function = "a == 'first'";
			func.AddSetVariable("a", "first");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringFirstWithStringSecondWithLeftVariable_IsCorrect()
        {
            func.Function = "a == 'second'";
			func.AddSetVariable("a", "first");
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringFirstWithLeftVariable_IsCorrect()
        {
            func.Function = "a == 'first'";
			func.AddSetVariable("a", "second");
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringSecondWithLeftVariable_IsCorrect()
        {
            func.Function = "a == 'second'";
			func.AddSetVariable("a", "second");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringFirstWithStringFirstWithRightVariable_IsCorrect()
        {
            func.Function = "'first' == a";
			func.AddSetVariable("a", "first");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringFirstWithStringSecondWithRightVariable_IsCorrect()
        {
            func.Function = "'first' == a";
			func.AddSetVariable("a", "second");
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringFirstWithRightVariable_IsCorrect()
        {
            func.Function = "'second' == a";
			func.AddSetVariable("a", "first");
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringSecondWithRightVariable_IsCorrect()
        {
            func.Function = "'second' == a";
			func.AddSetVariable("a", "second");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringFirstWithStringFirstWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", "first");
			func.AddSetVariable("b", "first");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringFirstWithStringSecondWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", "first");
			func.AddSetVariable("b", "second");
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringFirstWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", "second");
			func.AddSetVariable("b", "first");
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringSecondWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", "second");
			func.AddSetVariable("b", "second");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void EqualStringOperator_MalformedExpressionStringFirstLeftOfOperator_ThrowsException()
        {
            func.Function = "'first' ==";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void EqualStringOperator_MalformedExpressionStringSecondLeftOfOperator_ThrowsException()
        {
            func.Function = "'second' ==";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void EqualStringOperator_MalformedExpressionStringFirstRightOfOperator_ThrowsException()
        {
            func.Function = "== 'first'";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void EqualStringOperator_MalformedExpressionStringSecondRightOfOperator_ThrowsException()
        {
            func.Function = "== 'second'";
        }

    }
}

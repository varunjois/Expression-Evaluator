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
            func.Function = "'first' == '1sec.ond'";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringFirst_IsCorrect()
        {
            func.Function = "'1sec.ond' == 'first'";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringSecond_IsCorrect()
        {
            func.Function = "'1sec.ond' == '1sec.ond'";
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
            func.Function = "a == '1sec.ond'";
			func.AddSetVariable("a", "first");
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringFirstWithLeftVariable_IsCorrect()
        {
            func.Function = "a == 'first'";
			func.AddSetVariable("a", "1sec.ond");
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringSecondWithLeftVariable_IsCorrect()
        {
            func.Function = "a == '1sec.ond'";
			func.AddSetVariable("a", "1sec.ond");
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
			func.AddSetVariable("a", "1sec.ond");
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringFirstWithRightVariable_IsCorrect()
        {
            func.Function = "'1sec.ond' == a";
			func.AddSetVariable("a", "first");
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringSecondWithRightVariable_IsCorrect()
        {
            func.Function = "'1sec.ond' == a";
			func.AddSetVariable("a", "1sec.ond");
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
			func.AddSetVariable("b", "1sec.ond");
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringFirstWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", "1sec.ond");
			func.AddSetVariable("b", "first");
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void EqualStringOperator_StringSecondWithStringSecondWithVariable_IsCorrect()
        {
            func.Function = "a == b";
			func.AddSetVariable("a", "1sec.ond");
			func.AddSetVariable("b", "1sec.ond");
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
            func.Function = "'1sec.ond' ==";
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
            func.Function = "== '1sec.ond'";
        }

    }
}

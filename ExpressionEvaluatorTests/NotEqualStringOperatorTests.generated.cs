// ReSharper disable InconsistentNaming
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
            func.Function = "'first' != 'second'";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringSecondWithStringFirst_IsCorrect()
        {
            func.Function = "'second' != 'first'";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringSecondWithStringSecond_IsCorrect()
        {
            func.Function = "'second' != 'second'";
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
            func.Function = "a != 'second'";
			func.AddSetVariable("a", "first");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringSecondWithStringFirstWithLeftVariable_IsCorrect()
        {
            func.Function = "a != 'first'";
			func.AddSetVariable("a", "second");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringSecondWithStringSecondWithLeftVariable_IsCorrect()
        {
            func.Function = "a != 'second'";
			func.AddSetVariable("a", "second");
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
			func.AddSetVariable("a", "second");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringSecondWithStringFirstWithRightVariable_IsCorrect()
        {
            func.Function = "'second' != a";
			func.AddSetVariable("a", "first");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringSecondWithStringSecondWithRightVariable_IsCorrect()
        {
            func.Function = "'second' != a";
			func.AddSetVariable("a", "second");
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
			func.AddSetVariable("b", "second");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringSecondWithStringFirstWithVariable_IsCorrect()
        {
            func.Function = "a != b";
			func.AddSetVariable("a", "second");
			func.AddSetVariable("b", "first");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqualStringOperator_StringSecondWithStringSecondWithVariable_IsCorrect()
        {
            func.Function = "a != b";
			func.AddSetVariable("a", "second");
			func.AddSetVariable("b", "second");
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
            func.Function = "'second' !=";
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
            func.Function = "!= 'second'";
        }

    }
}

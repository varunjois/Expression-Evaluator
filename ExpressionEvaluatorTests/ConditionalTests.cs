// ReSharper disable InconsistentNaming
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vanderbilt.Biostatistics.Wfccm2;
using NUnit.Framework;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class ConditionalTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void IfElse_IfNoOperator_ExpressionException()
        {
            func.Function = @"if  {  } else { 1 }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void IfElse_IfNoExpression_ExpressionException()
        {
            func.Function = @"if (true)  {  } else { 1 }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void IfElse_ElseNoOperator_ExpressionException()
        {
            func.Function = @"if (true)  { 1  } else { }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "not in a correct format", MatchType = MessageMatch.Contains)]
        public void IfElse_IfStringOperator_ExpressionException()
        {
            func.Function = @"if ( val )  { 1 } else { 1 }";
            func.EvaluateNumeric();
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Conditional Error", MatchType = MessageMatch.Contains)]
        public void IfElse_OutOfOrder001_ExpressionException()
        {
            func.Function = @"else { 2 } if (true) { 1 }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Conditional Error", MatchType = MessageMatch.Contains)]
        public void IfElse_OutOfOrder003_ExpressionException()
        {
            func.Function = @"if (true) { 2 } if else (true) { 1 }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Conditional Error", MatchType = MessageMatch.Contains)]
        public void IfElse_IfElseMismatch001_ExpressionException()
        {
            func.Function = @"if (true) { 2 } else if { 1 }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Conditional Error", MatchType = MessageMatch.Contains)]
        public void IfElse_IfElseMismatch002_ExpressionException()
        {
            func.Function = @"if (true) { 2 } else if (true) { 1 }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Conditional Error", MatchType = MessageMatch.Contains)]
        public void IfElse_ElseWithBoolean001_ExpressionException()
        {
            func.Function = @"if (true) { 2 } else (true) { 1 }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Conditional Error", MatchType = MessageMatch.Contains)]
        public void IfElse_ElseWithBoolean002_ExpressionException()
        {
            func.Function = @"if (true) { 2 } else if (true) { 1 } else (true) { 1 }";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Conditional Error", MatchType = MessageMatch.Contains)]
        public void IfElse_NestedElseWithBoolean001_ExpressionException()
        {
            func.Function = @"if (true) { if (true) { 3 } else (true) { 2 } } else { 1 }";
        }

        [Test]
        public void IfElse_CorrectFormat001_IsCorrect()
        {
            func.Function = "if (true) { 1 } else { 2 }";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_CorrectFormat002_IsCorrect()
        {
            func.Function = "if (false) { 1 } else { 2 }";
            Assert.AreEqual(2, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_CorrectFormat003_IsCorrect()
        {
            func.Function = "5 + if (true) { 1 } else { 2 }";
            // 5 true 1 if 2 else +
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_ToInfix001_IsCorrect()
        {
            func.Function = "5 + if (true) { 1 } else { 2 }";
            Assert.AreEqual("5 true 1 if 2 else +", func.PostFix);
        }

        [Test]
        public void IfElse_CorrectFormat004_IsCorrect()
        {
            func.Function = "5 + if (false) { 1 } else { 2 }";
            Assert.AreEqual(7, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_WithElseIfCorrectFormat001_IsCorrect()
        {
            func.Function = "if (true) { 1 } else if (true) { 2 } else { 3 }";
            // true 1 if true 2 elseif 3 else 5 +
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_WithElseIfCorrectFormat002_IsCorrect()
        {
            func.Function = "5 + if (true) { 1 } else if (true) { 2 } else { 3 }";
            // true 1 if true 2 elseif 3 else 5 +
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_WithElseIfCorrectFormat003_IsCorrect()
        {
            func.Function = "if (false) { 1 } else if (true) { 2 } else { 3 }";
            Assert.AreEqual(2, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_WithElseIfCorrectFormat004_IsCorrect()
        {
            func.Function = "5 + if (false) { 1 } else if (true) { 2 } else { 3 }";
            // true 1 if true 2 elseif 3 else 5 +
            Assert.AreEqual(7, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_WithElseIfCorrectFormat005_IsCorrect()
        {
            func.Function = "if (false) { 1 } else if (false) { 2 } else { 3 }";
            Assert.AreEqual(3, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_WithElseIfCorrectFormat006_IsCorrect()
        {
            func.Function = "5 + if (false) { 1 } else if (false) { 2 } else { 3 }";
            // true 1 if true 2 elseif 3 else 5 +
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedCorrectFormat001_IsCorrect()
        {
            func.Function = "if (true) { if (true) { 1 } else { 2 } } else { 3 }";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedCorrectFormat002_IsCorrect()
        {
            func.Function = "5 + if (true) { if (false) { 1 } else { 2 } } else { 3 }";
            // 5 true  +
            Assert.AreEqual(7, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedCorrectFormat003_IsCorrect()
        {
            func.Function = "5 + if (true) { if (true) { 1 } else { 2 } } else { 3 }";
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedBoolean001_IsCorrect()
        {
            func.Function = "5 + if (8 > 1) { 1 } else { 2 }";
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedBoolean002_IsCorrect()
        {
            func.Function = "5 + if (8 > 1 || 8 < 10) { 1 } else { 2 }";
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedBooleanWithVariable001_IsCorrect()
        {
            func.Function = "5 + if (a > 1) { 1 } else { 2 }";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedBooleanWithVariable002_IsCorrect()
        {
            func.Function = "5 + if (a > 1 || a < 10) { 1 } else { 2 }";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(6, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedMathmaticalWithVariable001_IsCorrect()
        {
            func.Function = "5 + if (a > 1) { a + 1 } else { 2 }";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void IfElse_NestedMathmaticalWithVariable002_IsCorrect()
        {
            func.Function = "5 + if (a > 1 || a < 10) { a + 1 } else { a + 2 }";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException))]
        public void Grouping_OutOfOrder001_ExpressionException()
        {
            func.Function = @"if (true { ) 2 } else { 1 }";
        }

        [Test]
        public void Multiline_ValidExpression001_IsCorrect()
        {
            func.Function =
                "5 +" +
                Environment.NewLine +
                "if (a > 1 || a < 10)" +
                Environment.NewLine +
                "{ a + 1 }" +
                Environment.NewLine +
                "else" +
                Environment.NewLine +
                "{ a + 2 }";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }
    }
}

// ReSharper disable InconsistentNaming
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class PrecedanceTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void Precedance_AdditionSubtraction_IsCorrect()
        {
            func.Function = "2 + 3 - 2";
            Assert.AreEqual(3, func.EvaluateNumeric());
        }

        [Test]
        public void Precedance_SubtractionAddition_IsCorrect()
        {
            func.Function = "3 - 2 + 2";
            Assert.AreEqual(3, func.EvaluateNumeric());
        }

        [Test]
        public void Precedance_AdditionMultiplication_IsCorrect()
        {
            func.Function = "2 * 3 - 2";
            Assert.AreEqual(4, func.EvaluateNumeric());
        }

        [Test]
        public void Precedance_MultiplicationAddition_IsCorrect()
        {
            func.Function = "8 - 2 * 3";
            Assert.AreEqual(2, func.EvaluateNumeric());
        }
    }

    [TestFixture]
    public class OperatorTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void Ln_002()
        {
            func.Function = "ln(5) + 1";
            Assert.AreEqual(2.6094379124341005, func.EvaluateNumeric());
        }

        [Test]
        public void Ln_003()
        {
            func.Function = "ln(5) * 2";
            Assert.AreEqual(3.2188758248682006, func.EvaluateNumeric());
        }

        [Test]
        public void Sign003()
        {
            func.Function = "sign(0)";
            Assert.AreEqual(1, func.EvaluateNumeric());
        }

        [Test]
        public void Subtraction001()
        {
            func.Function = "-23";
            Assert.AreEqual(-23, func.EvaluateNumeric());
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MulitpleOperators_BadExpression001_ExpressionException()
        {
            func.Function = "1+(2*)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MulitpleOperators_BadExpression002_ExpressionException()
        {
            func.Function = "1/2*";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Expression formatted incorrecty", MatchType = MessageMatch.Contains)]
        public void MulitpleOperators_BadExpression005_ExpressionException()
        {
            func.Function = "1-(2+3)2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MulitpleOperators_BadExrpession006_ExpressionException()
        {
            func.Function = "+1/";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        public void MulitpleOperators_BadExpression007_ExpressionException()
        {
            func.Function = "1-2-3-3-2-";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Function error", MatchType = MessageMatch.Contains)]
        public void Negation_BadExpression001_ExpressionException()
        {
            func.Function = "9832 neg";
        }

    }
}

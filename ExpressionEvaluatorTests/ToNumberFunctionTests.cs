// ReSharper disable InconsistentNaming
using System;
using Vanderbilt.Biostatistics.Wfccm2;
using NUnit.Framework;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class ToNumberFunctionTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void ToNumberOperator_CalledWithPositiveWholeWithSpaces_IsCorrect()
        {
            func.Function = "toNumber(' 2 ')";
            NUnit.Framework.Assert.AreEqual(2.0f, func.EvaluateNumeric());
        }

        [Test]
        public void ToNumberOperator_ResultFromSubstringVariable_IsCorrect()
        {
            func.Function = "toNumber(substring(a, 1, length(a) - 1))";
            func.AddSetVariable("a", "<2.0");
            Assert.AreEqual(2.0f, func.EvaluateNumeric());
        }

        [Test]
        public void ToNumberOperator_CalledWithPositiveWhole_IsCorrect()
        {
            func.Function = "toNumber('2')";
            NUnit.Framework.Assert.AreEqual(2.0f, func.EvaluateNumeric());
        }

        [Test]
        public void ToNumberOperator_CalledWithPositiveDecimal_IsCorrect()
        {
            func.Function = "toNumber('2.3')";
            NUnit.Framework.Assert.AreEqual(2.3, func.EvaluateNumeric());
        }

        [Test]
        public void ToNumberOperator_CalledWithNegativeWhole_IsCorrect()
        {
            func.Function = "toNumber('-2')";
            NUnit.Framework.Assert.AreEqual(-2.0f, func.EvaluateNumeric());
        }

        [Test]
        public void ToNumberOperator_PositiveFractionWithLeftVariable_IsCorrect()
        {
            func.Function = "toNumber(a)";
            func.AddSetVariable("a", "0.5");
            NUnit.Framework.Assert.AreEqual(0.5d, func.EvaluateNumeric());
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(ExpressionException), ExpectedMessage = "ToNumber operator used incorrectly", MatchType = MessageMatch.Contains)]
        public void ToNumberOperator_PositiveFractionNotStringWithLeftVariable_IsNotCorrect()
        {
            func.Function = "toNumber(a)";
            func.AddSetVariable("a", 2.1);
            NUnit.Framework.Assert.AreEqual(2.1d, func.EvaluateNumeric());
        }

        [Test]
        public void ToNumberOperator_VariableNotStringButNotNumber_NaN()
        {
            func.Function = "toNumber(a)";
            func.AddSetVariable("a", "b");
            NUnit.Framework.Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(ExpressionException), ExpectedMessage = "ToNumber operator used incorrectly", MatchType = MessageMatch.Contains)]
        public void ToNumberOperator_VariableWithoutSetVariable_OperatorError()
        {
            func.Function = "toNumber(a)";
            func.EvaluateNumeric();
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(ExpressionException), ExpectedMessage = "ToNumber operator used incorrectly", MatchType = MessageMatch.Contains)]
        public void ToNumberOperator_VariableMixedWithDigitWithoutSetVariable_OperatorError()
        {
            func.Function = "toNumber(3a)";
            func.EvaluateNumeric();
        }

        [Test]
        public void ToNumber_IfValidElseWillThrowException_StillEvaluates()
        {
            func.Function = "if (true) { tonumber('2') } else { toNumber('a') }";
            Assert.AreEqual(2.0f, func.EvaluateNumeric());
        }

        [Test]
        public void ToNumber_IfWillThrowExceptionElseValid_StillEvaluates()
        {
            func.Function = "if (false) { tonumber('a') } else { toNumber('2') }";
            Assert.AreEqual(2.0f, func.EvaluateNumeric());
        }

    }
}

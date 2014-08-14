using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class SubstringFunctionTests
    {
        private Expression _func;

        [SetUp]
        public void Init()
        {
            _func = new Expression("");
        }

        [TearDown]
        public void Clear()
        {
            _func.Clear();
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(ExpressionException),
            ExpectedMessage =
                "One or more of the substring parameters contain decimals and not integers",
            MatchType = MessageMatch.Contains)]
        public void SubstringOperator_CalledWithFloat_IsNotCorrect()
        {
            _func.Function = "substring('hello', 0.1, 3)";
            _func.Evaluate<String>();
        }

        [Test]
        public void SubstringOperator_CalledWithIntegers_IsCorrect()
        {
            _func.Function = "substring('hello', 0, 3)";
            NUnit.Framework.Assert.AreEqual("hel", _func.Evaluate<String>());
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(ExpressionException),
            ExpectedMessage = "Operator error! \"substring\".", MatchType = MessageMatch.Contains)]
        public void SubstringOperator_CalledWithNegativeIndex_IsCorrect()
        {
            _func.Function = "substring('hello', -1, 3)";
            _func.Evaluate<String>();
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(InvalidTypeExpressionException),
            ExpectedMessage = "Result was null because of an invalid type",
            MatchType = MessageMatch.Contains)]
        public void SubstringOperator_ExecuteSubstringOnNonString_OperatorError()
        {
            _func.Function = "substring(3a, 0, 1)";
            _func.Evaluate<String>();
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(ExpressionException),
            ExpectedMessage =
                "One or more of the substring parameters contain decimals and not integers",
            MatchType = MessageMatch.Contains)]
        public void SubstringOperator_PositiveFractionNotIntegerWithLeftVariable_IsNotCorrect()
        {
            _func.Function = "substring('hello', 0, a)";
            _func.AddSetVariable("a", 2.1);
            _func.Evaluate<String>();
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(ExpressionException),
            ExpectedMessage = "Substring operator used incorrectly",
            MatchType = MessageMatch.Contains)]
        public void SubstringOperator_PositiveFractionWithLeftVariableOfWrongType_IsNotCorrect()
        {
            _func.Function = "substring('hello', 0, a)";
            _func.AddSetVariable("a", "b");
            _func.Evaluate<String>();
        }

        [Test]
        [NUnit.Framework.ExpectedException(typeof(InvalidTypeExpressionException),
            ExpectedMessage = "Result was null because of an invalid type",
            MatchType = MessageMatch.Contains)]
        public void SubstringOperator_VariableWithoutSetVariable_OperatorError()
        {
            _func.Function = "substring('hello', a, 2)";
            _func.Evaluate<String>();
        }
    }
}

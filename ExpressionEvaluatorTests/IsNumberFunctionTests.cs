// ReSharper disable InconsistentNaming
using System;
using Vanderbilt.Biostatistics.Wfccm2;
using NUnit.Framework;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class IsNumberFunctionTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void IsNumber_NumericStringInput_IsCorrect()
        {
            func.Function = "isNumber('2')";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void IsNumber_NumericInputWithSpaces_IsCorrect()
        {
            func.Function = "isNumber( ' 2 ' )";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void IsNumber_VariableIsNumeric_IsCorrect()
        {
            func.Function = "isNumber(a)";
            func.AddSetVariable("a", "2");
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void IsNumber_NotANumber_IsCorrect()
        {
            func.Function = "isNumber('blah')";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void IsNumber_Null_IsCorrect()
        {
            func.Function = "isNumber(a)";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

    }
}

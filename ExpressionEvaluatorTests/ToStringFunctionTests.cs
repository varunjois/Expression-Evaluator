// ReSharper disable InconsistentNaming

using System;
using Vanderbilt.Biostatistics.Wfccm2;
using NUnit.Framework;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class ToStringFunctionTests
    {
        Expression func;

        [SetUp]
        public void init()
        { func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }


        [Test]
        public void ToStringOperator_NumericInput_IsCorrect()
        {
            func.Function = "toString(2)";
            Assert.AreEqual("2", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_NumericInputWithSpaces_IsCorrect()
        {
            func.Function = "toString( 2 )";
            Assert.AreEqual("2", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_VariableIsNumeric_IsCorrect()
        {
            func.Function = "toString(a)";
            func.AddSetVariable("a", 2);
            Assert.AreEqual("2", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_BooleanInput_IsCorrect()
        {
            func.Function = "toString(true)";
            Assert.AreEqual("True", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_BooleanInputWithSpaces_IsCorrect()
        {
            func.Function = "toString( true )";
            Assert.AreEqual("True", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_VariableIsBoolean_IsCorrect()
        {
            func.Function = "toString(a)";
            func.AddSetVariable("a", true);
            Assert.AreEqual("True", func.Evaluate<string>());
        }
        
        [Test]
        public void ToStringOperator_VariableIsDateTime_IsCorrect()
        {
            var dt = DateTime.Now;
            func.Function = "toString(a)";
            func.AddSetVariable("a", dt);
            Assert.AreEqual(dt.ToString(), func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_StringInput_IsCorrect()
        {
            func.Function = "toString('test')";
            Assert.AreEqual("test", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_StringInputWithSpaces_IsCorrect()
        {
            func.Function = "toString( 'test' )";
            Assert.AreEqual("test", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_VariableIsString_IsCorrect()
        {
            func.Function = "toString(a)";
            func.AddSetVariable("a", "test");
            Assert.AreEqual("test", func.Evaluate<string>());
        }

        [Test]
        public void ToStringOperator_VariableIsNull_IsCorrect()
        {
            func.Function = "toString(a)";
            Assert.AreEqual("null", func.Evaluate<string>());
        }
    }
}

// ReSharper disable InconsistentNaming
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class NullVariableTests
    {
        private Expression func;

        [SetUp]
        public void init() { this.func = new Expression(""); }

        [TearDown]
        public void clear() { func.Clear(); }

        [Test]
        public void ValidFunctionWithTwoVariables_VariablesNull_NANReturned()
        {
            func.Function = "a + b";
            Assert.AreEqual(double.NaN, func.EvaluateNumeric());
        }

        [Test]
        public void ValidFunctionWithVariablesAndIfThenNotEquals_VariableNull_CorrectValueReturned()
        {
            func.Function = "if (a != null) { a + 1 } else { 0 }";
            Assert.AreEqual(0, func.EvaluateNumeric());
        }

        [Test]
        public void ValidFunctionWithVariablesAndIfThenNotEquals_VariableNotNull_CorrectValueReturned()
        {
            func.Function = "if (a != null) { a + 1 } else { 0 }";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(3, func.EvaluateNumeric());
        }

        [Test]
        public void ValidFunctionWithVariablesAndIfThenEquals_VariableNull_CorrectValueReturned()
        {
            func.Function = "if (a == null) { 0 } else { a + 1 }";
            Assert.AreEqual(0, func.EvaluateNumeric());
        }

        [Test]
        public void ValidFunctionWithVariablesAndIfThenEquals_VariableNotNull_CorrectValueReturned()
        {
            func.Function = "if (a == null) { 0 } else { a + 1 }";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(3, func.EvaluateNumeric());
        }

        [Test]
        public void ValidFunctionWithVariablesAndIfThenEquals_MultipleVairable_CorrectValueReturned()
        {
            func.Function = "if (a == null) { 0 } else { a } + if (b == null) { 0 } else { b }";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 2);
            Assert.AreEqual(4, func.EvaluateNumeric());
        }

        [Test]
        public void ValidFunctionWithVariablesAndIfThenEquals_MultipleVairableOneNull_CorrectValueReturned()
        {
            func.Function = "if (a == null) { 0 } else { a } + if (b == null) { 0 } else { b }";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(2, func.EvaluateNumeric());
        }
    }
}
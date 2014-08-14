using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class NullVariableTests
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
        public void ValidFunctionWithTwoVariables_VariablesNull_NANReturned()
        {
            _func.Function = "a + b";
            Assert.AreEqual(double.NaN, _func.EvaluateNumeric());
        }

        [Test]
        public void
            ValidFunctionWithVariablesAndIfThenEquals_MultipleVairableOneNull_CorrectValueReturned()
        {
            _func.Function = "if (a == null) { 0 } else { a } + if (b == null) { 0 } else { b }";
            _func.AddSetVariable("a", 2);
            Assert.AreEqual(2, _func.EvaluateNumeric());
        }

        [Test]
        public void ValidFunctionWithVariablesAndIfThenEquals_MultipleVairable_CorrectValueReturned()
        {
            _func.Function = "if (a == null) { 0 } else { a } + if (b == null) { 0 } else { b }";
            _func.AddSetVariable("a", 2);
            _func.AddSetVariable("b", 2);
            Assert.AreEqual(4, _func.EvaluateNumeric());
        }

        [Test]
        public void ValidFunctionWithVariablesAndIfThenEquals_VariableNotNull_CorrectValueReturned()
        {
            _func.Function = "if (a == null) { 0 } else { a + 1 }";
            _func.AddSetVariable("a", 2);
            Assert.AreEqual(3, _func.EvaluateNumeric());
        }

        [Test]
        public void ValidFunctionWithVariablesAndIfThenEquals_VariableNull_CorrectValueReturned()
        {
            _func.Function = "if (a == null) { 0 } else { a + 1 }";
            Assert.AreEqual(0, _func.EvaluateNumeric());
        }

        [Test]
        public void
            ValidFunctionWithVariablesAndIfThenNotEquals_VariableNotNull_CorrectValueReturned()
        {
            _func.Function = "if (a != null) { a + 1 } else { 0 }";
            _func.AddSetVariable("a", 2);
            Assert.AreEqual(3, _func.EvaluateNumeric());
        }

        [Test]
        public void ValidFunctionWithVariablesAndIfThenNotEquals_VariableNull_CorrectValueReturned()
        {
            _func.Function = "if (a != null) { a + 1 } else { 0 }";
            Assert.AreEqual(0, _func.EvaluateNumeric());
        }
    }
}

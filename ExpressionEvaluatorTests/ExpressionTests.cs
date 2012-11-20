using Vanderbilt.Biostatistics.Wfccm2;
using NUnit.Framework;

namespace ExpressionEvaluatorTests
{
    /// <summary>
    /// Summary description for ExpressionTests
    /// </summary>
    [TestFixture]
    public class ExpressionTest
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void Add_SimpleTest_ValueIsCorrect()
        {
            func.Function = "1+2";
            Assert.AreEqual(true, double.IsNaN(func.GetVariableValue("a")));
            Assert.AreEqual(3, func.EvaluateNumeric());
        }

        [Test]
        public void ClearVariables_Call_VariableAreCleared()
        {
            func.Function = "a+b";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            func.ClearVariables();
            Assert.AreEqual(true, double.IsNaN(func.GetVariableValue("a")));
            Assert.AreEqual(true, double.IsNaN(func.GetVariableValue("b")));
        }

        [Test]
        public void Variable_SetThenChanged_IsCorrect()
        {
            func.Function = "a+b";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual(2, func.GetVariableValue("a"));
            Assert.AreEqual(3, func.GetVariableValue("b"));

            func.AddSetVariable("a", 3);
            func.AddSetVariable("b", 4);
            Assert.AreEqual(3, func.GetVariableValue("a"));
            Assert.AreEqual(4, func.GetVariableValue("b"));
        }

        [Test]
        public void Variable002()
        {
            func.Function = "a+b";
            Assert.AreEqual(true, double.IsNaN(func.GetVariableValue("a")));
            Assert.AreEqual(true, double.IsNaN(func.GetVariableValue("b")));
        }

        [Test]
        public void ToString001()
        {
            func.Function = "a + b";
            Assert.AreEqual("a + b; a=null, b=null", func.ToString());
        }

        [Test]
        public void ToString002()
        {
            func.Function = "a + b";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual("a + b; a=2, b=3", func.ToString());
        }

        [Test]
        public void PostFix001()
        {
            func.Function = "a + b";
            Assert.AreEqual("a b +", func.PostFix);
        }

        [Test]
        public void PostFix002()
        {
            func.Function = "a+b";
            Assert.AreEqual("a b +", func.PostFix);
        }

        [Test]
        public void InFix001()
        {
            func.Function = "a+b";
            Assert.AreEqual("a + b", func.InFix);
        }

        [Test]
        public void InFix002()
        {
            func.Function = "a+ b";
            Assert.AreEqual("a + b", func.InFix);
        }

        [Test]
        public void InFix003()
        {
            func.Function = "a +b";
            Assert.AreEqual("a + b", func.InFix);
        }

        [Test]
        public void InFix004()
        {
            func.Function = "a + b";
            Assert.AreEqual("a + b", func.InFix);
        }

        [Test]
        public void InFix005()
        {
            func.Function = "a+b-2*3/66*sign(-3)+abs(-16)^3";
            Assert.AreEqual("a + b - 2 * 3 / 66 * sign ( -3 ) + abs ( -16 ) ^ 3", func.InFix);
        }

        [Test]
        public void PostFix003()
        {
            func.Function = "a+b - 2";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual("a b + 2 -", func.PostFix);
        }

        [Test]
        public void Function001()
        {
            func.Function = "a+b - 2";
            Assert.AreEqual("a+b - 2", func.Function);
        }

        [Test]
        public void Function002()
        {
            func.Function = "a +b - 2";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual("a +b - 2", func.Function);
        }

        [Test]
        public void Function003()
        {
            func.Function = "a + b - 2";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual("a + b - 2", func.Function);
        }

        [Test]
        public void DivideByZero_EvaluateFunction001_IsNotANumber()
        {
            func.Function = "2/0";
            Assert.AreEqual(true, double.IsNaN(func.EvaluateNumeric()));
        }

        [Test]
        public void DivideByZero_EvaluateFunction002_IsNotANumber()
        {
            func.Function = "2/(1-1)";
            Assert.AreEqual(true, double.IsNaN(func.EvaluateNumeric()));
        }

        [Test]
        public void Evaulate_CheckFloatingPointErrors_IsCorrect()
        {
            func.Function = "99.999999999999/100";
            Assert.AreEqual(0.99999999999999, func.EvaluateNumeric());
        }

        [Test]
        public void Power_PositivePower_IsCorrect()
        {
            func.Function = "2^2";
            Assert.AreEqual(4, func.EvaluateNumeric());
        }

        [Test]
        public void Power_PositiveWholeNegativePower_IsCorrect()
        {
            func.Function = "2^-2";
            Assert.AreEqual(0.25, func.EvaluateNumeric());
        }

    }

}


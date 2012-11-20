using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class VariableTests
    {
        Expression _func;

        [SetUp]
        public void init()
        { this._func = new Expression(""); }

        [TearDown]
        public void clear()
        { _func.Clear(); }

        [Test]
        public void VariableList_HasVariableNotSet_IsInList()
        {
            _func.Function = "a";
            Assert.IsTrue(_func.FunctionVariables.Contains("a"));
        }

        [Test]
        public void VariableList_HasNumericVariableSet_IsInList()
        {
            _func.Function = "a";
            _func.AddSetVariable("a", 2);
            Assert.IsTrue(_func.FunctionVariables.Contains("a"));
        }

        [Test]
        public void VariableList_HasNumericVariableSet_CountCorrect()
        {
            _func.Function = "a";
            _func.AddSetVariable("a", 2);
            Assert.AreEqual(1, _func.FunctionVariables.Count);
        }

        [Test]
        public void VariableList_HasStringVariableSet_IsInList()
        {
            _func.Function = "a";
            _func.AddSetVariable("a", "2");
            Assert.IsTrue(_func.FunctionVariables.Contains("a"));
        }

        [Test]
        public void VariableList_HasStringVariableSet_CountCorrect()
        {
            _func.Function = "a";
            _func.AddSetVariable("a", "2");
            Assert.AreEqual(1, _func.FunctionVariables.Count);
        }

        [Test]
        public void VariableList_HasNumericValue_CountCorrect()
        {
            _func.Function = "1";
            Assert.AreEqual(0, _func.FunctionVariables.Count);
        }

        [Test]
        public void VariableList_HasStringValue_CountCorrect()
        {
            _func.Function = "'1'";
            Assert.AreEqual(0, _func.FunctionVariables.Count);
        }

        [Test]
        public void EvaluationWithVariables001()
        {
            _func.Function = "a^3";
            _func.AddSetVariable("a", 2);
            Assert.AreEqual(8, _func.EvaluateNumeric());
        }

        [Test]
        public void EvaluationWithVariables002()
        {
            _func.Function = "a^b";
            _func.AddSetVariable("a", 2);
            _func.AddSetVariable("b", 3);
            Assert.AreEqual(8, _func.EvaluateNumeric());
        }

        [Test]
        public void EvaluationWithVariables003()
        {
            _func.Function = "a^2";
            _func.AddSetVariable("a", 2);
            _func.AddSetVariable("a", 3);
            Assert.AreEqual(9, _func.EvaluateNumeric());
        }

        [Test]
        public void EvaluationWithVariables004()
        {
            _func.Function = "a^b";
            _func.AddSetVariable("a", 2);
            _func.AddSetVariable("a", 3);
            _func.AddSetVariable("b", 2);
            _func.AddSetVariable("b", 3);
            Assert.AreEqual(27, _func.EvaluateNumeric());
        }

        [Test]
        public void EvaluationWithVariables005()
        {
            _func.Function = "(a^b)/2";
            _func.AddSetVariable("a", 4);
            _func.AddSetVariable("b", 2);
            Assert.AreEqual(8, _func.EvaluateNumeric());
        }

        [Test]
        public void VariableNames_WithNumbers_SetsCorrectly()
        {
            _func.Function = "a118+2";
            _func.AddSetVariable("a118", 6);
            Assert.AreEqual(8, _func.EvaluateNumeric());
        }

        [Test]
        public void VariableNames_ContainsSign_SetsCorrectly()
        {
            _func.Function = "signature+2";
            _func.AddSetVariable("signature", 6);
            Assert.AreEqual(8, _func.EvaluateNumeric());
        }

        [Test]
        public void VariableNames_ContainsAbs_SetsCorrectly()
        {
            _func.Function = "absolute+2";
            _func.AddSetVariable("absolute", 6);
            Assert.AreEqual(8, _func.EvaluateNumeric());
        }

        [Test]
        public void VariableNames_ContainsLn_SetsCorrectly()
        {
            _func.Function = "pillname+2";
            _func.AddSetVariable("pillname", 6);
            Assert.AreEqual(8, _func.EvaluateNumeric());
        }

        [Test]
        public void NumericalBooleanEvaluation013()
        {
            _func.Function = "4 > abs(neg (5.2))";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void NumericalBooleanEvaluation014()
        {
            _func.Function = "4 > abs(neg (3.2))";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NumericalBooleanEvaluation015()
        {
            _func.Function = "4 > neg(abs(5.2))";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqual_ValidExpression001_IsCorrect()
        {
            _func.Function = "4 != 5.2";
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void NotEqual_ValidExpression002_IsCorrect()
        {
            _func.Function = "4 != 4";
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables001()
        {
            _func.Function = "a == 4";
            _func.AddSetVariable("a", 4);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables002()
        {
            _func.Function = "a == b";
            _func.AddSetVariable("a", 4);
            _func.AddSetVariable("b", 4);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables003()
        {
            _func.Function = "a != b";
            _func.AddSetVariable("a", 4);
            _func.AddSetVariable("b", 4);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables004()
        {
            _func.Function = "a && b";
            _func.AddSetVariable("a", true);
            _func.AddSetVariable("b", true);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables005()
        {
            _func.Function = "a && b";
            _func.AddSetVariable("a", true);
            _func.AddSetVariable("b", false);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables006()
        {
            _func.Function = "a && b";
            _func.AddSetVariable("a", false);
            _func.AddSetVariable("b", false);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables007()
        {
            _func.Function = "a && b";
            _func.AddSetVariable("a", true);
            _func.AddSetVariable("b", false);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables008()
        {
            _func.Function = "a || b";
            _func.AddSetVariable("a", true);
            _func.AddSetVariable("b", true);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables009()
        {
            _func.Function = "a || b";
            _func.AddSetVariable("a", true);
            _func.AddSetVariable("b", false);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables010()
        {
            _func.Function = "a || b";
            _func.AddSetVariable("a", false);
            _func.AddSetVariable("b", false);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables011()
        {
            _func.Function = "a || b && c || d";
            _func.AddSetVariable("a", true);
            _func.AddSetVariable("b", false);
            _func.AddSetVariable("c", true);
            _func.AddSetVariable("d", false);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables012()
        {
            _func.Function = "a || b && c || d";
            _func.AddSetVariable("a", true);
            _func.AddSetVariable("b", false);
            _func.AddSetVariable("c", false);
            _func.AddSetVariable("d", false);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables014()
        {
            _func.Function = "(a || b) && (c || d)";
            _func.AddSetVariable("a", true);
            _func.AddSetVariable("b", false);
            _func.AddSetVariable("c", true);
            _func.AddSetVariable("d", false);
            Assert.AreEqual(true, _func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables015()
        {
            _func.Function = "(a || b) && (c || d)";
            _func.AddSetVariable("a", true);
            _func.AddSetVariable("b", false);
            _func.AddSetVariable("c", false);
            _func.AddSetVariable("d", false);
            Assert.AreEqual(false, _func.EvaluateBoolean());
        }

    }
}

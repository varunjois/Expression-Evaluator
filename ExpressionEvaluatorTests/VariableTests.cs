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
    public class VariableTests
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void VariableList_HasVariableNotSet_IsInList()
        {
            func.Function = "a";
            Assert.IsTrue(func.FunctionVariables.Contains("a"));
        }

        [Test]
        public void VariableList_HasNumericVariableSet_IsInList()
        {
            func.Function = "a";
            func.AddSetVariable("a", 2);
            Assert.IsTrue(func.FunctionVariables.Contains("a"));
        }

        [Test]
        public void VariableList_HasNumericVariableSet_CountCorrect()
        {
            func.Function = "a";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(1, func.FunctionVariables.Count);
        }

        [Test]
        public void VariableList_HasStringVariableSet_IsInList()
        {
            func.Function = "a";
            func.AddSetVariable("a", "2");
            Assert.IsTrue(func.FunctionVariables.Contains("a"));
        }

        [Test]
        public void VariableList_HasStringVariableSet_CountCorrect()
        {
            func.Function = "a";
            func.AddSetVariable("a", "2");
            Assert.AreEqual(1, func.FunctionVariables.Count);
        }

        [Test]
        public void VariableList_HasNumericValue_CountCorrect()
        {
            func.Function = "1";
            Assert.AreEqual(0, func.FunctionVariables.Count);
        }

        [Test]
        public void VariableList_HasStringValue_CountCorrect()
        {
            func.Function = "'1'";
            Assert.AreEqual(0, func.FunctionVariables.Count);
        }

        [Test]
        public void EvaluationWithVariables001()
        {
            func.Function = "a^3";
            func.AddSetVariable("a", 2);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void EvaluationWithVariables002()
        {
            func.Function = "a^b";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void EvaluationWithVariables003()
        {
            func.Function = "a^2";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("a", 3);
            Assert.AreEqual(9, func.EvaluateNumeric());
        }

        [Test]
        public void EvaluationWithVariables004()
        {
            func.Function = "a^b";
            func.AddSetVariable("a", 2);
            func.AddSetVariable("a", 3);
            func.AddSetVariable("b", 2);
            func.AddSetVariable("b", 3);
            Assert.AreEqual(27, func.EvaluateNumeric());
        }

        [Test]
        public void EvaluationWithVariables005()
        {
            func.Function = "(a^b)/2";
            func.AddSetVariable("a", 4);
            func.AddSetVariable("b", 2);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void VariableNames_WithNumbers_SetsCorrectly()
        {
            func.Function = "a118+2";
            func.AddSetVariable("a118", 6);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void VariableNames_ContainsSign_SetsCorrectly()
        {
            func.Function = "signature+2";
            func.AddSetVariable("signature", 6);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void VariableNames_ContainsAbs_SetsCorrectly()
        {
            func.Function = "absolute+2";
            func.AddSetVariable("absolute", 6);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void VariableNames_ContainsLn_SetsCorrectly()
        {
            func.Function = "pillname+2";
            func.AddSetVariable("pillname", 6);
            Assert.AreEqual(8, func.EvaluateNumeric());
        }

        [Test]
        public void NumericalBooleanEvaluation013()
        {
            func.Function = "4 > abs(neg (5.2))";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NumericalBooleanEvaluation014()
        {
            func.Function = "4 > abs(neg (3.2))";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NumericalBooleanEvaluation015()
        {
            func.Function = "4 > neg(abs(5.2))";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqual_ValidExpression001_IsCorrect()
        {
            func.Function = "4 != 5.2";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqual_ValidExpression002_IsCorrect()
        {
            func.Function = "4 != 4";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables001()
        {
            func.Function = "a == 4";
            func.AddSetVariable("a", 4);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables002()
        {
            func.Function = "a == b";
            func.AddSetVariable("a", 4);
            func.AddSetVariable("b", 4);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables003()
        {
            func.Function = "a != b";
            func.AddSetVariable("a", 4);
            func.AddSetVariable("b", 4);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables004()
        {
            func.Function = "a && b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", true);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables005()
        {
            func.Function = "a && b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables006()
        {
            func.Function = "a && b";
            func.AddSetVariable("a", false);
            func.AddSetVariable("b", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables007()
        {
            func.Function = "a && b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables008()
        {
            func.Function = "a || b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", true);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables009()
        {
            func.Function = "a || b";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables010()
        {
            func.Function = "a || b";
            func.AddSetVariable("a", false);
            func.AddSetVariable("b", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables011()
        {
            func.Function = "a || b && c || d";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            func.AddSetVariable("c", true);
            func.AddSetVariable("d", false);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables012()
        {
            func.Function = "a || b && c || d";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            func.AddSetVariable("c", false);
            func.AddSetVariable("d", false);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables014()
        {
            func.Function = "(a || b) && (c || d)";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            func.AddSetVariable("c", true);
            func.AddSetVariable("d", false);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void BooleanEvaluationWithVariables015()
        {
            func.Function = "(a || b) && (c || d)";
            func.AddSetVariable("a", true);
            func.AddSetVariable("b", false);
            func.AddSetVariable("c", false);
            func.AddSetVariable("d", false);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

    }
}

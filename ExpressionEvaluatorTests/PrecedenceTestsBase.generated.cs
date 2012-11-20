// ReSharper disable InconsistentNaming
using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class PrecedenceTestsBase
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void Precedence_AdditionAddition_IsCorrect()
        {
            func.Function = "3+7+11";
            Assert.AreEqual(3d+7d+11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_AdditionMultiplication_IsCorrect()
        {
            func.Function = "3+7*11";
            Assert.AreEqual(3d+7d*11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_AdditionSubtraction_IsCorrect()
        {
            func.Function = "3+7-11";
            Assert.AreEqual(3d+7d-11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_AdditionDivision_IsCorrect()
        {
            func.Function = "3+7/11";
            Assert.AreEqual(3d+7d/11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_MultiplicationAddition_IsCorrect()
        {
            func.Function = "3*7+11";
            Assert.AreEqual(3d*7d+11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_MultiplicationMultiplication_IsCorrect()
        {
            func.Function = "3*7*11";
            Assert.AreEqual(3d*7d*11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_MultiplicationSubtraction_IsCorrect()
        {
            func.Function = "3*7-11";
            Assert.AreEqual(3d*7d-11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_MultiplicationDivision_IsCorrect()
        {
            func.Function = "3*7/11";
            Assert.AreEqual(3d*7d/11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_SubtractionAddition_IsCorrect()
        {
            func.Function = "3-7+11";
            Assert.AreEqual(3d-7d+11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_SubtractionMultiplication_IsCorrect()
        {
            func.Function = "3-7*11";
            Assert.AreEqual(3d-7d*11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_SubtractionSubtraction_IsCorrect()
        {
            func.Function = "3-7-11";
            Assert.AreEqual(3d-7d-11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_SubtractionDivision_IsCorrect()
        {
            func.Function = "3-7/11";
            Assert.AreEqual(3d-7d/11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_DivisionAddition_IsCorrect()
        {
            func.Function = "3/7+11";
            Assert.AreEqual(3d/7d+11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_DivisionMultiplication_IsCorrect()
        {
            func.Function = "3/7*11";
            Assert.AreEqual(3d/7d*11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_DivisionSubtraction_IsCorrect()
        {
            func.Function = "3/7-11";
            Assert.AreEqual(3d/7d-11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_DivisionDivision_IsCorrect()
        {
            func.Function = "3/7/11";
            Assert.AreEqual(3d/7d/11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_AdditionPower_IsCorrect()
        {
            func.Function = "3+7^11";
            Assert.AreEqual(3d+Math.Pow(7d, 11d), func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_PowerAddition_IsCorrect()
        {
            func.Function = "3^7+11";
            Assert.AreEqual(Math.Pow(3d, 7d)+11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_MultiplicationPower_IsCorrect()
        {
            func.Function = "3*7^11";
            Assert.AreEqual(3d*Math.Pow(7d, 11d), func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_PowerMultiplication_IsCorrect()
        {
            func.Function = "3^7*11";
            Assert.AreEqual(Math.Pow(3d, 7d)*11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_SubtractionPower_IsCorrect()
        {
            func.Function = "3-7^11";
            Assert.AreEqual(3d-Math.Pow(7d, 11d), func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_PowerSubtraction_IsCorrect()
        {
            func.Function = "3^7-11";
            Assert.AreEqual(Math.Pow(3d, 7d)-11d, func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_DivisionPower_IsCorrect()
        {
            func.Function = "3/7^11";
            Assert.AreEqual(3d/Math.Pow(7d, 11d), func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_PowerDivision_IsCorrect()
        {
            func.Function = "3^7/11";
            Assert.AreEqual(Math.Pow(3d, 7d)/11d, func.EvaluateNumeric());
        }

    }
}

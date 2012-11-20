using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class PrecedenceTestsBase
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void Precedence_AdditionAddition_IsCorrect()
        {
            _func.Function = "3+7+11";
            Assert.AreEqual(3d+7d+11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_AdditionMultiplication_IsCorrect()
        {
            _func.Function = "3+7*11";
            Assert.AreEqual(3d+7d*11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_AdditionSubtraction_IsCorrect()
        {
            _func.Function = "3+7-11";
            Assert.AreEqual(3d+7d-11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_AdditionDivision_IsCorrect()
        {
            _func.Function = "3+7/11";
            Assert.AreEqual(3d+7d/11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_MultiplicationAddition_IsCorrect()
        {
            _func.Function = "3*7+11";
            Assert.AreEqual(3d*7d+11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_MultiplicationMultiplication_IsCorrect()
        {
            _func.Function = "3*7*11";
            Assert.AreEqual(3d*7d*11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_MultiplicationSubtraction_IsCorrect()
        {
            _func.Function = "3*7-11";
            Assert.AreEqual(3d*7d-11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_MultiplicationDivision_IsCorrect()
        {
            _func.Function = "3*7/11";
            Assert.AreEqual(3d*7d/11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_SubtractionAddition_IsCorrect()
        {
            _func.Function = "3-7+11";
            Assert.AreEqual(3d-7d+11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_SubtractionMultiplication_IsCorrect()
        {
            _func.Function = "3-7*11";
            Assert.AreEqual(3d-7d*11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_SubtractionSubtraction_IsCorrect()
        {
            _func.Function = "3-7-11";
            Assert.AreEqual(3d-7d-11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_SubtractionDivision_IsCorrect()
        {
            _func.Function = "3-7/11";
            Assert.AreEqual(3d-7d/11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_DivisionAddition_IsCorrect()
        {
            _func.Function = "3/7+11";
            Assert.AreEqual(3d/7d+11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_DivisionMultiplication_IsCorrect()
        {
            _func.Function = "3/7*11";
            Assert.AreEqual(3d/7d*11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_DivisionSubtraction_IsCorrect()
        {
            _func.Function = "3/7-11";
            Assert.AreEqual(3d/7d-11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_DivisionDivision_IsCorrect()
        {
            _func.Function = "3/7/11";
            Assert.AreEqual(3d/7d/11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_AdditionPower_IsCorrect()
        {
            _func.Function = "3+7^11";
            Assert.AreEqual(3d+Math.Pow(7d, 11d), _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_PowerAddition_IsCorrect()
        {
            _func.Function = "3^7+11";
            Assert.AreEqual(Math.Pow(3d, 7d)+11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_MultiplicationPower_IsCorrect()
        {
            _func.Function = "3*7^11";
            Assert.AreEqual(3d*Math.Pow(7d, 11d), _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_PowerMultiplication_IsCorrect()
        {
            _func.Function = "3^7*11";
            Assert.AreEqual(Math.Pow(3d, 7d)*11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_SubtractionPower_IsCorrect()
        {
            _func.Function = "3-7^11";
            Assert.AreEqual(3d-Math.Pow(7d, 11d), _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_PowerSubtraction_IsCorrect()
        {
            _func.Function = "3^7-11";
            Assert.AreEqual(Math.Pow(3d, 7d)-11d, _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_DivisionPower_IsCorrect()
        {
            _func.Function = "3/7^11";
            Assert.AreEqual(3d/Math.Pow(7d, 11d), _func.EvaluateNumeric());
        }

        [Test]
        public void Precedence_PowerDivision_IsCorrect()
        {
            _func.Function = "3^7/11";
            Assert.AreEqual(Math.Pow(3d, 7d)/11d, _func.EvaluateNumeric());
        }

    }
}

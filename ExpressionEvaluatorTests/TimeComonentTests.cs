using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class TimeComponentTests
    {
        private Expression _func;
        private DateTime _now;

        [SetUp]
        public void Init()
        {
            _func = new Expression("");
            _now = DateTime.Now;
        }

        [TearDown]
        public void Clear()
        {
            _func.Clear();
        }

        [Test]
        public void Concatenate_TimespanStrings_IsCorrect()
        {
            _func.Function =
                "Concatenate( tostring(HoursComponent(a - b)), ':', MinutesComponent(a - b), ':', SecondsComponent(a - b))";
            _func.AddSetVariable("a", new DateTime(2014, 12, 08, 2, 25, 03));
            _func.AddSetVariable("b", new DateTime(2014, 12, 08, 1, 23, 00));
            Assert.AreEqual("1:2:3", _func.Evaluate<string>());
        }

        [Test]
        public void DaysComponent_ValidTimespan_IsCorrect()
        {
            _func.Function = "DaysComponent(a - b)";
            _func.AddSetVariable("a", new DateTime(2014, 12, 09, 1, 23, 00));
            _func.AddSetVariable("b", new DateTime(2014, 12, 08, 1, 23, 00));
            Assert.AreEqual(1m, _func.EvaluateNumeric());
        }

        [Test]
        public void HoursComponent_ValidTimespan_IsCorrect()
        {
            _func.Function = "HoursComponent(a - b)";
            _func.AddSetVariable("a", new DateTime(2014, 12, 08, 2, 23, 00));
            _func.AddSetVariable("b", new DateTime(2014, 12, 08, 1, 23, 00));
            Assert.AreEqual(1m, _func.EvaluateNumeric());
        }

        [Test]
        public void MinutesComponent_ValidTimespan_IsCorrect()
        {
            _func.Function = "MinutesComponent(a - b)";
            _func.AddSetVariable("a", new DateTime(2014, 12, 08, 1, 24, 00));
            _func.AddSetVariable("b", new DateTime(2014, 12, 08, 1, 23, 00));
            Assert.AreEqual(1m, _func.EvaluateNumeric());
        }

        [Test]
        public void SecondsComponent_ValidTimespan_IsCorrect()
        {
            _func.Function = "SecondsComponent(a - b)";
            _func.AddSetVariable("a", new DateTime(2014, 12, 08, 1, 23, 01));
            _func.AddSetVariable("b", new DateTime(2014, 12, 08, 1, 23, 00));
            Assert.AreEqual(1m, _func.EvaluateNumeric());
        }

        [Test]
        public void ToStringFormat_NumberWithStrings_IsCorrect()
        {
            _func.Function = "ToStringFormat(1, '00') + ':' + ToStringFormat(2, '00')";
            Assert.AreEqual("01:02", _func.Evaluate<string>());
        }

        [Test]
        public void ToStringFormat_SingleNumber_IsCorrect()
        {
            _func.Function = "ToStringFormat(1, '00')";
            Assert.AreEqual("01", _func.Evaluate<string>());
        }

        [Test]
        public void ToStringFormat_TimespansStringAddition_IsCorrect()
        {
            _func.Function =
                "ToStringFormat(HoursComponent(a - b), '00') + ':' + ToStringFormat(MinutesComponent(a - b), '00')";
            _func.AddSetVariable("a", new DateTime(2014, 12, 08, 2, 25, 00));
            _func.AddSetVariable("b", new DateTime(2014, 12, 08, 1, 23, 00));
            Assert.AreEqual("01:02", _func.Evaluate<string>());
        }

        [Test]
        public void ToStringFormat_Timespans_IsCorrect()
        {
            _func.Function = "ToStringFormat(MinutesComponent(a - b), '00')";
            _func.AddSetVariable("a", new DateTime(2014, 12, 08, 1, 24, 00));
            _func.AddSetVariable("b", new DateTime(2014, 12, 08, 1, 23, 00));
            Assert.AreEqual("01", _func.Evaluate<string>());
        }
    }
}

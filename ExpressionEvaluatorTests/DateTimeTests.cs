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
    public class DateTimeTests
    {
        Expression func;
        DateTime _now;

        [SetUp]
        public void init()
        {
            this.func = new Expression("");
            _now = DateTime.Now;

        }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void DateTime_Day_IsCorrect()
        {
            var expected = new TimeSpan(1, 0, 0, 0);
            func.Function = "days(1)";
            Assert.AreEqual(expected, func.Evaluate<TimeSpan>());
        }

        [Test]
        public void DateTime_Hour_IsCorrect()
        {
            var expected = new TimeSpan(1, 0, 0);
            func.Function = "hours(1)";
            Assert.AreEqual(expected, func.Evaluate<TimeSpan>());
        }

        [Test]
        public void DateTime_Minute_IsCorrect()
        {
            var expected = new TimeSpan(0, 1, 0);
            func.Function = "minutes(1)";
            Assert.AreEqual(expected, func.Evaluate<TimeSpan>());
        }

        [Test]
        public void DateTime_Second_IsCorrect()
        {
            var expected = new TimeSpan(0, 0, 1);
            func.Function = "seconds(1)";
            Assert.AreEqual(expected, func.Evaluate<TimeSpan>());
        }

        [Test]
        public void Seconds_Timespan_IsCorrect()
        {
            func.Function = "totalseconds(a)";
            func.AddSetVariable("a", new TimeSpan(0, 1, 0));
            Assert.AreEqual(60, func.EvaluateNumeric());
        }

        [Test]
        public void Minutes_Timespan_IsCorrect()
        {
            func.Function = "totalminutes(a)";
            func.AddSetVariable("a", new TimeSpan(1, 0, 0));
            Assert.AreEqual(60, func.EvaluateNumeric());
        }

        [Test]
        public void Hours_Timespan_IsCorrect()
        {
            func.Function = "totalhours(a)";
            func.AddSetVariable("a", new TimeSpan(1, 0, 0, 0));
            Assert.AreEqual(24, func.EvaluateNumeric());
        }

        [Test]
        public void Days_Timespan_IsCorrect()
        {
            func.Function = "totaldays(a)";
            func.AddSetVariable("a", new TimeSpan(2, 0, 0, 0));
            Assert.AreEqual(2, func.EvaluateNumeric());
        }

        [Test]
        public void GreaterThan_TimeSpan_True()
        {
            func.Function = "days(1) > seconds(1)";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThan_TimeSpan_False()
        {
            func.Function = "seconds(1) > days(1)";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThan_DateTime_True()
        {
            func.Function = "a > b";
            func.AddSetVariable("a", _now.AddDays(1));
            func.AddSetVariable("b", _now);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThan_DateTime_False()
        {
            func.Function = "a > b";
            func.AddSetVariable("a", _now);
            func.AddSetVariable("b", _now.AddDays(1));
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_TimeSpan_True()
        {
            func.Function = "days(1) >= seconds(1)";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_TimeSpanEqual_True()
        {
            func.Function = "days(1) >= days(1)";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_TimeSpan_False()
        {
            func.Function = "seconds(1) >= days(1)";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_DateTime_True()
        {
            func.Function = "a >= b";
            func.AddSetVariable("a", _now.AddDays(1));
            func.AddSetVariable("b", _now);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_DateTimeEqual_True()
        {
            func.Function = "a >= b";
            func.AddSetVariable("a", _now);
            func.AddSetVariable("b", _now);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_DateTime_False()
        {
            func.Function = "a >= b";
            func.AddSetVariable("a", _now);
            func.AddSetVariable("b", _now.AddDays(1));
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserThan_TimeSpan_True()
        {
            func.Function = "seconds(1) < days(1)";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserThan_TimeSpan_False()
        {
            func.Function = "days(1) < seconds(1)";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserThan_DateTime_True()
        {
            func.Function = "a < b";
            func.AddSetVariable("a", _now);
            func.AddSetVariable("b", _now.AddDays(1));
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserThan_DateTime_False()
        {
            func.Function = "a < b";
            func.AddSetVariable("a", _now.AddDays(1));
            func.AddSetVariable("b", _now);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqual_TimeSpan_True()
        {
            func.Function = "seconds(1) <= days(1)";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqual_TimeSpanEqual_True()
        {
            func.Function = "days(1) <= days(1)";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqual_TimeSpan_False()
        {
            func.Function = "days(1) <= seconds(1)";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqual_DateTime_True()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", _now);
            func.AddSetVariable("b", _now.AddDays(1));
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqual_DateTimeEqual_True()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", _now);
            func.AddSetVariable("b", _now);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqual_DateTime_False()
        {
            func.Function = "a <= b";
            func.AddSetVariable("a", _now.AddDays(1));
            func.AddSetVariable("b", _now);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void Equal_TimeSpan_True()
        {
            func.Function = "days(1) == days(1)";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void Equal_TimeSpan_False()
        {
            func.Function = "days(1) == minutes(1)";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void Equal_DateTimeEqual_True()
        {
            func.Function = "a == b";
            func.AddSetVariable("a", _now);
            func.AddSetVariable("b", _now);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void Equal_DateTime_False()
        {
            func.Function = "a == b";
            func.AddSetVariable("a", _now.AddDays(1));
            func.AddSetVariable("b", _now);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqual_TimeSpan_True()
        {
            func.Function = "days(1) != minutes(1)";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqual_TimeSpan_False()
        {
            func.Function = "days(1) != days(1)";
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqual_DateTimeEqual_True()
        {
            func.Function = "a != b";
            func.AddSetVariable("a", _now.AddDays(1));
            func.AddSetVariable("b", _now);
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqual_DateTime_False()
        {
            func.Function = "a != b";
            func.AddSetVariable("a", _now);
            func.AddSetVariable("b", _now);
            Assert.AreEqual(false, func.EvaluateBoolean());
        }

        [Test]
        public void Addition_DateTimeTimeSpan_IsCorrect()
        {
            func.Function = "a + days(1)";
            func.AddSetVariable("a", _now);
            Assert.AreEqual(_now.AddDays(1), func.Evaluate<DateTime>());
        }

        [Test]
        public void Addition_TimeSpanDateTime_IsCorrect()
        {
            func.Function = "days(1) + a";
            func.AddSetVariable("a", _now);
            Assert.AreEqual(_now.AddDays(1), func.Evaluate<DateTime>());
        }

        [Test]
        public void Addition_TimeSpanTimeSpan_IsCorrect()
        {
            func.Function = "days(1) + days(1)";
            func.AddSetVariable("a", _now);
            Assert.AreEqual(new TimeSpan(2, 0, 0, 0), func.Evaluate<TimeSpan>());
        }

        [Test]
        public void Subtraction_DateTimeTimeSpan_IsCorrect()
        {
            func.Function = "a - days(1)";
            func.AddSetVariable("a", _now);
            Assert.AreEqual(_now.AddDays(-1), func.Evaluate<DateTime>());
        }

        [Test]
        public void Subtraction_TimeSpanTimeSpan_IsCorrect()
        {
            func.Function = "days(2) - days(1)";
            func.AddSetVariable("a", _now);
            Assert.AreEqual(new TimeSpan(1, 0, 0, 0), func.Evaluate<TimeSpan>());
        }

        [Test]
        public void Subtraction_DateTimeDateTime_IsCorrect()
        {
            func.Function = "a - b";
            func.AddSetVariable("a", _now.AddDays(1));
            func.AddSetVariable("b", _now);
            Assert.AreEqual(new TimeSpan(1, 0, 0, 0), func.Evaluate<TimeSpan>());
        }
    }
}

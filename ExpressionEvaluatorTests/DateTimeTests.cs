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
            func.Function = "day(1)";
            Assert.AreEqual(expected, func.Evaluate<TimeSpan>());
        }

        [Test]
        public void DateTime_Hour_IsCorrect()
        {
            var expected = new TimeSpan(1, 0, 0);
            func.Function = "hour(1)";
            Assert.AreEqual(expected, func.Evaluate<TimeSpan>());
        }

        [Test]
        public void DateTime_Minute_IsCorrect()
        {
            var expected = new TimeSpan(0, 1, 0);
            func.Function = "minute(1)";
            Assert.AreEqual(expected, func.Evaluate<TimeSpan>());
        }

        [Test]
        public void DateTime_Second_IsCorrect()
        {
            var expected = new TimeSpan(0, 0, 1);
            func.Function = "second(1)";
            Assert.AreEqual(expected, func.Evaluate<TimeSpan>());
        }

        [Test]
        public void Seconds_Timespan_IsCorrect()
        {
            func.Function = "seconds(a)";
            func.AddSetVariable("a", new TimeSpan(0, 1, 0));
            Assert.AreEqual(60, func.EvaluateNumeric());
        }

        [Test]
        public void Minutes_Timespan_IsCorrect()
        {
            func.Function = "minutes(a)";
            func.AddSetVariable("a", new TimeSpan(1, 0, 0));
            Assert.AreEqual(60, func.EvaluateNumeric());
        }

        [Test]
        public void Hours_Timespan_IsCorrect()
        {
            func.Function = "hours(a)";
            func.AddSetVariable("a", new TimeSpan(1, 0, 0, 0));
            Assert.AreEqual(24, func.EvaluateNumeric());
        }

        [Test]
        public void Days_Timespan_IsCorrect()
        {
            func.Function = "days(a)";
            func.AddSetVariable("a", new TimeSpan(2, 0, 0, 0));
            Assert.AreEqual(2, func.EvaluateNumeric());
        }

        [Test]
        public void GreaterThan_TimeSpan_True()
        {
            func.Function = "day(1) > second(1)";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void GreaterThan_TimeSpan_False()
        {
            func.Function = "second(1) > day(1)";
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
            func.Function = "day(1) >= second(1)";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_TimeSpanEqual_True()
        {
            func.Function = "day(1) >= day(1)";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void GreaterEqual_TimeSpan_False()
        {
            func.Function = "second(1) >= day(1)";
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
            func.Function = "second(1) < day(1)";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserThan_TimeSpan_False()
        {
            func.Function = "day(1) < second(1)";
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
            func.Function = "second(1) <= day(1)";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqual_TimeSpanEqual_True()
        {
            func.Function = "day(1) <= day(1)";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void LesserEqual_TimeSpan_False()
        {
            func.Function = "day(1) <= second(1)";
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
            func.Function = "day(1) == day(1)";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void Equal_TimeSpan_False()
        {
            func.Function = "day(1) == minute(1)";
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
            func.Function = "day(1) != minute(1)";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        [Test]
        public void NotEqual_TimeSpan_False()
        {
            func.Function = "day(1) != day(1)";
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
            func.Function = "a + day(1)";
            func.AddSetVariable("a", _now);
            Assert.AreEqual(_now.AddDays(1), func.Evaluate<DateTime>());
        }

        [Test]
        public void Addition_TimeSpanTimeSpan_IsCorrect()
        {
            func.Function = "day(1) + day(1)";
            func.AddSetVariable("a", _now);
            Assert.AreEqual(new TimeSpan(2, 0, 0, 0), func.Evaluate<TimeSpan>());
        }

        [Test]
        public void Subtraction_DateTimeTimeSpan_IsCorrect()
        {
            func.Function = "a - day(1)";
            func.AddSetVariable("a", _now);
            Assert.AreEqual(_now.AddDays(-1), func.Evaluate<DateTime>());
        }

        [Test]
        public void Subtraction_TimeSpanTimeSpan_IsCorrect()
        {
            func.Function = "day(2) - day(1)";
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


        //[Test]
        //public void DateTime_UseGetMinutesFunction_IsCorrect()
        //{
        //    DateTime a = DateTime.Now;
        //    func.Function = "minutes(timeA - timeB)";
        //    func.AddSetVariable("timeA", a);
        //    func.AddSetVariable("timeB", a.AddMinutes(5));
        //    Assert.AreEqual(5, func.EvaluateBoolean());
        //}

        //[Test]
        //public void DateTime_UseGetHoursFunction_IsCorrect()
        //{
        //    DateTime a = DateTime.Now;
        //    func.Function = "hours(timeA - timeB)";
        //    func.AddSetVariable("timeA", a);
        //    func.AddSetVariable("timeB", a.AddHours(5));
        //    Assert.AreEqual(5, func.EvaluateBoolean());
        //}

        //[Test]
        //public void DateTime_UseGetDayFunction_IsCorrect()
        //{
        //    DateTime a = DateTime.Now;
        //    func.Function = "days(timeA - timeB)";
        //    func.AddSetVariable("timeA", a);
        //    func.AddSetVariable("timeB", a.AddDays(5));
        //    Assert.AreEqual(5, func.EvaluateBoolean());
        //}

        //[Test]
        //public void DateTime_UseGetMonthsFunction_IsCorrect()
        //{
        //    DateTime a = DateTime.Now;
        //    func.Function = "months(timeA - timeB)";
        //    func.AddSetVariable("timeA", a);
        //    func.AddSetVariable("timeB", a.AddMonths(5));
        //    Assert.AreEqual(5, func.EvaluateBoolean());
        //}

        //[Test]
        //public void DateTime_UseGetYearsFunction_IsCorrect()
        //{
        //    DateTime a = DateTime.Now;
        //    func.Function = "years(timeA - timeB)";
        //    func.AddSetVariable("timeA", a);
        //    func.AddSetVariable("timeB", a.AddYears(5));
        //    Assert.AreEqual(5, func.EvaluateBoolean());
        //}

        //[Test]
        //public void DateTime_BadExpression001_ExpressionException()
        //{
        //    func.Function = "a < now() + hour(1)";
        //    func.AddSetVariable("a", DateTime.Now);
        //    Assert.AreEqual(true, func.EvaluateBoolean());
        //}

        //[Test]
        //[ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        //public void DateTime_BadExpression002_ExpressionException()
        //{
        //    func.Function = "now() < now() * 2";
        //}

        //[Test]
        //[ExpectedException(typeof(ExpressionException), ExpectedMessage = "Operator error", MatchType = MessageMatch.Contains)]
        //public void DateTime_BadExpression003_ExpressionException()
        //{
        //    func.Function = "5 * minutes(timeA)";
        //}
    }
}

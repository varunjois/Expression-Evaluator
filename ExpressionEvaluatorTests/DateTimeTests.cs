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

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void DateTime_useHourFunction_IsCorrect()
        {
            func.Function = "now() < ( now() + hour(1) )";
            Assert.AreEqual(true, func.EvaluateBoolean());
        }

        //[Test]
        //public void DateTime_useMinuteFunction_IsCorrect()
        //{
        //    func.Function = "now() < now() + minute(1)";
        //    Assert.AreEqual(true, func.EvaluateBoolean());
        //}

        //[Test]
        //public void DateTime_useDayFunction_IsCorrect()
        //{
        //    func.Function = "now() < now() + day(1)";
        //    Assert.AreEqual(true, func.EvaluateBoolean());
        //}

        //[Test]
        //public void DateTime_useYearFunction_IsCorrect()
        //{
        //    func.Function = "now() < now() + year(1)";
        //    Assert.AreEqual(true, func.EvaluateBoolean());
        //}

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

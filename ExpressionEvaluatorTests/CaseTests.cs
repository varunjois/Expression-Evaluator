// ReSharper disable InconsistentNaming
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class OperatorTest2
    {
        Expression func;

        [SetUp]
        public void init()
        { this.func = new Expression(""); }

        [TearDown]
        public void clear()
        { func.Clear(); }

        [Test]
        public void Sign_HasCaps_NoException()
        {
            func.Function = "Sign(a)";
        }

        [Test]
        public void Sign_AllLower_NoException()
        {
            func.Function = "sign(a)";
        }

        [Test]
        public void Sign_AllUpper_NoException()
        {
            func.Function = "SIGN(a)";
        }

        [Test]
        public void Abs_HasCaps_NoException()
        {
            func.Function = "Abs(a)";
        }

        [Test]
        public void Abs_AllLower_NoException()
        {
            func.Function = "abs(a)";
        }

        [Test]
        public void Abs_AllUpper_NoException()
        {
            func.Function = "ABS(a)";
        }

        [Test]
        public void Neg_HasCaps_NoException()
        {
            func.Function = "Neg(a)";
        }

        [Test]
        public void Neg_AllLower_NoException()
        {
            func.Function = "neg(a)";
        }

        [Test]
        public void Neg_AllUpper_NoException()
        {
            func.Function = "NEG(a)";
        }

        [Test]
        public void Ln_HasCaps_NoException()
        {
            func.Function = "Ln(a)";
        }

        [Test]
        public void Ln_AllLower_NoException()
        {
            func.Function = "ln(a)";
        }

        [Test]
        public void Ln_AllUpper_NoException()
        {
            func.Function = "LN(a)";
        }

        [Test]
        public void Now_HasCaps_NoException()
        {
            func.Function = "Now()";
        }

        [Test]
        public void Now_AllLower_NoException()
        {
            func.Function = "now()";
        }

        [Test]
        public void Now_AllUpper_NoException()
        {
            func.Function = "NOW()";
        }

        [Test]
        public void TotalDays_HasCaps_NoException()
        {
            func.Function = "TotalDays(a)";
        }

        [Test]
        public void TotalDays_AllLower_NoException()
        {
            func.Function = "totaldays(a)";
        }

        [Test]
        public void TotalDays_AllUpper_NoException()
        {
            func.Function = "TOTALDAYS(a)";
        }

        [Test]
        public void TotalHours_HasCaps_NoException()
        {
            func.Function = "TotalHours(a)";
        }

        [Test]
        public void TotalHours_AllLower_NoException()
        {
            func.Function = "totalhours(a)";
        }

        [Test]
        public void TotalHours_AllUpper_NoException()
        {
            func.Function = "TOTALHOURS(a)";
        }

        [Test]
        public void TotalMinutes_HasCaps_NoException()
        {
            func.Function = "TotalMinutes(a)";
        }

        [Test]
        public void TotalMinutes_AllLower_NoException()
        {
            func.Function = "totalminutes(a)";
        }

        [Test]
        public void TotalMinutes_AllUpper_NoException()
        {
            func.Function = "TOTALMINUTES(a)";
        }

        [Test]
        public void TotalSeconds_HasCaps_NoException()
        {
            func.Function = "TotalSeconds(a)";
        }

        [Test]
        public void TotalSeconds_AllLower_NoException()
        {
            func.Function = "totalseconds(a)";
        }

        [Test]
        public void TotalSeconds_AllUpper_NoException()
        {
            func.Function = "TOTALSECONDS(a)";
        }

        [Test]
        public void Days_HasCaps_NoException()
        {
            func.Function = "Days(a)";
        }

        [Test]
        public void Days_AllLower_NoException()
        {
            func.Function = "days(a)";
        }

        [Test]
        public void Days_AllUpper_NoException()
        {
            func.Function = "DAYS(a)";
        }

        [Test]
        public void Hours_HasCaps_NoException()
        {
            func.Function = "Hours(a)";
        }

        [Test]
        public void Hours_AllLower_NoException()
        {
            func.Function = "hours(a)";
        }

        [Test]
        public void Hours_AllUpper_NoException()
        {
            func.Function = "HOURS(a)";
        }

        [Test]
        public void Minutes_HasCaps_NoException()
        {
            func.Function = "Minutes(a)";
        }

        [Test]
        public void Minutes_AllLower_NoException()
        {
            func.Function = "minutes(a)";
        }

        [Test]
        public void Minutes_AllUpper_NoException()
        {
            func.Function = "MINUTES(a)";
        }

        [Test]
        public void Seconds_HasCaps_NoException()
        {
            func.Function = "Seconds(a)";
        }

        [Test]
        public void Seconds_AllLower_NoException()
        {
            func.Function = "seconds(a)";
        }

        [Test]
        public void Seconds_AllUpper_NoException()
        {
            func.Function = "SECONDS(a)";
        }
    }
} 

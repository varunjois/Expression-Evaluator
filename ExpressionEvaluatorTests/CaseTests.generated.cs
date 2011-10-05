// ReSharper disable InconsistentNaming
using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class CaseTests
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
		
        [Test]
        public void Variable_FormulaIsMixedCaseVariableIsMixedCase_NoException()
        {
            func.Function = "aAaA";
            Assert.IsTrue(func.IsVariable("aAaA"));
        }
		
        [Test]
        public void Variable_FormulaIsMixedCaseVariableIsAllCaps_NoException()
        {
            func.Function = "aAaA";
            Assert.IsTrue(func.IsVariable("AAAA"));
        }
		
        [Test]
        public void Variable_FormulaIsMixedCaseVariableIsAllLower_NoException()
        {
            func.Function = "aAaA";
            Assert.IsTrue(func.IsVariable("aaaa"));
        }
		
        [Test]
        public void Variable_FormulaIsAllCapsVariableIsMixedCase_NoException()
        {
            func.Function = "AAAA";
            Assert.IsTrue(func.IsVariable("aAaA"));
        }
		
        [Test]
        public void Variable_FormulaIsAllCapsVariableIsAllCaps_NoException()
        {
            func.Function = "AAAA";
            Assert.IsTrue(func.IsVariable("AAAA"));
        }
		
        [Test]
        public void Variable_FormulaIsAllCapsVariableIsAllLower_NoException()
        {
            func.Function = "AAAA";
            Assert.IsTrue(func.IsVariable("aaaa"));
        }
		
        [Test]
        public void Variable_FormulaIsAllLowerVariableIsMixedCase_NoException()
        {
            func.Function = "aaaa";
            Assert.IsTrue(func.IsVariable("aAaA"));
        }
		
        [Test]
        public void Variable_FormulaIsAllLowerVariableIsAllCaps_NoException()
        {
            func.Function = "aaaa";
            Assert.IsTrue(func.IsVariable("AAAA"));
        }
		
        [Test]
        public void Variable_FormulaIsAllLowerVariableIsAllLower_NoException()
        {
            func.Function = "aaaa";
            Assert.IsTrue(func.IsVariable("aaaa"));
        }
		
        [Test]
        public void Variable_FormulaIsMixedCaseVariableIsMixedCaseValueSet_CorrectEvaluation()
        {
            func.Function = "aAaA";
			func.AddSetVariable("aAaA", 2.2);
            Assert.AreEqual(func.EvaluateNumeric(), 2.2);
        }
		
        [Test]
        public void Variable_FormulaIsMixedCaseVariableIsAllCapsValueSet_CorrectEvaluation()
        {
            func.Function = "aAaA";
			func.AddSetVariable("AAAA", 2.2);
            Assert.AreEqual(func.EvaluateNumeric(), 2.2);
        }
		
        [Test]
        public void Variable_FormulaIsMixedCaseVariableIsAllLowerValueSet_CorrectEvaluation()
        {
            func.Function = "aAaA";
			func.AddSetVariable("aaaa", 2.2);
            Assert.AreEqual(func.EvaluateNumeric(), 2.2);
        }
		
        [Test]
        public void Variable_FormulaIsAllCapsVariableIsMixedCaseValueSet_CorrectEvaluation()
        {
            func.Function = "AAAA";
			func.AddSetVariable("aAaA", 2.2);
            Assert.AreEqual(func.EvaluateNumeric(), 2.2);
        }
		
        [Test]
        public void Variable_FormulaIsAllCapsVariableIsAllCapsValueSet_CorrectEvaluation()
        {
            func.Function = "AAAA";
			func.AddSetVariable("AAAA", 2.2);
            Assert.AreEqual(func.EvaluateNumeric(), 2.2);
        }
		
        [Test]
        public void Variable_FormulaIsAllCapsVariableIsAllLowerValueSet_CorrectEvaluation()
        {
            func.Function = "AAAA";
			func.AddSetVariable("aaaa", 2.2);
            Assert.AreEqual(func.EvaluateNumeric(), 2.2);
        }
		
        [Test]
        public void Variable_FormulaIsAllLowerVariableIsMixedCaseValueSet_CorrectEvaluation()
        {
            func.Function = "aaaa";
			func.AddSetVariable("aAaA", 2.2);
            Assert.AreEqual(func.EvaluateNumeric(), 2.2);
        }
		
        [Test]
        public void Variable_FormulaIsAllLowerVariableIsAllCapsValueSet_CorrectEvaluation()
        {
            func.Function = "aaaa";
			func.AddSetVariable("AAAA", 2.2);
            Assert.AreEqual(func.EvaluateNumeric(), 2.2);
        }
		
        [Test]
        public void Variable_FormulaIsAllLowerVariableIsAllLowerValueSet_CorrectEvaluation()
        {
            func.Function = "aaaa";
			func.AddSetVariable("aaaa", 2.2);
            Assert.AreEqual(func.EvaluateNumeric(), 2.2);
        }
		
    }
}

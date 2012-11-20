using System;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class CaseTests
    {
        Expression _func;

        [SetUp]
        public void Init()
        { this._func = new Expression(""); }

        [TearDown]
        public void Clear()
        { _func.Clear(); }

        [Test]
        public void Sign_HasCaps_NoException()
        {
            _func.Function = "Sign(a)";
        }

        [Test]
        public void Sign_AllLower_NoException()
        {
            _func.Function = "sign(a)";
        }

        [Test]
        public void Sign_AllUpper_NoException()
        {
            _func.Function = "SIGN(a)";
        }
        
        [Test]
        public void Abs_HasCaps_NoException()
        {
            _func.Function = "Abs(a)";
        }

        [Test]
        public void Abs_AllLower_NoException()
        {
            _func.Function = "abs(a)";
        }

        [Test]
        public void Abs_AllUpper_NoException()
        {
            _func.Function = "ABS(a)";
        }
        
        [Test]
        public void Neg_HasCaps_NoException()
        {
            _func.Function = "Neg(a)";
        }

        [Test]
        public void Neg_AllLower_NoException()
        {
            _func.Function = "neg(a)";
        }

        [Test]
        public void Neg_AllUpper_NoException()
        {
            _func.Function = "NEG(a)";
        }
        
        [Test]
        public void Ln_HasCaps_NoException()
        {
            _func.Function = "Ln(a)";
        }

        [Test]
        public void Ln_AllLower_NoException()
        {
            _func.Function = "ln(a)";
        }

        [Test]
        public void Ln_AllUpper_NoException()
        {
            _func.Function = "LN(a)";
        }
        
        [Test]
        public void Now_HasCaps_NoException()
        {
            _func.Function = "Now()";
        }

        [Test]
        public void Now_AllLower_NoException()
        {
            _func.Function = "now()";
        }

        [Test]
        public void Now_AllUpper_NoException()
        {
            _func.Function = "NOW()";
        }
        
        [Test]
        public void TotalDays_HasCaps_NoException()
        {
            _func.Function = "TotalDays(a)";
        }

        [Test]
        public void TotalDays_AllLower_NoException()
        {
            _func.Function = "totaldays(a)";
        }

        [Test]
        public void TotalDays_AllUpper_NoException()
        {
            _func.Function = "TOTALDAYS(a)";
        }
        
        [Test]
        public void TotalHours_HasCaps_NoException()
        {
            _func.Function = "TotalHours(a)";
        }

        [Test]
        public void TotalHours_AllLower_NoException()
        {
            _func.Function = "totalhours(a)";
        }

        [Test]
        public void TotalHours_AllUpper_NoException()
        {
            _func.Function = "TOTALHOURS(a)";
        }
        
        [Test]
        public void TotalMinutes_HasCaps_NoException()
        {
            _func.Function = "TotalMinutes(a)";
        }

        [Test]
        public void TotalMinutes_AllLower_NoException()
        {
            _func.Function = "totalminutes(a)";
        }

        [Test]
        public void TotalMinutes_AllUpper_NoException()
        {
            _func.Function = "TOTALMINUTES(a)";
        }
        
        [Test]
        public void TotalSeconds_HasCaps_NoException()
        {
            _func.Function = "TotalSeconds(a)";
        }

        [Test]
        public void TotalSeconds_AllLower_NoException()
        {
            _func.Function = "totalseconds(a)";
        }

        [Test]
        public void TotalSeconds_AllUpper_NoException()
        {
            _func.Function = "TOTALSECONDS(a)";
        }
        
        [Test]
        public void Days_HasCaps_NoException()
        {
            _func.Function = "Days(a)";
        }

        [Test]
        public void Days_AllLower_NoException()
        {
            _func.Function = "days(a)";
        }

        [Test]
        public void Days_AllUpper_NoException()
        {
            _func.Function = "DAYS(a)";
        }
        
        [Test]
        public void Hours_HasCaps_NoException()
        {
            _func.Function = "Hours(a)";
        }

        [Test]
        public void Hours_AllLower_NoException()
        {
            _func.Function = "hours(a)";
        }

        [Test]
        public void Hours_AllUpper_NoException()
        {
            _func.Function = "HOURS(a)";
        }
        
        [Test]
        public void Minutes_HasCaps_NoException()
        {
            _func.Function = "Minutes(a)";
        }

        [Test]
        public void Minutes_AllLower_NoException()
        {
            _func.Function = "minutes(a)";
        }

        [Test]
        public void Minutes_AllUpper_NoException()
        {
            _func.Function = "MINUTES(a)";
        }
        
        [Test]
        public void Seconds_HasCaps_NoException()
        {
            _func.Function = "Seconds(a)";
        }

        [Test]
        public void Seconds_AllLower_NoException()
        {
            _func.Function = "seconds(a)";
        }

        [Test]
        public void Seconds_AllUpper_NoException()
        {
            _func.Function = "SECONDS(a)";
        }
        
        [Test]
        public void Variable_FormulaIsMixedCaseVariableIsMixedCase_NoException()
        {
            _func.Function = "aAaA";
            Assert.IsTrue(_func.IsVariable("aAaA"));
        }
        
        [Test]
        public void Variable_FormulaIsMixedCaseVariableIsAllCaps_NoException()
        {
            _func.Function = "aAaA";
            Assert.IsTrue(_func.IsVariable("AAAA"));
        }
        
        [Test]
        public void Variable_FormulaIsMixedCaseVariableIsAllLower_NoException()
        {
            _func.Function = "aAaA";
            Assert.IsTrue(_func.IsVariable("aaaa"));
        }
        
        [Test]
        public void Variable_FormulaIsAllCapsVariableIsMixedCase_NoException()
        {
            _func.Function = "AAAA";
            Assert.IsTrue(_func.IsVariable("aAaA"));
        }
        
        [Test]
        public void Variable_FormulaIsAllCapsVariableIsAllCaps_NoException()
        {
            _func.Function = "AAAA";
            Assert.IsTrue(_func.IsVariable("AAAA"));
        }
        
        [Test]
        public void Variable_FormulaIsAllCapsVariableIsAllLower_NoException()
        {
            _func.Function = "AAAA";
            Assert.IsTrue(_func.IsVariable("aaaa"));
        }
        
        [Test]
        public void Variable_FormulaIsAllLowerVariableIsMixedCase_NoException()
        {
            _func.Function = "aaaa";
            Assert.IsTrue(_func.IsVariable("aAaA"));
        }
        
        [Test]
        public void Variable_FormulaIsAllLowerVariableIsAllCaps_NoException()
        {
            _func.Function = "aaaa";
            Assert.IsTrue(_func.IsVariable("AAAA"));
        }
        
        [Test]
        public void Variable_FormulaIsAllLowerVariableIsAllLower_NoException()
        {
            _func.Function = "aaaa";
            Assert.IsTrue(_func.IsVariable("aaaa"));
        }
        
        [Test]
        public void Variable_FormulaIsMixedCaseVariableIsMixedCaseValueSet_CorrectEvaluation()
        {
            _func.Function = "aAaA";
            _func.AddSetVariable("aAaA", 2.2);
            Assert.AreEqual(_func.EvaluateNumeric(), 2.2);
        }
        
        [Test]
        public void Variable_FormulaIsMixedCaseVariableIsAllCapsValueSet_CorrectEvaluation()
        {
            _func.Function = "aAaA";
            _func.AddSetVariable("AAAA", 2.2);
            Assert.AreEqual(_func.EvaluateNumeric(), 2.2);
        }
        
        [Test]
        public void Variable_FormulaIsMixedCaseVariableIsAllLowerValueSet_CorrectEvaluation()
        {
            _func.Function = "aAaA";
            _func.AddSetVariable("aaaa", 2.2);
            Assert.AreEqual(_func.EvaluateNumeric(), 2.2);
        }
        
        [Test]
        public void Variable_FormulaIsAllCapsVariableIsMixedCaseValueSet_CorrectEvaluation()
        {
            _func.Function = "AAAA";
            _func.AddSetVariable("aAaA", 2.2);
            Assert.AreEqual(_func.EvaluateNumeric(), 2.2);
        }
        
        [Test]
        public void Variable_FormulaIsAllCapsVariableIsAllCapsValueSet_CorrectEvaluation()
        {
            _func.Function = "AAAA";
            _func.AddSetVariable("AAAA", 2.2);
            Assert.AreEqual(_func.EvaluateNumeric(), 2.2);
        }
        
        [Test]
        public void Variable_FormulaIsAllCapsVariableIsAllLowerValueSet_CorrectEvaluation()
        {
            _func.Function = "AAAA";
            _func.AddSetVariable("aaaa", 2.2);
            Assert.AreEqual(_func.EvaluateNumeric(), 2.2);
        }
        
        [Test]
        public void Variable_FormulaIsAllLowerVariableIsMixedCaseValueSet_CorrectEvaluation()
        {
            _func.Function = "aaaa";
            _func.AddSetVariable("aAaA", 2.2);
            Assert.AreEqual(_func.EvaluateNumeric(), 2.2);
        }
        
        [Test]
        public void Variable_FormulaIsAllLowerVariableIsAllCapsValueSet_CorrectEvaluation()
        {
            _func.Function = "aaaa";
            _func.AddSetVariable("AAAA", 2.2);
            Assert.AreEqual(_func.EvaluateNumeric(), 2.2);
        }
        
        [Test]
        public void Variable_FormulaIsAllLowerVariableIsAllLowerValueSet_CorrectEvaluation()
        {
            _func.Function = "aaaa";
            _func.AddSetVariable("aaaa", 2.2);
            Assert.AreEqual(_func.EvaluateNumeric(), 2.2);
        }
        
        [Test]
        public void Equals_FormulaIsMixedCaseAndMixedCaseValueSet_CorrectEvaluation()
        {
            _func.Function = "'aAaA' == 'aAaA'";
            Assert.IsTrue(_func.EvaluateBoolean());
        }
        
        [Test]
        public void Equals_FormulaIsMixedCaseAndAllCapsValueSet_CorrectEvaluation()
        {
            _func.Function = "'aAaA' == 'AAAA'";
            Assert.IsTrue(_func.EvaluateBoolean());
        }
        
        [Test]
        public void Equals_FormulaIsMixedCaseAndAllLowerValueSet_CorrectEvaluation()
        {
            _func.Function = "'aAaA' == 'aaaa'";
            Assert.IsTrue(_func.EvaluateBoolean());
        }
        
        [Test]
        public void Equals_FormulaIsAllCapsAndMixedCaseValueSet_CorrectEvaluation()
        {
            _func.Function = "'AAAA' == 'aAaA'";
            Assert.IsTrue(_func.EvaluateBoolean());
        }
        
        [Test]
        public void Equals_FormulaIsAllCapsAndAllCapsValueSet_CorrectEvaluation()
        {
            _func.Function = "'AAAA' == 'AAAA'";
            Assert.IsTrue(_func.EvaluateBoolean());
        }
        
        [Test]
        public void Equals_FormulaIsAllCapsAndAllLowerValueSet_CorrectEvaluation()
        {
            _func.Function = "'AAAA' == 'aaaa'";
            Assert.IsTrue(_func.EvaluateBoolean());
        }
        
        [Test]
        public void Equals_FormulaIsAllLowerAndMixedCaseValueSet_CorrectEvaluation()
        {
            _func.Function = "'aaaa' == 'aAaA'";
            Assert.IsTrue(_func.EvaluateBoolean());
        }
        
        [Test]
        public void Equals_FormulaIsAllLowerAndAllCapsValueSet_CorrectEvaluation()
        {
            _func.Function = "'aaaa' == 'AAAA'";
            Assert.IsTrue(_func.EvaluateBoolean());
        }
        
        [Test]
        public void Equals_FormulaIsAllLowerAndAllLowerValueSet_CorrectEvaluation()
        {
            _func.Function = "'aaaa' == 'aaaa'";
            Assert.IsTrue(_func.EvaluateBoolean());
        }
        
        [Test]
        public void Equals_FormulaIsMixedCaseVariableIsMixedCaseValueSet_CorrectEvaluation()
        {
            _func.Function = "'aAaA' == a";
            _func.AddSetVariable("a", "aAaA");
            Assert.IsTrue(_func.EvaluateBoolean());
        }
        
        [Test]
        public void Equals_FormulaIsMixedCaseVariableIsAllCapsValueSet_CorrectEvaluation()
        {
            _func.Function = "'aAaA' == a";
            _func.AddSetVariable("a", "AAAA");
            Assert.IsTrue(_func.EvaluateBoolean());
        }
        
        [Test]
        public void Equals_FormulaIsMixedCaseVariableIsAllLowerValueSet_CorrectEvaluation()
        {
            _func.Function = "'aAaA' == a";
            _func.AddSetVariable("a", "aaaa");
            Assert.IsTrue(_func.EvaluateBoolean());
        }
        
        [Test]
        public void Equals_FormulaIsAllCapsVariableIsMixedCaseValueSet_CorrectEvaluation()
        {
            _func.Function = "'AAAA' == a";
            _func.AddSetVariable("a", "aAaA");
            Assert.IsTrue(_func.EvaluateBoolean());
        }
        
        [Test]
        public void Equals_FormulaIsAllCapsVariableIsAllCapsValueSet_CorrectEvaluation()
        {
            _func.Function = "'AAAA' == a";
            _func.AddSetVariable("a", "AAAA");
            Assert.IsTrue(_func.EvaluateBoolean());
        }
        
        [Test]
        public void Equals_FormulaIsAllCapsVariableIsAllLowerValueSet_CorrectEvaluation()
        {
            _func.Function = "'AAAA' == a";
            _func.AddSetVariable("a", "aaaa");
            Assert.IsTrue(_func.EvaluateBoolean());
        }
        
        [Test]
        public void Equals_FormulaIsAllLowerVariableIsMixedCaseValueSet_CorrectEvaluation()
        {
            _func.Function = "'aaaa' == a";
            _func.AddSetVariable("a", "aAaA");
            Assert.IsTrue(_func.EvaluateBoolean());
        }
        
        [Test]
        public void Equals_FormulaIsAllLowerVariableIsAllCapsValueSet_CorrectEvaluation()
        {
            _func.Function = "'aaaa' == a";
            _func.AddSetVariable("a", "AAAA");
            Assert.IsTrue(_func.EvaluateBoolean());
        }
        
        [Test]
        public void Equals_FormulaIsAllLowerVariableIsAllLowerValueSet_CorrectEvaluation()
        {
            _func.Function = "'aaaa' == a";
            _func.AddSetVariable("a", "aaaa");
            Assert.IsTrue(_func.EvaluateBoolean());
        }
        
    }
}

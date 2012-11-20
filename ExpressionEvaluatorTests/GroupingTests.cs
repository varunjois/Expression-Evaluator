using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Vanderbilt.Biostatistics.Wfccm2;

namespace ExpressionEvaluatorTests
{
    [TestFixture]
    public class GroupingTests
    {
        Expression _func;

        [SetUp]
        public void init()
        { this._func = new Expression(""); }

        [TearDown]
        public void clear()
        { _func.Clear(); }


        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Close missing", MatchType = MessageMatch.Contains)]
        public void Braces_MissingClose001_ExpressionException()
        {
            _func.Function = "{{1+2}";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Close missing", MatchType = MessageMatch.Contains)]
        public void Braces_MissingClose002_ExpressionException()
        {
            _func.Function = "{1+2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open missing", MatchType = MessageMatch.Contains)]
        public void Braces_MissingOpen001_ExpressionException()
        {
            _func.Function = "1+2}";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open missing", MatchType = MessageMatch.Contains)]
        public void Braces_MissingOpen002_ExpressionException()
        {
            _func.Function = "}{1+2}";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Close missing", MatchType = MessageMatch.Contains)]
        public void Parenthesis_MissingClose001_ExpressionException()
        {
            _func.Function = "((1+2)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Close missing", MatchType = MessageMatch.Contains)]
        public void Parenthesis_MissingClose002_ExpressionException()
        {
            _func.Function = "(1+2";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open missing", MatchType = MessageMatch.Contains)]
        public void Parenthesis_MissingOpen001_ExpressionException()
        {
            _func.Function = "1+2)";
        }

        [Test]
        [ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open missing", MatchType = MessageMatch.Contains)]
        public void Parenthesis_MissingOpen002_ExpressionException()
        {
            _func.Function = ")(1+2)";
        }

        //[Test]
        //[ExpectedException(typeof(ExpressionException), ExpectedMessage = "Close missing", MatchType = MessageMatch.Contains)]
        //public void Bracket_MissingClose001_ExpressionException()
        //{
        //    func.Function = "[[1+2]";
        //}

        //[Test]
        //[ExpectedException(typeof(ExpressionException), ExpectedMessage = "Close missing", MatchType = MessageMatch.Contains)]
        //public void Bracket_MissingClose002_ExpressionException()
        //{
        //    func.Function = "[1+2";
        //}

        //[Test]
        //[ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open missing", MatchType = MessageMatch.Contains)]
        //public void Bracket_MissingOpen001_ExpressionException()
        //{
        //    func.Function = "1+2]";
        //}

        //[Test]
        //[ExpectedException(typeof(ExpressionException), ExpectedMessage = "Open missing", MatchType = MessageMatch.Contains)]
        //public void Bracket_MissingOpen002_ExpressionException()
        //{
        //    func.Function = "][1+2]";
        
    }
}

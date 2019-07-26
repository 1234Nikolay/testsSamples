using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnitTestProject1;

namespace Tests
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        //[TearDown]
        //public void Teardown()
        //{

        //}

        [TestCase("dsf.txt",false)]
        [TestCase("dsfdfdfs.tx",true)]

        public void IsValidLogFileNameTest(string str,bool expected)
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName(str);
           Assert.AreEqual(expected, result);
           
        }

        [Test]
        //[Ignore("mistake")]
        [Category("fast")]
        public void IsValidFileName_EmptyFileName_ThrowsException()
        {
            LogAnalyzer la = MakeAnalyzer();
            var ex = Assert.Catch<Exception>(() => la.IsValidLogFileName(string.Empty));
            StringAssert.Contains("we need to have", ex.Message);
        }
        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }
        //----------------------------------------
        [Test]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid()
        {
            LogAnalyzer la = MakeAnalyzer();
            la.IsValidLogFileName("dfdfxt.txt");
            Assert.False(la.WasLastFileNameValid);
        }
    }
}
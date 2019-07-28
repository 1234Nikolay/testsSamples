using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnitTestProject1;
using NSubstitute;
namespace Tests
{
   
    public class Tests
    { 
        [Test]
    public void Analyze_LoggerThrows_CallsWebService()
    {
        var mockWebService = Substitute.For<IWebService>();
        var stubLogger = Substitute.For<ILogger>();
        stubLogger.When(
            logger => logger.LogError(Arg.Any<string>()))
            .Do(info => { throw new Exception("fake exception"); });
        var analyzer = new LogAnalyzer2(stubLogger, mockWebService);
        analyzer.MinNameLength = 10;
        analyzer.Analyze("Short.txt");
        mockWebService.Received()
            .Write(Arg.Is<string>(s => s.Contains("fake exception")));
    }
    public class FakeWebService : IWebService
        {
            public string MessageToWebService;
            public void Write(string message)
            {
                MessageToWebService = message;
            }
        }
        public class FakeLogger2 : ILogger
        {
            public Exception WillThrow = null;
            public string LoggerGotMessage = null;
            public void LogError(string message)
            {
                LoggerGotMessage = message;
                if (WillThrow != null)
                {
                    throw WillThrow;
                }
            }
        }
    }
}


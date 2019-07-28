using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1
{
    public interface ILogger
    {
        void LogError(string message);
    }
    public class LogAnalyzer2
    {
        private ILogger _logger;
        private IWebService _webService;
        public LogAnalyzer2(ILogger logger, IWebService webService)
        {
            _logger = logger;
            _webService = webService;
        }
        public int MinNameLength { get; set; }
        public void Analyze(string filename)
        {
            if (filename.Length < MinNameLength)
            {
                try
                {
                    _logger.LogError(
                      string.Format($"Too short name of file: { 0}",filename));
                }
                catch (Exception e)
                {
                    _webService.Write("mistake of: " +e);
                }
            }
        }
    }
    public interface IWebService
    {
        void Write(string message);
    }

}

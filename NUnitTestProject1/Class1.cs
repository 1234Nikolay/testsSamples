using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1
{
    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            IExtensionManager mgr = new FileExtensionManager();
            return mgr.IsValid(fileName);
          
        }

    }
    public interface IExtensionManager
    {
        bool IsValid(string fileName);
    }
    public class AlwaysValidFakeExtensionManager : IExtensionManager //this is stub
    {
        public bool IsValid(string fileName)
        {
            return true;
        }
    }
    class FileExtensionManager: IExtensionManager
    {
        public bool IsValid(string fileName)
        {
            //here is read file
            return true;
        }
    }
}

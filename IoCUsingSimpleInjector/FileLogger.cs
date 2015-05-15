using System;

namespace IoCUsingSimpleInjector
{
    internal class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logging from File: {0}", message);
        }
    }
}
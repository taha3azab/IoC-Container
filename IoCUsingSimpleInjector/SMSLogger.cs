using System;

namespace IoCUsingSimpleInjector
{
    internal class SMSLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logging from SMS: {0}", message);
        }
    }
}
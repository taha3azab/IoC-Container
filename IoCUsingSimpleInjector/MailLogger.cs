using System;

namespace IoCUsingSimpleInjector
{
    public class MailLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logging from Mail: {0}", message);
        }
    }
}
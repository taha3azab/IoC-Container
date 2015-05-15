using System;
using SimpleInjector;

namespace IoCUsingSimpleInjector
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();

            container.RegisterSingle<ICreditCard, Visa>();

            container.RegisterSingle<Shopper, Shopper>();
            var shopper = container.GetInstance<Shopper>();
            shopper.Charge();


            //var loggerFactory = new LoggerFactory(container);
            //loggerFactory.Register<MailLogger>("MailLogger");
            //loggerFactory.Register<SMSLogger>("SMSLogger");
            //loggerFactory.Register<FileLogger>("FileLogger");

            //container.RegisterSingle<ILoggerFactory>(loggerFactory);

            //var factory = container.GetInstance<ILoggerFactory>();
            //var mailLogger = factory.GetInstance("MailLogger");
            //mailLogger.Log("Mail Logger");

            //var smsLogger = factory.GetInstance("SMSLogger");
            //smsLogger.Log("SMS Logger");

            //var fileLogger = factory.GetInstance("FileLogger");
            //fileLogger.Log("File Logger");

            Console.ReadKey();
        }
    }
}

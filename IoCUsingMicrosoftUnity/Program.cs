using System;
using Microsoft.Practices.Unity;

namespace IoCUsingMicrosoftUnity
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new UnityContainer();

            container.RegisterType<ICreditCard, MasterCard>(new ContainerControlledLifetimeManager());
            //container.RegisterType<ICreditCard, MasterCard>("DefaultCreditCard");
            //container.RegisterType<ICreditCard, Visa>("BackupCard");
            //container.RegisterType<ICreditCard, Visa>();
            //container.RegisterType<ICreditCard, MasterCard>(new InjectionProperty("ChargeCount", 5));

            var shopper = container.Resolve<Shopper>();

            //var shopper = container.Resolve<Shopper>(new ParameterOverride("_creditCard", new Visa()));

            shopper.Charge();
            Console.WriteLine(shopper.ChargesForCurrentCard);

            var shopper2 = container.Resolve<Shopper>();
            shopper2.Charge();
            Console.WriteLine(shopper2.ChargesForCurrentCard);


            Console.Read();
        }
    }
}

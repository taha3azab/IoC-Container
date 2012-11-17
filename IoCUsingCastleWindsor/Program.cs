using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace IoCUsingCastleWindsor
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            //container.Register(Component.For<Shopper>().LifeStyle.Transient);
            //container.Register(Component.For<ICreditCard>().ImplementedBy<MasterCard>().LifeStyle.Transient);
            container.Install(new ShoppingInstaller());


            var shopper = container.Resolve<Shopper>();
            shopper.Charge();
            Console.WriteLine(shopper.ChargesForCurrentCard);


            var shopper2 = container.Resolve<Shopper>();
            shopper2.Charge();
            Console.WriteLine(shopper2.ChargesForCurrentCard);

            Console.Read();
        }
    }

    internal class ShoppingInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<Shopper>()
                .LifeStyle.Transient);
            container.Register(Component.For<ICreditCard>()
                .ImplementedBy<MasterCard>()
                .LifeStyle.Transient);
        }
    }
}

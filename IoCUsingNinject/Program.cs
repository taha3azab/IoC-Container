using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;

namespace IoCUsingNinject
{
    class Program
    {
        static void Main(string[] args)
        {
            //var kernel = new StandardKernel();

            //kernel.Bind<ICreditCard>().To<Visa>().Named("visa");
            //kernel.Rebind<ICreditCard>().To<MasterCard>().InSingletonScope();

            //kernel.Bind<ICreditCard>().ToMethod(context =>
            //                                        {
            //                                            Console.WriteLine("Creating new card");
            //                                            return new MasterCard();
            //                                        });


            var kernel = new StandardKernel(new MyModule());


            var shopper = kernel.Get<Shopper>();
            shopper.Charge();
            Console.WriteLine(shopper.ChargesForCurrentCard);

            var shopper2 = kernel.Get<Shopper>();
            shopper2.Charge();
            Console.WriteLine(shopper2.ChargesForCurrentCard);

            Console.Read();
        }
    }

    internal class MyModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<ICreditCard>().To<MasterCard>();
        }
    }
}

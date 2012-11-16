using System;

namespace IoCContainerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //ICreditCard creditCard = new MasterCard();
            //ICreditCard otherCreditCard = new Visa();

            var resolver = new Resolver();
            
            resolver.Register<Shopper, Shopper>();
            
            //resolver.Register<ICreditCard, MasterCard>();
            resolver.Register<ICreditCard, Visa>();

            var shopper = resolver.Resolve<Shopper>();


            //var shopper = new Shopper(resolver.ResolvCreditCard());
            //var shopper = new Shopper(otherCreditCard);
            
            shopper.Charge();

            Console.ReadKey();
        }
    }
}

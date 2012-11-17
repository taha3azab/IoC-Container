using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Pipeline;

namespace IoCUsingStructureMap
{
    class Program
    {
        static void Main(string[] args)
        {
            //var container = new Container(x => x.For<ICreditCard>().Use<MasterCard>());
            //var container = new Container(x => x.For<ICreditCard>().Singleton().Use<MasterCard>());
            //var container = new Container(x => x.For<ICreditCard>().LifecycleIs(new SingletonLifecycle()).Use<MasterCard>());

            var container = new Container(new MyRegistery());



            //container.Configure(x => x.For<ICreditCard>().Use<MasterCard>().Named("master"));

            //container.Configure(x => x.For<ICreditCard>().Use<Visa>().Named("visa"));

            //var creditCard = container.TryGetInstance<ICreditCard>("master");
            //Console.WriteLine(creditCard.Charge());


            var shopper = container.GetInstance<Shopper>();
            shopper.Charge();
            Console.WriteLine(shopper.ChargesForCurrentCard);


            var shopper2 = container.GetInstance<Shopper>();
            shopper2.Charge();
            Console.WriteLine(shopper2.ChargesForCurrentCard);


            //Console.WriteLine(container.WhatDoIHave());

            Console.Read();
        }
    }

    internal class MyRegistery : Registry
    {
        public MyRegistery()
        {
            For<ICreditCard>().Singleton().Use<MasterCard>();
        }
    }
}

using System;
using IoCUsingCastleWindsor;

namespace IoCUsingCastleWindsor
{
    public class Shopper
    {
        private readonly ICreditCard _creditCard;

        public Shopper(ICreditCard creditCard)
        {
            _creditCard = creditCard;
        }

        public void Charge()
        {
            var chargeMessage = _creditCard.Charge();
            Console.WriteLine(chargeMessage);
        }

        public int ChargesForCurrentCard
        { get { return _creditCard.ChargeCount; } }
    }
}
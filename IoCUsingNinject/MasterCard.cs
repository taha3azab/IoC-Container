
namespace IoCUsingNinject
{

    public class MasterCard : ICreditCard
    {
        public string Charge()
        {
            ChargeCount++;
            return "Swiping the master card";
        }

        public int ChargeCount { get; set; }
    }
}
namespace IoCUsingSimpleInjector
{
    public class MasterCard : ICreditCard
    {
        public string Charge()
        {
            return "Swiping the master card";
        }

    }
}
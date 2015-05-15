namespace IoCUsingSimpleInjector
{
    public class Visa : ICreditCard
    {
        public string Charge()
        {
            return "Charging with the visa";
        }
    }
}
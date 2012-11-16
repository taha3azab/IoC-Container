namespace IoCUsingMicrosoftUnity
{
    public class Visa : ICreditCard
    {
        public string Charge()
        {
            return "Charging with the visa";
        }

        public int ChargeCount
        {
            get { return 0; }
        }
    }
}

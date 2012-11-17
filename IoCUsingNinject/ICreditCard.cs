namespace IoCUsingNinject
{
    public interface ICreditCard
    {
        string Charge();

        int ChargeCount { get; }

    }

}

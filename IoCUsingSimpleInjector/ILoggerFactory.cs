namespace IoCUsingSimpleInjector
{
    public interface ILoggerFactory
    {
        ILogger GetInstance(string name);
    }
}

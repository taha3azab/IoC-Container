using System;
using System.Collections.Generic;
using SimpleInjector;

namespace IoCUsingSimpleInjector
{
    public class LoggerFactory : ILoggerFactory
    {
        private readonly Dictionary<string, InstanceProducer> _producers =
            new Dictionary<string, InstanceProducer>(StringComparer.OrdinalIgnoreCase);

        private readonly Container _container;

        public LoggerFactory(Container container)
        {
            _container = container;
        }

        ILogger ILoggerFactory.GetInstance(string name)
        {
            var handler = _producers[name].GetInstance();
            return (ILogger)handler;
        }

        public void Register<TImplementation>(string name, Lifestyle lifestyle = null)
            where TImplementation : class, ILogger
        {
            lifestyle = lifestyle ?? Lifestyle.Singleton;

            var registration = lifestyle.CreateRegistration<ILogger, TImplementation>(_container);
            _container.Verify();

            var producer = new InstanceProducer(typeof(ILogger), registration);

            _producers.Add(name, producer);
        }
    }
}

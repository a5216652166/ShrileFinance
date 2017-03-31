namespace Infrastructure.Logger
{
    using System.Linq;
    using System.Reflection;
    using Autofac;
    using Autofac.Core;
    using Core.Interfaces;

    public class LoggingModule : Autofac.Module
    {
        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            // Handle properties.
            registration.Activated += (sender, e) => InjectLoggerProperties(e);
        }

        private static void InjectLoggerProperties(ActivatedEventArgs<object> eventArgs)
        {
            var instance = eventArgs.Instance;
            var logger = eventArgs.Context.Resolve<ILogger>();

            // Get all the injectable properties to set.
            // If you wanted to ensure the properties were only UNSET properties,
            // here's where you'd do it.
            var properties = instance.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType == typeof(ILogger) && p.CanWrite && p.GetIndexParameters().Length == 0);

            // Set the properties located.
            foreach (var propToSet in properties)
            {
                propToSet.SetValue(instance, logger, null);
            }
        }
    }
}

using System.Reflection;
using Autofac;

namespace ReSharperTnT
{
    public class Bootstrapper
    {
        private readonly IContainer _container;

        public Bootstrapper()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(Bootstrapper).Assembly)
                .AsImplementedInterfaces();

            _container = builder.Build();
        }

        public IContainer CreateContainer()
        {
            return _container;
        }

        public T Get<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
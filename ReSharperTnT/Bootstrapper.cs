using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace ReSharperTnT
{
    public class Bootstrapper
    {
        private readonly IContainer _container;

        public Bootstrapper()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(typeof (Bootstrapper).Assembly)
                .AsImplementedInterfaces();

            _container = builder.Build();
        }

        public IContainer GetContainer()
        {
            return _container;
        }

        public T Get<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
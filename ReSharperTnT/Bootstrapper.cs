using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace ReSharperTnT
{
    public class Bootstrapper
    {
        static Bootstrapper()
        {
            Init();
        }

        public static void Init()
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.CreateContainer();
            var autofacWebApiDependencyResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = autofacWebApiDependencyResolver;
        }

        private readonly IContainer _container;

        public Bootstrapper()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof (Bootstrapper).Assembly)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof (Bootstrapper).Assembly)
                .Where(c=>c.Name.EndsWith("Controller"))
                .AsSelf();

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
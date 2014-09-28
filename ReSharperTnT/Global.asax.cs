using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace ReSharperTnT
{
    public class MvcApplication : HttpApplication
    {
        private static IContainer _container;
        private static AutofacWebApiDependencyResolver _dependencyResolver;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            _container = new Bootstrapper().CreateContainer();

            _dependencyResolver = new AutofacWebApiDependencyResolver(_container);

            GlobalConfiguration.Configuration.DependencyResolver = _dependencyResolver;
        }
    }
}
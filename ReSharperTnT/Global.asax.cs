using System.Web;
using System.Web.Http;
using Autofac.Integration.WebApi;

namespace ReSharperTnT
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var container = new Bootstrapper().CreateContainer();

            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}
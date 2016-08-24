using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace ReSharperTnT
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            IContainer container = new Bootstrapper().GetContainer();

            GlobalConfiguration.Configuration.DependencyResolver = 
                new AutofacWebApiDependencyResolver(container);
        }
    }
}
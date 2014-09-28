using System.Web;
using System.Web.Http;

namespace ReSharperTnT
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Bootstrapper.Init();
        }
    }
}
using Inveon.Services.Abstract;
using Inveon.Services.DependencyResolver;
using Inveon.WebUI.App_Start;
using Ninject.Modules;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Inveon.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new ServiceModule()));

            AreaRegistration.RegisterAllAreas();
        }
    }
}

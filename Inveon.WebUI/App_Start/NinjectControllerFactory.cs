using Ninject;
using Ninject.Modules;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Inveon.WebUI.App_Start
{
    public class NinjectControllerFactory :DefaultControllerFactory
    {
        private IKernel _kernel;

        public NinjectControllerFactory(INinjectModule ninjectModule)
        {
            _kernel = new StandardKernel(ninjectModule);
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(
                404, String.Format(
                "The controller for path '{0}' could not be found " +
                "or it does not implement IController.",
                requestContext.HttpContext.Request.Path));
            }
            return controllerType == null ? null : (IController)_kernel.Get(controllerType);
        }
        private void AddBindings()
        {
            _kernel.Inject(Roles.Provider);
        }
    }
}
using Inveon.DataAccess.Abstract;
using Inveon.DataAccess.Concrete.EntityFramework;
using Inveon.Services.Abstract;
using Inveon.Services.Concrete;
using Ninject.Modules;
using System.Web.Security;

namespace Inveon.Services.DependencyResolver
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductRepository>().To<ProductRepository>().InSingletonScope();

            Bind<IAccountService>().To<AccountManager>().InSingletonScope();
            Bind<IAccountRepository>().To<AccountRepository>().InSingletonScope();
            Bind<RoleProvider>().ToMethod(ctx => Roles.Provider);

        }
    }
}

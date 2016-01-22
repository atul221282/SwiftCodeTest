using System.Web.Http;
using SwiftDemo.Core;
using SwiftDemo.CoreContracts;
using Ninject;
using SwiftDemo.Core.Helpers;

namespace SwiftDemo.Web
{
    public class IocConfig
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel(); // Ninject IoC

            // These registrations are "per instance request".
            // See http://blog.bobcravens.com/2010/03/ninject-life-cycle-management-or-scoping/

            kernel.Bind<RepositoryFactories>().To<RepositoryFactories>()
                .InSingletonScope();

            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();
            kernel.Bind<ISwiftDemoUow>().To<SwiftDemoUow>();

            // Tell WebApi how to use our Ninject IoC
            config.DependencyResolver = new NinjectDependencyResolver(kernel);
        }
    }
}
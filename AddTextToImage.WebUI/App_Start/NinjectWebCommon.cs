[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AddTextToImage.WebUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(AddTextToImage.WebUI.App_Start.NinjectWebCommon), "Stop")]

namespace AddTextToImage.WebUI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using AddTextToImage.Data.Context;
    using AddTextToImage.Domain.Repository;
    using AddTextToImage.Domain.Entities;
    using AddTextToImage.Data.Service;
    using System.Web.Http;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                GlobalConfiguration.Configuration.DependencyResolver = new Ninject.Web.WebApi.NinjectDependencyResolver(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDbContextFactory>().To<DbContextFactory>();

            kernel.Bind<IRepository<Sample>>().To<Repository<Sample>>();
            kernel.Bind<IRepository<TextTemplate>>().To<Repository<TextTemplate>>();
            kernel.Bind<IRepository<TextGallery>>().To<Repository<TextGallery>>();
            kernel.Bind<IRepository<ClipartTemplate>>().To<Repository<ClipartTemplate>>();
            kernel.Bind<IRepository<ClipartGallery>>().To<Repository<ClipartGallery>>();
            kernel.Bind<IRepository<ModelItem>>().To<Repository<ModelItem>>();
            kernel.Bind<IRepository<Model>>().To<Repository<Model>>();
        }        
    }
}

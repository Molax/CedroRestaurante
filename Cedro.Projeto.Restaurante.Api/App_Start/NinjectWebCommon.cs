﻿using Cedro.Projeto.Restaurante.Application;
using Cedro.Projeto.Restaurante.Application.Interface;
using Cedro.Projeto.Restaurante.Domain.Interfaces.Repositories;
using Cedro.Projeto.Restaurante.Domain.Interfaces.Services;
using Cedro.Projeto.Restaurante.Domain.Services;
using Cedro.Projeto.Restaurante.Infra.Data.Repositories;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Cedro.Projeto.Restaurante.Api.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Cedro.Projeto.Restaurante.Api.App_Start.NinjectWebCommon), "Stop")]

namespace Cedro.Projeto.Restaurante.Api.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

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
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IRestauranteAppService>().To<RestauranteAppService>();
            kernel.Bind<IPratoAppService>().To<PratoAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IRestauranteService>().To<RestauranteService>();
            kernel.Bind<IPratoService>().To<PratoService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IRestauranteRepository>().To<RestauranteRepository>();
            kernel.Bind<IPratoRepository>().To<PratoRepository>();
        }
    }
}
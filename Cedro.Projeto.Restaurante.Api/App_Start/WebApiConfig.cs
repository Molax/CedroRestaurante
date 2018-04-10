using Cedro.Projeto.Restaurante.Api.Helpers;
using Cedro.Projeto.Restaurante.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Unity;
using Unity.Lifetime;

namespace Cedro.Projeto.Restaurante.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<Application.Interface.IPratoAppService, Application.PratoAppService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);


            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}

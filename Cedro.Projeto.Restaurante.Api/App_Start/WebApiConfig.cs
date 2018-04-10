using Cedro.Projeto.Restaurante.Api.Helpers;
using Cedro.Projeto.Restaurante.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Unity;
using Unity.Lifetime;
using Cedro.Projeto.Restaurante.Domain.Interfaces.Repositories;
using Cedro.Projeto.Restaurante.Infra.Data.Repositories;
using System.Net.Http.Headers;
using System.Web.Http.Cors;

namespace Cedro.Projeto.Restaurante.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IRestauranteRepository, RestauranteRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPratoRepository, PratoRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<Projeto.Restaurante.Application.Interface.IPratoAppService, Application.PratoAppService>(new HierarchicalLifetimeManager());
            container.RegisterType<Domain.Services.IPratoService, PratoService>(new HierarchicalLifetimeManager());


            container.RegisterType<Projeto.Restaurante.Application.Interface.IRestauranteAppService, Application.RestauranteAppService>(new HierarchicalLifetimeManager());
            container.RegisterType<Domain.Services.IRestauranteService, RestauranteService>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);


            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}

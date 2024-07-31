using Domain.Entities;
using Domain.Interfaces;
using Repository.Repositories;
using Service.Interfaces;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace TaskManager
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IGenericRepo<Quote>, GenericRepo<Quote>>();
            container.RegisterType<IQuoteService, QuoteService>();
            container.RegisterType<IQuoteRepo, QuoteRepo>();
            container.RegisterType<IUserRepo, UserRepo>();
            container.RegisterType<IGenericRepo<Users>, GenericRepo<Users>>();
            container.RegisterType<IUserService, UserService>();

            config.DependencyResolver = new UnityDependencyResolver(container);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


        }
    }
}

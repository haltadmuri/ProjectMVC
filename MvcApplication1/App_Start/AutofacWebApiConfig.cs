using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logica;
using Infraestructura;
using System.Web.Http;
using Dominio;
using System.Reflection;
using Autofac.Builder;
using System.Security;
using MvcApplication1.App_Start;
using MvcApplication1.Controllers;
using Autofac.Integration.WebApi;


namespace MvcApplication1.App_Start
{
    public class AutofacWebApiConfig
    {
        public static void RegisterAutofacApi()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<CustomerDbContext>().As<ICustomerDbContext>();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}
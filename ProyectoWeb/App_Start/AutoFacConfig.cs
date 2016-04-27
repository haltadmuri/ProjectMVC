using Autofac;
using Autofac.Integration.Mvc;
using Infraestructura;
using Logica;
using ProyectoWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb
{
    public static class AutoFacConfig
    {
      public static void Register(Action<IDependencyResolver> resolver)
        {
            // un delegado es un puntero a un metodo por tanto si defino un puntero a un metodo
            //" Action<IDependencyResolver> resolver" puedo pasarle un metodo como parametro con la misma firma
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();

            
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerHttpRequest();
            builder.RegisterType<CustomerDbContext>().As<ICustomerDbContext>().InstancePerHttpRequest();
            //builder.RegisterType<Cliente>().InstancePerHttpRequest();
     
            builder.RegisterModelBinderProvider();

            // Set the MVC dependency resolver to use Autofac
            var container = builder.Build();
            resolver(new AutofacDependencyResolver(container));
        }
    }
}
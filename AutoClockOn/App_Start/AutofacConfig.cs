using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace AutoClockOn.Web
{
    public partial class AutofacConfig
    {
        public static void Bootstrapper()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var services = Assembly.Load("AutoClockOn.Service");
            builder.RegisterAssemblyTypes(services)
                 .Where(t => t.Name.EndsWith("Service"))
                 .AsImplementedInterfaces();//.InstancePerLifetimeScope();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));

            //return builder.Build();
        }
    }
}
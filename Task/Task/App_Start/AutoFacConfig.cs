using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Structure.Repositories;
using Task.Structure.Services;

namespace Task.App_Start
{
    public class AutoFacConfig
    {
        public static void RegisterAutoFac()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).InstancePerRequest();
            builder.RegisterType<EntitiesContexts>().InstancePerRequest();
            builder.RegisterGeneric(typeof(Generic<>)).InstancePerRequest();
            builder.RegisterType<UnitOfWork>().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ClientService).Assembly)
                .Where(i => i.Name.EndsWith("Service")).InstancePerRequest();
            IContainer ic = builder.Build();
            DependencyResolver.SetResolver( new AutofacDependencyResolver(ic));
        }
    }
}
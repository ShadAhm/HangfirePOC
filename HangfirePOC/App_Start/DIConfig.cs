using Autofac;
using Autofac.Integration.Mvc;
using HangfirePOC.Data;
using HangfirePOC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HangfirePOC.Web.App_Start
{
    internal class DIConfig
    {
        internal static void Setup()
        {
            var builder = new ContainerBuilder();

            var uof = new UnitOfWork();

            builder.RegisterInstance(uof).As<IUnitOfWork>();
            builder.RegisterInstance(new ActivityService(uof)).As<IActivityService>();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
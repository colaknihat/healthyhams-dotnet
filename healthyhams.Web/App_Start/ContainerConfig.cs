using Autofac;
using Autofac.Integration.Mvc;
using DotNetOpenAuth.OAuth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using healthyhams.Data;
using healthyhams.Data.Services;
using healthyhams.Web.Controllers;

namespace healthyhams.Web.App_Start
{
    public class ContainerConfig
    {

        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SqlUserData>()
                .As<IUserData>()
                .SingleInstance();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SqlFoodData>()
                .As<IFoodData>()
                .SingleInstance();

            builder.RegisterType<healthyhamsContext>()
                .As<healthyhamsContext>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
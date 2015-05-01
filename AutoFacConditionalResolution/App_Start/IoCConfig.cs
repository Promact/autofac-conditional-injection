using Autofac;
using Autofac.Integration.Mvc;
using AutoFacConditionalResolution.Controllers;
using AutoFacConditionalResolution.Core;
using AutoFacConditionalResolution.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoFacConditionalResolution.App_Start
{
    public class IoCConfig
    {
        public static IContainer Register()
        {

            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.RegisterModule(new AutofacWebTypesModule());            
            builder.RegisterModule(new SocialMediaConditionalLoadingModule());
            var container = builder.Build();
            AutofacDependencyResolver resolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(resolver);
            return container;
        }
    }
}
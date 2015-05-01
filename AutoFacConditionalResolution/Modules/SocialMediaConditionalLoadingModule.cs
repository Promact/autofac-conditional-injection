using Autofac;
using Autofac.Core;
using AutoFacConditionalResolution.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFacConditionalResolution.Modules
{
    public class SocialMediaConditionalLoadingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FacebookRepository>().Named<ISocialMediaRepository>("facebook");
            builder.RegisterType<TwitterRepository>().Named<ISocialMediaRepository>("twitter");
            base.Load(builder);
        }

        protected override void AttachToComponentRegistration(IComponentRegistry componentRegistry, IComponentRegistration registration)
        {
            registration.Preparing += registration_Preparing;
            base.AttachToComponentRegistration(componentRegistry, registration);
        }

        void registration_Preparing(object sender, PreparingEventArgs e)
        {
            IComponentRegistration registration = sender as IComponentRegistration;
            IInstanceActivator activator = registration.Activator as IInstanceActivator;
            if (!activator.LimitType.FullName.StartsWith("Http"))
            {
                HttpRequestBase request = e.Context.Resolve<HttpRequestBase>();
                string provider = "";
                if (!String.IsNullOrWhiteSpace(request.QueryString["provider"]))
                    provider = request.QueryString["provider"];
                else
                    provider = "facebook";
                ResolvedParameter resolvedParameter = ResolvedParameter.ForNamed<ISocialMediaRepository>(provider);
                e.Parameters = new List<Parameter>() { resolvedParameter };
            }
        }
    }
}
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AutoFacConditionalResolution.Startup))]
namespace AutoFacConditionalResolution
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheSecretOfTime.Startup))]
namespace TheSecretOfTime
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

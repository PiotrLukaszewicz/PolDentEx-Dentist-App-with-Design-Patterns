using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PolDentEx.Startup))]
namespace PolDentEx
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

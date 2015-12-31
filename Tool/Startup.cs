using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tool.Startup))]
namespace Tool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

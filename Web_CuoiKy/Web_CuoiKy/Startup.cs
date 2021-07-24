using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_CuoiKy.Startup))]
namespace Web_CuoiKy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

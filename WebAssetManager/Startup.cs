using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAssetManager.Startup))]
namespace WebAssetManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

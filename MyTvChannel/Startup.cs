using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyTvChannel.Startup))]
namespace MyTvChannel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeiphartUniversity.Startup))]
namespace LeiphartUniversity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab4_ThucHanh.Startup))]
namespace Lab4_ThucHanh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

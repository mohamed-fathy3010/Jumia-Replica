using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GraduationProject.Startup))]
namespace GraduationProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

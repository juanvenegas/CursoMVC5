using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CursoMVC5.Startup))]
namespace CursoMVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

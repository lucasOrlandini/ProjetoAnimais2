using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fatec.ProjetoAnimais.Startup))]
namespace Fatec.ProjetoAnimais
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;
using Tut.Run;

[assembly: OwinStartup(typeof (Startup))]

namespace Tut.Run
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutofacConfig.RegsiterComponents();
        }
    }
}
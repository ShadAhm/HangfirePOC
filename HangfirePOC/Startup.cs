using Microsoft.Owin;
using Owin;
using Hangfire;

[assembly: OwinStartupAttribute(typeof(HangfirePOC.Startup))]
namespace HangfirePOC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("HangfireDB");

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}

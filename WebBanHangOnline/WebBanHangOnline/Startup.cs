using Microsoft.Owin;
using Microsoft.Owin.Security;
using Owin;
using System;
using System.Web;

[assembly: OwinStartupAttribute(typeof(WebBanHangOnline.Startup))]
namespace WebBanHangOnline
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

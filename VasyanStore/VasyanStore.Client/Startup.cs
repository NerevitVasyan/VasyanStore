using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using VasyanStore.Client.Utils;
using VasyanStore.DataAccess;

[assembly: OwinStartup(typeof(VasyanStore.Client.Startup))]

namespace VasyanStore.Client
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //для того щоб Identity розумів який контекст потрібно використовувати
            app.CreatePerOwinContext<DbContext>(() => new EFContext());

            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);

            app.CreatePerOwinContext<AppSignInManager>(AppSignInManager.Create);

            //додаємо аутентефікацію
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
        }
    }
}

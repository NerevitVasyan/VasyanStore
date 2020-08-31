using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Auth/Login")
            });

            InitUsers();
        }

        private void InitUsers()
        {
            //Створюємо контекст
            var dbContext = new EFContext();

            //Створюємо менеджер юзерів який може додавати юзерів до нашої бази данних
            var userStore = new UserStore<IdentityUser>(dbContext);
            var userManager = new UserManager<IdentityUser>(userStore);

            //Створюємо менеджер ролей який може додавати ролі до нашої бази данних
            var roleStore = new RoleStore<IdentityRole>(dbContext);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            //створюємо роль Адміністратор
            var role = new IdentityRole
            {
                Name = "ADMIN",
            };
            roleManager.Create(role);

            //створюємо звичайного юзера
            var user = new IdentityUser
            {
                UserName = "vasyan",
                Email = "vasyan@gmail.com",
            };
            userManager.Create(user, "Qwe123!!");

            //створюємо юзера-адміна
            var userAdmin = new IdentityUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
            };
            userManager.Create(userAdmin, "Qwe123!!");

            //даємо юзеру-адміну права Адміністратора
            userManager.AddToRole(userManager.FindByName("admin").Id, "ADMIN");

        }

    }
}

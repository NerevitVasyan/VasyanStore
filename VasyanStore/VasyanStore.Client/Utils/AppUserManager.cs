using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VasyanStore.Client.Utils
{
    public class AppUserManager : UserManager<IdentityUser>
    {
        public AppUserManager(IUserStore<IdentityUser> store) : base(store) { }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext owinContext)
        {
            var dbContext = owinContext.Get<DbContext>();
            var manager = new AppUserManager(new UserStore<IdentityUser>(dbContext));

            manager.UserValidator = new UserValidator<IdentityUser>(manager)
            {
                //емейл не має повторюватися
                RequireUniqueEmail = true,
                //логін юзера має містити тільки літери та цифри
                AllowOnlyAlphanumericUserNames = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                //чи мають бути цифри
                RequireDigit = true,
                //скільки символів має містити пароль
                RequiredLength = 6,
                //маленькі літери
                RequireLowercase = true,
                //великі літери
                RequireUppercase = true,
                //символи
                RequireNonLetterOrDigit = true
            };

            //налаштування токену
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser>(dataProtectionProvider.Create("Token"));
            }

            return manager;
        }
    }
}
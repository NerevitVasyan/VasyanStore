using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VasyanStore.Client.Utils
{
    public class AppSignInManager : SignInManager<IdentityUser,string>
    {
        public AppSignInManager(AppUserManager userManager, IAuthenticationManager authenticationManager): base(userManager, authenticationManager) { }

        public static AppSignInManager Create(IdentityFactoryOptions<AppSignInManager> options,IOwinContext owinContext)
        {
            var userManager = owinContext.GetUserManager<AppUserManager>();
            var signInManager = new AppSignInManager(userManager, owinContext.Authentication);

            return signInManager;
        }
    }
}
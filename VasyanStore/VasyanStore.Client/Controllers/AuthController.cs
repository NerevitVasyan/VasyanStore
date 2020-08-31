using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VasyanStore.Client.Models;
using VasyanStore.Client.Utils;

namespace VasyanStore.Client.Controllers
{

    /*
     
     1. DataAccess
        1.1     Install Microsoft.AspNet.Identity.EntityFramework
                        Microsoft.AspNet.Identity.Core
        1.2     EfContext : IdentityDbContext<IdenityUser>
     2. Client
        2.1     Install Microsoft.Owin.Host.SystemWeb
                        Microsoft.AspNet.Identity.EntityFramework
                        Microsoft.AspNet.Identity.OWIN
        2.2     Add Startup.cs File
        2.3     Configure AppUserManager
        2.4     Configure AppSignInManager
        2.5     Configure all managers in Startup.cs file
        2.6     Add Auth Controller
        2.7     Implement Login and Register methods within AuthController
   
      */


    public class AuthController : Controller
    {
        // Повертає сторінку входу(логіну)
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // Винонує вхід в систему після заповненя форми логіну
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            //дістаємо "менеджер входу" з Owin-у
            var signInManager = HttpContext.GetOwinContext().Get<AppSignInManager>();

            //передаємо логін та пароль
            var status = signInManager.PasswordSignIn(model.Username, model.Password, false, false);

            //якщо все добре то все добре
            if(status == SignInStatus.Success)
            {
                return RedirectToAction("Index", "Games");
            }
            else
            {
                return Content("Something Wrong!!!");
            }
        }

        // повертає сторінку реєстрації
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // здійснює реєстрацію юзера в нашому додатку і заносить інфорамацію про юзера в базу
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            //дістаємо "менеджер юрезів" з Owin-у
            var manager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();

            //створюємо нового юзера
            var user = new IdentityUser
            {
                UserName = model.Username,
                Email = model.Email
            };

            //створюємо юзера в базі данних
            var result = manager.CreateAsync(user, model.Password).Result;

            if(result.Succeeded)
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                //якщо є помилки то ліпимо їх і повертаємо користувачу
                var error = "";
                foreach(var err in result.Errors)
                {
                    error += err +"\n";
                }

                return Content(error);
            }
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index","Games");
        }

    }
}
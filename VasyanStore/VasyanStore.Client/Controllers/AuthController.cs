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
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

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

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

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
    }
}
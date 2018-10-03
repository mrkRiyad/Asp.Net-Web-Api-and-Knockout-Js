using AspNetWebApiWithKnockoutJs.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AspNetWebApiWithKnockoutJs.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string pass)
        {
            var userManager = new UserManager<AppUser>(new UserStore<AppUser>(new Security()));
            var user = userManager.FindByEmail(email);

            if (user != null && userManager.CheckPassword(user, pass))
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, email)
                }, DefaultAuthenticationTypes.ApplicationCookie);

                Request.GetOwinContext().Authentication.SignIn(identity);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }
    }
}
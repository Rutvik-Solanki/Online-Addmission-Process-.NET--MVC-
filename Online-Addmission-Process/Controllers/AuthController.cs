using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace updateted1.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(SIGNUP model1)
        {
            using (var context = new ProjectEntities())
            {
                context.SIGNUPs.Add(model1);
                context.SaveChanges();
            }
            return RedirectToAction("Login", "Auth");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login los)
        {
            using (var context = new ProjectEntities())
            {
                bool isValid = context.SIGNUPs.Any(x => x.EmailAddress == los.EmailAddress && x.Password == los.Password);
                if (isValid)
                {
                    ModelState.AddModelError("", "Login thai gyu");
                    return RedirectToAction("Home", "Home");
                }

                ModelState.AddModelError("", "Invalid Username and password");
                return View();

            }
            return RedirectToAction("Login", "Auth");
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace updateted1.Controllers
{
    public class Auth1Controller : Controller
    {
        // GET: Auth1
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(SIGNUP1 si)
        {
            using (var context = new ProjectEntities())
            {
                context.SIGNUP1.Add(si);
                context.SaveChanges();
            }
            return RedirectToAction("Login", "Auth1");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login1 los)
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
            return RedirectToAction("Home", "Home");
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}
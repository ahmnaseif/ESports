using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ESports.Models;

namespace ESports.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            using (var context = new DBESportsEntities1())
            {
                bool isValid = context.Users.Any(x => x.Username == model.Username && x.Password == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("Index", "Players");
                }

                ModelState.AddModelError("", "Invalid username and password");
                return View();
            }
        }

        public ActionResult Signup()
        {
            var roles = new List<string>() { "Player", "Manager" };
            ViewBag.roles = roles;
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User model)
        {
          

            using (var context = new DBESportsEntities1())
            {
                context.Users.Add(model);
                context.SaveChanges();

            }
                return RedirectToAction("Login");
        }

        public ActionResult Logout(User model)
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
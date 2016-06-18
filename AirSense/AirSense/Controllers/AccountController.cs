using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirSense.Models;
using FluentNHibernate;
using NHibernate;
using AirSense.Mappings;
using NHibernate.Linq;

namespace AirSense.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["user"] == null)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                using (ISession session = DBConnect.OpenUserSession())
                {
                    var query = (from x in session.Query<UserViewModel>()
                                 where x.Username == user.Username
                                 select x).FirstOrDefault();
                    if (query != null)
                    {
                        Session["user"] = query;
                        Session["username"] = query.Username;
                        Session["role"] = query.Role;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Combination of username and password doesn't exist.");
                    }
                }
            }
            return View();
        }

    }
}
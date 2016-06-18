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
using System.Text;

namespace AirSense.Controllers
{
    //ヽ༼ຈل͜ຈ༽ﾉ WORDPRESS or RIOT ヽ༼ຈل͜ຈ༽ﾉ

    public class AccountController : Controller
    {
        public static string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        public String CreateSalt(int sizeSalt)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new byte[sizeSalt];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public String GenerateSHA256(String input, String salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA256Managed sha256hashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256hashstring.ComputeHash(bytes);

            return ByteArrayToHexString(hash);
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["user"] == null)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login(UserViewModel user    )
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
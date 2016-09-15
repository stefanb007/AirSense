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

        public String GenerateSHA256(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA256Managed sha256hashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256hashstring.ComputeHash(bytes);

            return ByteArrayToHexString(hash);
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["model"] == null)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (ISession session = DBConnect.OpenUserSession())
                {
                    
                    var checkUsername = (from x in session.Query<UserViewModel>()
                                 where x.Username == model.Username
                                 select x).FirstOrDefault();
                    if (checkUsername == null)
                    {
                        ModelState.AddModelError("Username", "Username not taken.");
                        return View();
                    }
                    string checkPassword = GenerateSHA256(model.Password, checkUsername.Salt);
                    if (checkPassword == checkUsername.HashedPass)
                    {
                        Session["model"] = checkUsername;
                        Session["username"] = checkUsername.Username;
                        //Session["role"] = query.Role;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Combination of username and password doesn't exist.");
                        return View();
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Signup()
        {
            if (Session["user"] == null)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Signup(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                    using (ISession session = DBConnect.OpenUserSession())
                    {
                        using (ITransaction tx = session.BeginTransaction() )
                        {
                            UserViewModel qUserU = new UserViewModel();
                            UserViewModel qUserE = new UserViewModel();
                            qUserU = session.Query<UserViewModel>()
                                .Where(x => x.Username == user.Username)
                                .FirstOrDefault();
                            qUserE = session.Query<UserViewModel>()
                                .Where(x => x.Email == user.Email)
                                .FirstOrDefault();
                            if (qUserU != null || qUserE != null)
                            {
                                if (qUserU != null)
                                { ModelState.AddModelError("Username", "Username has been taken."); }
                                if (qUserE != null)
                                { ModelState.AddModelError("Email", "There exists an account with this email address."); }
                                return View();
                            } else {

                            user.RoleId = "user";
                            user.Id = Guid.NewGuid();
                            user.Salt = CreateSalt(10);
                            user.HashedPass = GenerateSHA256(user.Password, user.Salt);
                            session.Save(user);
                            tx.Commit();
                            return RedirectToAction("Index", "Home");
                            }
                    }
                }
            }
            return View();
        }
    }
}
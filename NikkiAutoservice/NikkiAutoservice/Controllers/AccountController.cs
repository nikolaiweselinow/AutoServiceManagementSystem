using NikkiAutoservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NikkiAutoservice.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (NikkiAutoserviceContext db = new NikkiAutoserviceContext())
            {
                return View(db.userAccount.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using (NikkiAutoserviceContext db = new NikkiAutoserviceContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registered";                   
            }
            return View();
        }
        // Login

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (NikkiAutoserviceContext db = new NikkiAutoserviceContext())
            {
                var usr = db.userAccount.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
                if (usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    Session["Fullname"] = (usr.FirstName + " " + usr.LastName).ToString();
                    //return RedirectToAction("LoggedId");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong!");
                }                 
            }
            return View();
        }

        public ActionResult LoggedId()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            else
            {
                //return RedirectToAction("LoggedId");
                return View("Index", "Home");
            }
        }

        public ActionResult LogOut()
        {
            Session["UserID"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
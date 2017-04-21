using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DPSP_DAL;
using DPSP_BLL;

namespace DPSP_UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult TableOfUsers()
        {
            using (var db = new DboContext())
            {
                return View(db.Users.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DboContext())
                {
                    //user.FormatedPassword = DPSP_BLL.UserManager.CreateHash(user.FormatedPassword);
                    //user.Hash = DPSP_BLL.UserManager.GetHash(user.FormatedPassword);
                    //user.Salt = DPSP_BLL.UserManager.GetSalt(user.FormatedPassword);
                    var usr = db.Users.FirstOrDefault(x => x.Email == user.Email);
                    if (usr != null) return Content("Email already exists.");
                    user.CreatedAt = DateTime.Now;
                    //updatedAt by melo byt jinde(tam kde se upravuje user) a moznost NULL!
                    user.UpdatedAt = DateTime.Now;
                    //BirthDate muzu nejspise odmazat
                    user.BirthDate = DateTime.Now;
                    user.Token = Guid.NewGuid();
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = user.FirstName + " " + user.LastName + " successfully registered.";
            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (var db = new DboContext())
            {
                //pouze jedenkrat mail
                var usr = db.Users.Where(u => u.Email == user.Email).FirstOrDefault();
                if (usr == null || string.IsNullOrWhiteSpace(usr.FormatedPassword)) return Content("Access denied.");
                if (usr != null && DPSP_BLL.UserManager.VerifyPassword(user.FormatedPassword, usr.FormatedPassword))
                {
                    Session["Id"] = usr.Id.ToString();
                    Session["Email"] = usr.Email.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is not correct.");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public ActionResult TestToken()
        {

            return View();
        }

        
        public ActionResult ConfirmationRegistration(Guid? id)
        {
            if (id == null) return Content("Access denied.");
            //BLL getUserByToken
            using (var db = new DboContext())
            {
                var usr = db.Users.FirstOrDefault(x => x.Token == id);
                if (usr == null || !string.IsNullOrWhiteSpace(usr.FormatedPassword)) return Content("Access denied.");
                return View(usr);
            }
        }

        [HttpPost]
        public ActionResult ConfirmationRegistration(User user)
        {
            //nemusis drzet, ale takhle ziskanu token z url
            //String s = Request.QueryString["token"];

            //taky v BLL
            using (var db = new DboContext())
            {
                //getUserByToken()  BLL
                var usr = db.Users.FirstOrDefault(u => u.Token == user.Token);
                usr.FormatedPassword = DPSP_BLL.UserManager.CreateHash(user.FormatedPassword);
                //saveUser 
                db.SaveChanges();
                Session["Id"] = usr.Id.ToString();
                Session["Email"] = usr.Email.ToString();
                return View("LoggedIn");

            }
            //return View();
        }
    }
}
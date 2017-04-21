using DPSP_API.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DPSP_API.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;

        public HomeController()
        {

        }
        
        public HomeController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Index()
        {

        ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult ResetPassword(string code)
        {
            //var model = new ResetPasswordViewModel
            //{
            //    Code = code
            //};
            return code == null ? View("Error") : View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (model != null)
            {
                var code = model.Code.Replace(" ", "+");
                if (!string.IsNullOrWhiteSpace(model.Email))
                {
                    var user = UserManager.FindByName(model.Email);
                    if (user == null)
                    {
                        var error = new IdentityResult("Invalid token.");
                        ViewBag.Error = string.Join("<br/>", error.Errors);
                        return View(model);
                    }

                    if (!string.IsNullOrWhiteSpace(model.Password) && model.Password.Equals(model.ConfirmPassword))
                    {
                        var result = UserManager.ResetPassword(user.Id, code, model.Password);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("NativeAppsPage");
                        }
                        ViewBag.Error = string.Join("<br/>", result.Errors);
                    }
                }
                return View(model);
            }
            else
            {
                return View();
            }
        }

        public ActionResult NativeAppsPage()
        {
            return View();
        }
    }
}

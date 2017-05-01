using DPSP_API.Models;
using DPSP_BLL;
using DPSP_BLL.Models;
using DPSP_DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DPSP_API.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;
        private IAccountService accountService;

        public HomeController()
        {

        }

        public HomeController(IAccountService accountService)
        {
            this.accountService = accountService;
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

        public ActionResult ResetPassword(string code, bool nameAlready)
        {
            var model = new ResetPasswordViewModel
            {
                Code = code,
                NameAlready = nameAlready,
                Error = new ErrorModel() { ErrorValue = null },
                RedirectToAction = new RedirectToActionModel() { }
            };
            return code == null ? View("Error") : View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            var serviceModel = accountService.ResetPassword(model, UserManager);
            if (serviceModel == null) return View();
            if (!string.IsNullOrWhiteSpace(serviceModel.RedirectToAction.RedirectValue)) return RedirectToAction(serviceModel.RedirectToAction.RedirectValue);
            if(!string.IsNullOrWhiteSpace(serviceModel.Error.ErrorValue)) ViewBag.Error = serviceModel.Error.ErrorValue;
            return View(serviceModel);

            //    if (model != null)
            //    {
            //        var code = model.Code.Replace(" ", "+");
            //        if (!string.IsNullOrWhiteSpace(model.Email))
            //        {

            //            var user = UserManager.FindByName(model.Email);
            //            if (user == null)
            //            {
            //                var error = new IdentityResult("Invalid token.");
            //                ViewBag.Error = string.Join("<br/>", error.Errors);
            //                return View(model);
            //            }
            //            if (model.AddName != null)
            //            {
            //                using (var db = new DboContext())
            //                {
            //                    var dbUser = db.Users.FirstOrDefault(x => x.AspNetUsersId == user.Id);
            //                    dbUser.FirstName = model.AddName.FirstName;
            //                    dbUser.LastName = model.AddName.LastName;
            //                    db.SaveChanges();
            //                }
            //            }
            //            if (!string.IsNullOrWhiteSpace(model.Password) && model.Password.Equals(model.ConfirmPassword))
            //            {
            //                var result = UserManager.ResetPassword(user.Id, code, model.Password);
            //                if (result.Succeeded)
            //                {
            //                    return RedirectToAction("NativeAppsPage");
            //                }
            //                ViewBag.Error = string.Join("<br/>", result.Errors);
            //            }
            //        }
            //        return View(model);
            //    }
            //    else
            //    {
            //        return View();
            //    }
        }

        public ActionResult NativeAppsPage()
        {
            return View();
        }
    }
}

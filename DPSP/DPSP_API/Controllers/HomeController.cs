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
        }

        public ActionResult NativeAppsPage()
        {
            return View();
        }
    }
}

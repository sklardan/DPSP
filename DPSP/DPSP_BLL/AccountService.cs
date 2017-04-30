using DPSP_BLL.Models;
using System.Web.Http;
using System.Net.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System;
using Microsoft.Owin.Host.SystemWeb;
using System.Web;
using DPSP_DAL;

namespace DPSP_BLL
{
    public class AccountService : IAccountService
    {
        protected readonly IUserService userService;

        //private ApplicationUserManager _userManager;

        public AccountService()
        {
        }

        public AccountService(IUserService userService)
        {
            this.userService = userService;
        }

        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}    

        public async Task<string> Creation(CreateUserBindingModel model, ApplicationUserManager userManager, Uri uri)
        {
            var tryUser = userManager.FindByEmail(model.Email);
            if (tryUser == null)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, EmailConfirmed = true };
                var result = await userManager.CreateAsync(user); // Create without password.
                if (result.Succeeded)
                {
                    bool nameAlready = false;
                    var dbUser = userService.GetUser(user.Id);
                    dbUser = (dbUser == null) ? userService.CreateUser(user.Id, model.Role) : dbUser;
                    if (!string.IsNullOrEmpty(model.FirstName) && !string.IsNullOrEmpty(model.LastName))
                    {
                        userService.AddNames(dbUser, model.FirstName, model.LastName);
                        nameAlready = true;
                    }
                    var htmlBody = await RedirectToCompleteCreation(user, nameAlready, userManager, uri);
                    return $"User created and here is code for reset password: {htmlBody}";

                    //MAIL SENDING IS WORKING
                    //await SendActivationMail(user, NameAlready);
                    //return RedirectToAction("CreateConfirmation");
                }
            }
            else
            {
                var htmlBody = await RedirectToCompleteCreation(tryUser, false, userManager, uri);
                return $"User created and here is code for reset password: {htmlBody}";
            }
            return "Not succeed";
        }

        private async Task<string> RedirectToCompleteCreation(ApplicationUser user, bool nameAlready, ApplicationUserManager userManager, Uri uri)
        {
            string code = await userManager.GeneratePasswordResetTokenAsync(user.Id);
            //var authority = new Uri(Request.RequestUri.GetLeftPart(UriPartial.Authority));
            var path = new Uri(uri, $"Home/ResetPassword/?code={code}&NameAlready={nameAlready}");
            string body = @"<h4>Welcome to my system!</h4><p>To get started, please <a href='" + path.AbsoluteUri + "'>activate</a> your account.</p><p>The account must be activated within 24 hours from receving this mail.</p>";
            return body;
        }

    }
}

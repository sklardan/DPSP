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
using System.Linq;

namespace DPSP_BLL
{
    public class AccountService : IAccountService
    {
        protected readonly IUserService userService;

        public AccountService()
        {
        }

        public AccountService(IUserService userService)
        {
            this.userService = userService;
        }

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

        public async Task<string> Register(RegisterBindingModel model, ApplicationUserManager userManager)
        {
            var aspUser = new ApplicationUser() { UserName = model.Email, Email = model.Email };
            IdentityResult result = await userManager.CreateAsync(aspUser, model.Password);
            if (!result.Succeeded)
            {
                return "Registering employee not succeded.";
            }
            var dbUser = userService.CreateUser(aspUser.Id, nameof(RoleType.Employee));
            userService.AddNames(dbUser, model.AddName.FirstName, model.AddName.LastName);

            return "Employee was registered.";
        }

        public ResetPasswordViewModel ResetPassword(ResetPasswordViewModel model, ApplicationUserManager userManager)
        {
            if (model != null)
            {
                model.Error = new ErrorModel();
                model.RedirectToAction = new RedirectToActionModel();
                var code = model.Code.Replace(" ", "+");
                if (!string.IsNullOrWhiteSpace(model.Email))
                {
                    var aspUser = userManager.FindByName(model.Email);
                    if (aspUser == null)
                    {
                        var error = new IdentityResult("Invalid token.");
                        model.Error.ErrorValue = string.Join("<br/>", error.Errors);
                        return model;
                    }
                    if (!string.IsNullOrWhiteSpace(model.Password) && model.Password.Equals(model.ConfirmPassword))
                    {
                        if (!model.NameAlready && (string.IsNullOrWhiteSpace(model.AddName.FirstName) || string.IsNullOrWhiteSpace(model.AddName.LastName))) return model;
                        var result = userManager.ResetPassword(aspUser.Id, code, model.Password);
                        if (result.Succeeded)
                        { 
                            if (model.AddName != null)
                            {
                                var dbUser = userService.GetUser(aspUser.Id);
                                userService.AddNames(dbUser, model.AddName.FirstName, model.AddName.LastName);
                                //using (var db = new DboContext())
                                //{
                                //    var dbUser = db.Users.FirstOrDefault(x => x.AspNetUsersId == aspUser.Id);
                                //    dbUser.FirstName = model.AddName.FirstName;
                                //    dbUser.LastName = model.AddName.LastName;
                                //    db.SaveChanges();
                                //}
                            }
                            model.RedirectToAction.RedirectValue = "NativeAppsPage";
                            return model;
                            //return RedirectToAction("NativeAppsPage");
                        }
                        model.Error.ErrorValue = string.Join("<br/>", result.Errors);
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }

    }
}

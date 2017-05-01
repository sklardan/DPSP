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
    public class ShareService : IShareService
    {
        protected readonly IUserService userService;
        protected readonly IAccountService accountService;

        public ShareService()
        {
        }

        public ShareService(IUserService userService, IAccountService accountService)
        {
            this.userService = userService;
            this.accountService = accountService;
        }

        public async Task<string> ShareProject(EmailViewModel model, ApplicationUserManager userManager, Uri uri)
        {
            if (userManager.Users.Any(x => x.Email == model.Email))
            {
                var aspUser = userManager.Users.FirstOrDefault(x => x.Email == model.Email);
                    if (model.ProjectIds.Count() > 0)
                    {
                        userService.AddProject(userService.GetUser(aspUser.Id), model.ProjectIds);
                    }
                return "Sharing sucessful.";
            }
            else
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, EmailConfirmed = true };
                var result = await userManager.CreateAsync(user); // Create without password.
                if (result.Succeeded)
                {
                    var userDb = userService.CreateUser(user.Id, nameof(RoleType.Client));
                    if (model.ProjectIds.Count() > 0)
                    {
                        userService.AddProject(userDb, model.ProjectIds);
                    }
                    //var newUrl = this.Url.Link("Default", new { Controller = "Account", Action = "Creation" });
                    //var url = RedirectToRoute("api/Account/Creation", new CreateUserBindingModel() { Email = model.Email, Role = nameof(RoleType.Client)});
                    //Request.CreateResponse(HttpStatusCode.OK, new { Success = true, RedirectUrl = newUrl });
                    return await accountService.Creation((new CreateUserBindingModel() { Email = model.Email, Role = nameof(RoleType.Client) }), userManager, uri);
                }
                return "Making new user and sending him an email not succeed.";
            }
        }

    }
}

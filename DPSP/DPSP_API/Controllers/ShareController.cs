using DPSP_API.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Http;
using DPSP_BLL;
using DPSP_DAL;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using DPSP_BLL.Models;
using System;

namespace DPSP_API.Controllers
{
    public class ShareController : ApiController
    {
        private ApplicationUserManager _userManager;
        private IUserService userService;
        private IAccountService accountService;

        public ShareController()
        {

        }

        public ShareController(/*ApplicationUserManager userManager,*/ IUserService userService, IAccountService accountService)
        {
            //UserManager = userManager;
            this.userService = userService;
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

        // POST: Api/Share/ShareProject
        [HttpPost]
        [Route("shareproject")]
        public async Task<IHttpActionResult> ShareProject(EmailViewModel model)
        {
            if (UserManager.Users.Any(x => x.Email == model.Email))
            {
                var aspUser = UserManager.Users.FirstOrDefault(x => x.Email == model.Email);
                using (var db = new DboContext())
                {
                    var userDb = db.Users.FirstOrDefault(x => x.AspNetUsersId == aspUser.Id);
                    if (model.ProjectIds.Any())
                    {
                        foreach (var item in model.ProjectIds)
                        {
                            userDb.Projects.Add(db.Projects.FirstOrDefault(x => x.IsActive && x.Id == item));
                        }
                        db.SaveChanges();
                    }
                }
                return Ok("Sharing sucessful.");
            }
            else
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, EmailConfirmed = true };
                var result = await UserManager.CreateAsync(user); // Create without password.
                if (result.Succeeded)
                {
                    var userDb = userService.CreateUser(user.Id, nameof(RoleType.Client));
                    if (model.ProjectIds.Any())
                    {
                        userDb = userService.AddProject(userDb, model.ProjectIds);
                    }
                    //var newUrl = this.Url.Link("Default", new { Controller = "Account", Action = "Creation" });
                    //var url = RedirectToRoute("api/Account/Creation", new CreateUserBindingModel() { Email = model.Email, Role = nameof(RoleType.Client)});
                    //Request.CreateResponse(HttpStatusCode.OK, new { Success = true, RedirectUrl = newUrl });
                    return Ok(await accountService.Creation((new CreateUserBindingModel() { Email = model.Email, Role = nameof(RoleType.Client) }), UserManager, new Uri(Request.RequestUri.GetLeftPart(UriPartial.Authority))));
                }
                return Ok("Making new user and sending him an email not succeed.");
                }
            //return Ok("Not completed.");
        }

    }
}

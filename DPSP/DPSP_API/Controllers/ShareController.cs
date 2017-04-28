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

namespace DPSP_API.Controllers
{
    public class ShareController : ApiController
    {
        private ApplicationUserManager _userManager;
        private IUserService userService;

        public ShareController()
        {

        }

        public ShareController(ApplicationUserManager userManager, IUserService userService)
        {
            UserManager = userManager;
            this.userService = userService;
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
        public IHttpActionResult ShareProject(EmailViewModel model)
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
                var userDb = userService.CreateUser(user.Id, nameof(RoleType.Client));
                userService.AddProject(userDb, model.ProjectIds);
                RedirectToRoute("Account/Creation", new CreateUserBindingModel() { Email = model.Email, Role = nameof(RoleType.Client)});
                return Ok("Send for creation with already shared your projects");
            }
            //return Ok("Not completed.");
        }

    }
}

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
        private IShareService shareService;

        public ShareController(){}

        public ShareController(IShareService shareService)
        {
            this.shareService = shareService;
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
            return Ok(await shareService.ShareProject(model, UserManager, new Uri(Request.RequestUri.GetLeftPart(UriPartial.Authority))));
        }

    }
}

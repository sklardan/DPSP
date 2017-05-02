using DPSP_BLL.Models;
using System;
using System.Threading.Tasks;

namespace DPSP_BLL
{
    public interface IShareService
    {
        /// <summary>
        /// ShareProject shares projects to existing user or new user. In that case it will call creation which send email to user to create himself already with projects.
        /// </summary>
        /// <param name="model">Accepting email and IList<Guid> ProjectIds, which are ids of sharing projects.</Guid></param>
        /// <param name="userManager">User manager for microsoft identity.</param>
        /// <param name="Uri">Servers url, which will be sent in email for reseting password.</param>
        /// <returns>Returns string for View call about succesful sharing or not.</returns>
        Task<string> ShareProject(EmailViewModel model, ApplicationUserManager userManager, Uri uri);
    }
}
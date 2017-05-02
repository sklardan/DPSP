using DPSP_BLL.Models;
using DPSP_DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DPSP_BLL
{
    public interface IAccountService
    {
        /// <summary>
        /// Creation will create new client or employee and send him email about adding his own password. 
        /// </summary>
        /// <param name="model">Accepting email, first name, last name and role.</param>
        /// <param name="userManager">User manager for microsoft identity.</param>
        /// <param name="Uri">Servers url, which will be sent in email for reseting password.</param>
        /// <returns>Returns string for View about succesful or not succesful creation.</returns>
        Task<string> Creation(CreateUserBindingModel model, ApplicationUserManager userManager, Uri uri);

        /// <summary>
        /// ResetPassword is method called from creation which will set users password after clicking on url sent by mail.
        /// </summary>
        /// <param name="model">Accepting email, password, confirm password, code for reseting password, bool namealready if user has already first and last name, AddNameModel with first and last name, ErrorModel if there is any error and RedirectToActionModel for redirecting</param>
        /// <param name="userManager">User manager for microsoft identity.</param>
        /// <returns>Returns ResetPasswordViewModel with errors if any.</returns>
        ResetPasswordViewModel ResetPassword(ResetPasswordViewModel model, ApplicationUserManager userManager);

        /// <summary>
        /// Register is simple registration only for employees with all projects.
        /// </summary>
        /// <param name="model">Accepting email, password, confirm password and AddNameModel with first and last name.</param>
        /// <param name="userManager">User manager for microsoft identity.</param>
        /// <returns>What this method returns.</returns>
        Task<string> Register(RegisterBindingModel model, ApplicationUserManager userManager);
    }
}

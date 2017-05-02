using DPSP_UI_LG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DPSP_UI_LG.Services
{
    public interface IAccountService
    {
        /// <summary>
        /// Create will send serialized model json data to API through POST request to create user and return content from API 
        /// </summary>
        /// <param name="model">User's email, first name, last name and role. (strings)</param>
        /// <returns>Returns string content from API</returns>
        Task<string> Create(CreateUserModel model);

        /// <summary>
        /// Create will send POST request to API for log off user and clear identity data (bearer_token etc.) in client. 
        /// </summary>
        void LogOff();

        /// <summary>
        /// ResetPassword will send POST request for reseting password from user to API with json data and return content from API.
        /// </summary>
        /// <param name="model">User's email, password, confirm password and code for reset password. (strings)</param>
        /// <returns>Returns content from API about succesful or not succesful reseting password..</returns>
        Task<string> ResetPassword(ResetPasswordViewModel model);

        /// <summary>
        /// ResetPassword will send POST request for register user (only employee) to API with json data and return content from API.
        /// </summary>
        /// <param name="model">User's email, password, confirm password and AddNameModel with first and last name. (strings)</param>
        /// <returns>Returns string for View about succesful or not succesful register from API.</returns>
        Task<string> Register(RegisterViewModel model);

        /// <summary>
        /// Login will send POST request for log in user to API with data and return content from API.
        /// </summary>
        /// <param name="model">User's email and password. (strings)</param>
        /// /// <param name="model">User's email and password. (strings)</param>
        /// <returns>Returns string for View about succesful or not succesful login from API.</returns>
        Task<string> Login(LoginViewModel model, string returnUrl);
    }
}
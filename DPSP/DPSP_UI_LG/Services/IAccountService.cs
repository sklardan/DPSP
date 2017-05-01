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
        Task<string> Create(CreateUserModel model);
        void LogOff();
        Task<string> ResetPassword(ResetPasswordViewModel model);
        Task<string> Register(RegisterViewModel model);
        Task<string> Login(LoginViewModel model, string returnUrl);
    }
}
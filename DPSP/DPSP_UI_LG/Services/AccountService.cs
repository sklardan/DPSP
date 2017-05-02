using DPSP_UI_LG.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DPSP_UI_LG.Services
{
    public class AccountService : IAccountService
    {
        public async Task<string> Create(CreateUserModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var url = Path.Combine(Configuration.DPSP_API_SERVER, "api/Account/Creation");
            //var data = $"Email={model.Email}&FirstName={model.FirstName}&LastName={model.LastName}&Role={model.Role}";
            var content = await Helpers.Request.ToApi(jsonData, url, Helpers.ApiRequesType.POST);
            return content.ToString();
        }

        public void LogOff()
        {
            var url = Path.Combine(Configuration.DPSP_API_SERVER, "api/Account/Logout");
            var content = Helpers.Request.ToApi(null, url, Helpers.ApiRequesType.POST);
            Helpers.Ident.Clear();
        }

        public async Task<string> ResetPassword(ResetPasswordViewModel model)
        {
            var url = Path.Combine(Configuration.DPSP_API_SERVER, "api/Account/ResetPassword");
            var jsonData = JsonConvert.SerializeObject(model);
            //var data = $"Email={model.Email}&Password={model.Password}&ConfirmPassword={model.ConfirmPassword}&Code={model.Code}";
            var content = await Helpers.Request.ToApi(jsonData, url, Helpers.ApiRequesType.POST);
            return content.ToString();
        }

        public async Task<string> Register(RegisterViewModel model)
        {
            var url = Path.Combine(Configuration.DPSP_API_SERVER, "api/Account/Register");
            var jsonData = JsonConvert.SerializeObject(model);
            //var data = $"Email={model.Email}&Password={model.Password}&ConfirmPassword={model.ConfirmPassword}";
            var content = await Helpers.Request.ToApi(jsonData, url, Helpers.ApiRequesType.POST);
            return content.ToString();
        }

        public async Task<string> Login(LoginViewModel model, string returnUrl)
        {
            var url = Path.Combine(Configuration.DPSP_API_SERVER, "Token");
            //var jsonDataModel = JsonConvert.SerializeObject(model);
            var data = $"grant_type=password&username={model.Email}&password={model.Password}";
            //var jsonData = JsonConvert.SerializeObject(data);
            var content = await Helpers.Request.ToApi(data, url, Helpers.ApiRequesType.POST);
            JavaScriptSerializer oJS = new JavaScriptSerializer();
            var tokenModel = new TokenModel();
            try
            {
                tokenModel = oJS.Deserialize<TokenModel>(content);
            }
            catch (Exception ex)
            {
                return "Error";
                //Content($"{ex.Message} Response from server API: '{content}'");
            }
            Helpers.Ident.Set(tokenModel);
            return "ConfirmLogin";
        }

    }
}
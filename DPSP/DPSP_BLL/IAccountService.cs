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
        Task<string> Creation(CreateUserBindingModel model, ApplicationUserManager userManager, Uri uri);
    }
}

using DPSP_BLL.Models;
using System;
using System.Threading.Tasks;

namespace DPSP_BLL
{
    public interface IShareService
    {
        Task<string> ShareProject(EmailViewModel model, ApplicationUserManager userManager, Uri uri);
    }
}
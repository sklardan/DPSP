using DPSP_UI_LG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DPSP_UI_LG.Services
{
    public interface IProjectService
    {
        Task<ListProjectViewModel> GetProject();
        Task<string> Share(EmailViewModel model);
    }
}
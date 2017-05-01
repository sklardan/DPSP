using DPSP_BLL.Models;
using DPSP_DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSP_BLL
{
    public interface IProjectService
    {
        IEnumerable<Project> GetUserProjects(string aspUserId);
        IEnumerable<ProjectViewModel> RetypeToProjectViewModel(IEnumerable<Project> userProjects, IEnumerable<Role> roleType);
        IEnumerable<ProjectViewModel> GetProjectViewModels(ApplicationUserManager userManager, string userName);
    }
}

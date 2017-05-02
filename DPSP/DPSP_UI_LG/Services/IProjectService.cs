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
        /// <summary>
        /// GetProject will send username data to API through json and url and deserialize returned data to ProjectViewModel.
        /// </summary>
        /// <returns>Returns list of ProjectViewModels.</returns>
        Task<ListProjectViewModel> GetProject();

        /// <summary>
        /// Share will share project by sending request to API with json data model.
        /// </summary>
        /// <param name="model">User's email, whose should be shared with and projects ids of projects, which should be shared.</param>
        /// <returns>Returns string for View about succesful or not succesful creation from API.</returns>
        Task<string> Share(EmailViewModel model);
    }
}
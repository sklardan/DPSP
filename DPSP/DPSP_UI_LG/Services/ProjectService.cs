using DPSP_UI_LG.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DPSP_UI_LG.Services
{
    public class ProjectService : IProjectService
    {
        public async Task<ListProjectViewModel> GetProject()
        {
            string data = string.Empty;
            if (Helpers.Ident.IsLogged) data = $"userName={Helpers.Ident.Get().userName}" ?? string.Empty;
            string jsonData = string.Empty;
            if (!string.IsNullOrWhiteSpace(data)) jsonData = JsonConvert.SerializeObject(data);
            //var filter = "$filter=Department eq 'Law'";
            //var filter = "$select=Name";
            var filter = string.Empty;
            var url = Path.Combine(Configuration.DPSP_API_SERVER, $"odata/Project?{data}&{filter}");
            var content = await Helpers.Request.ToApi(jsonData, url);
            try
            {
                var comingOdata = JsonConvert.DeserializeObject<ODataProject>(content);
                var project = comingOdata.Projects.Select(x => new ProjectViewModel()
                {
                    ProjectId = x.ProjectId,
                    Name = x.Name,
                    Department = x.Department,
                    Client = x.Client,
                    Manager = x.Manager,
                    Employees = x.Employees,
                    Introduction = x.Introduction,
                    Content = x.Content,
                    Conclusion = x.Conclusion,
                    Budget = x.Budget,
                    OpenDate = x.OpenDate,
                    CloseDate = x.CloseDate,
                    ForShare = x.ForShare
                }).ToList();
                var listOfProjects = new ListProjectViewModel()
                {
                    ProjectViewModels = project
                };
                //if (comingOdata.Projects.Count == 0) listOfProjects = null;
                return listOfProjects;
            }
            catch (Exception ex)
            {
                return null;
                //Content($"{ex.Message} Response from server API: '{content}'");
            }
        }

        public async Task<string> Share(EmailViewModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            //var data = jsonData;
            var url = Path.Combine(Configuration.DPSP_API_SERVER, $"api/share/shareproject");
            var content = await Helpers.Request.ToApi(jsonData, url, Helpers.ApiRequesType.POST);

            return content;
        }
    }
}
using DPSP_UI_LG.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DPSP_UI_LG.Controllers
{
    public class ProjectController : Controller
    {
        //
        // GET: /Project/GetProject
        [AllowAnonymous]
        public async Task<ActionResult> GetProject()
        {
            string data = string.Empty;
            if (Helpers.Ident.IsLogged) data = $"userName={Helpers.Ident.Get().userName}" ?? string.Empty;
            //var filter = "$filter=Department eq 'Law'";
            //var filter = "$select=Name";
            var filter = string.Empty;
            var url = $"http://localhost:63705/odata/Project?{data}&{filter}";
            var content = await Helpers.Request.ToApi(data, url);
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
                if (comingOdata.Projects.Count == 0) project = null;
                return View(listOfProjects);
            }
            catch (Exception ex)
            {
                return View("Error");
                    //Content($"{ex.Message} Response from server API: '{content}'");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult GetProject(ListProjectViewModel model)
        {
            var projects = model.ProjectViewModels.Where(x => x.ForShare);
            var projectIds = new List<Guid>();
            foreach(var item in projects)
            {
                projectIds.Add(item.ProjectId);
            }
            var emailViewModel = new EmailViewModel()
            {
                ProjectIds = projectIds
            };
            return View("Share", emailViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Share(EmailViewModel model)
        {
            var jsonData = JsonConvert.SerializeObject(model);
            var data = jsonData;
            var url = $"http://localhost:63705/api/share/shareproject?{data}";
            var content = await Helpers.Request.ToApi(data, url, Helpers.ApiRequesType.POST);

            return Content(content);
        }
    }
}
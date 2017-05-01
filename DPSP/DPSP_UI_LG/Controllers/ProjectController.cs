using DPSP_UI_LG.Models;
using DPSP_UI_LG.Services;
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
        private IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        //
        // GET: /Project/GetProject
        [AllowAnonymous]
        public async Task<ActionResult> GetProject()
        {
            var projects = await projectService.GetProject();
            return (projects == null) ? View("Error") : View(projects);
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
            return Content(await projectService.Share(model));
            //var jsonData = JsonConvert.SerializeObject(model);
            //var data = jsonData;
            //var url = $"http://localhost:63705/api/share/shareproject?{data}";
            //var content = await Helpers.Request.ToApi(data, url, Helpers.ApiRequesType.POST);

            //return Content(content);
        }
    }
}
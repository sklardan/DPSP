using DPSP_UI_LG.Models;
using Newtonsoft.Json;
using System;
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
            var filter = string.Empty;
            var url = $"http://localhost:63705/odata/Project?{data}&{filter}";
            var content = await Helpers.Request.ToApi(data, url);
            try
            {
                var comingOdata = JsonConvert.DeserializeObject<ODataProject>(content);
                var project = comingOdata.Project.Select(x => new ProjectViewModel()
                {
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
                });
                if (comingOdata.Project.Count == 0) project = null;
                return View(project);
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
        public ActionResult GetProject(ProjectViewModel model)
        {
            var projects = model;
            return View("Share");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Share(EmailViewModel model)
        {
            return View("Confirmation");
        }
    }
}
﻿using DPSP_API.Models;
using DPSP_BLL;
using DPSP_DAL;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Data.OData;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace DPSP_API.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.
    */
    [Authorize]
    //[ODataRouting]
    public class ProjectController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        private IProjectService projectService;

        private ApplicationUserManager _userManager;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: odata/Project
        [EnableQuery]
        public IHttpActionResult GetProject(ODataQueryOptions<Project> queryOptions,string userName)
        {
            return Ok(projectService.GetProjectViewModels(UserManager,userName));
        }

        //// POST: Api/odata/ShareProject
        //[HttpPost]
        ////[Route("({model})")]
        //public IHttpActionResult Post(ODataQueryOptions<Project> queryOptions, EmailViewModel model)
        //{
        //}

        // GET: odata/Project(5)
        public IHttpActionResult GetProject([FromODataUri] System.Guid key, ODataQueryOptions<Project> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<Project>(project);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/Project(5)
        public IHttpActionResult Put([FromODataUri] System.Guid key, Delta<Project> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(project);

            // TODO: Save the patched entity.

            // return Updated(project);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Project
        public IHttpActionResult Post(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(project);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Project(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] System.Guid key, Delta<Project> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(project);

            // TODO: Save the patched entity.

            // return Updated(project);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Project(5)
        public IHttpActionResult Delete([FromODataUri] System.Guid key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}

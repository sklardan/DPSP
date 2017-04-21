using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using DPSP_DAL;
using DPSP_BLL;
using Microsoft.Data.OData;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DPSP_API.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using DPSP_DAL;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Project>("Project");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    [Authorize]
    public class ProjectController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        //private IProjectService service;

        private ApplicationUserManager _userManager;

        //public ProjectController() { }

        //public ProjectController(IProjectService service)
        //{
        //    this.service = service;
        //}

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
            var service = new ProjectService();
            var aspUser = UserManager.Users.FirstOrDefault(x => x.UserName == userName);
            var projects = service.GetUserProjects(aspUser.Id);
            return Ok(projects);
        }

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

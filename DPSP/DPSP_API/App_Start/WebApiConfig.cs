using DPSP_DAL;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;

namespace DPSP_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = UnityConfig.GetConfiguredContainer();
            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            //config.MapHttpAttributeRoutes();

            //enabling cross-origin requests
            var cors = new EnableCorsAttribute("http://localhost:65075", "*", "*");
            cors.SupportsCredentials = true;
            config.EnableCors(cors);
            //config.EnableCors();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Project>(typeof(Project).Name);
            builder.EntitySet<User>(typeof(User).Name);
            builder.EntitySet<Role>(typeof(Role).Name);
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());



        }
    }
}

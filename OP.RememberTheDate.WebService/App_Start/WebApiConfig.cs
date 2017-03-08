using System.Web.Http;
using OP.RememberTheDate.WebService.Filters;

namespace OP.RememberTheDate.WebService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            RegisterFilters(config);
            MapRoutes(config);
        }

        private static void RegisterFilters(HttpConfiguration config)
        {
            config.Filters.Add(new ValidateModelAttribute());
        }

        private static void MapRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { controller = "Date", action = "Register" }
                );
        }
    }
}

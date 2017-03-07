using System.Web.Http;

namespace OP.RememberTheDate.WebService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            MapRoutes(config);
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

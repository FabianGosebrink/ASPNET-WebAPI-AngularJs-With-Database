using System.Net.Http.Formatting;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AngularJsDemoAppWithDb.Startup))]

namespace AngularJsDemoAppWithDb
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseWelcomePage();
            var config = new HttpConfiguration();

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);
        }
    }
}

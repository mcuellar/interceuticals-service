using InterceuticalsService.Extenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace InterceuticalsService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Clear XML formatter as dedfault formatter
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            //Support for XML Response
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping("xml", "true", "text/xml"));

            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Register ValidateModelState for all API calls to validate data being POSTED
            config.Filters.Add(new ValidateModelAttribute());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PragatiAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Clear();
            string s = System.Configuration.ConfigurationManager.AppSettings.Get("webpages:Version");

            // Web API configuration and services POST, GET, OPTIONS, PATCH
            var cors = new EnableCorsAttribute("*", "*", "*");
            //var cors = new EnableCorsAttribute("*", "accept,content-type,origin,x-my-header", "*");
            config.EnableCors(cors);
            // Web API configuration and services
            config.Formatters.Add(new JsonMediaTypeFormatter());
       
          //  config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
          name: "ActionApi",
          routeTemplate: "api/{controller}/{action}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );

            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new {id = RouteParameter.Optional }
           );
         


          
         

           
           // config.Routes.MapHttpRoute(
           //    name: "ActionApi",
           //    routeTemplate: "api/{controller}/{action}/{id}",
           //    defaults: new { id = RouteParameter.Optional }
           //);
        }
    }
}

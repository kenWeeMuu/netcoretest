using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Owin;

namespace net_ef_training
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder) {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Newtonsoft.Json.Formatting.Indented;
            settings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}
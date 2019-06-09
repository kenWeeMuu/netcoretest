using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace net_ef_training
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.SetCorsPolicyProviderFactory(new CorsPolicyFactory());
          //  var cors = new EnableCorsAttribute("localhost:9000", "*", "*");
            config.EnableCors();

            // Web API 配置和服务
            //  config.EnableCors();
            //  config.Filters.Add(new Cores());
            // Web API 路由
            config.MapHttpAttributeRoutes();
            config.SetCorsPolicyProviderFactory(new CorsPolicyFactory());
            //  var cors = new EnableCorsAttribute("localhost:9000", "*", "*");
            config.EnableCors();

            // Web API 配置和服务
            //  config.EnableCors();
            //  config.Filters.Add(new Cores());
            // Web API 路由
     
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            

        }
    }
}

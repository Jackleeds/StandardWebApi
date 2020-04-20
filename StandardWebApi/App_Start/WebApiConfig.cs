using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace StandardWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //跨域配置
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //自定义路由
            config.Routes.MapHttpRoute(
               name: "ActionApi",
               routeTemplate: "api/{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );
            //移除xml返回格式数据
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            //配置返回的时间类型数据格式  
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(
                new Newtonsoft.Json.Converters.IsoDateTimeConverter()
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
                }
            );
        }
    }
}

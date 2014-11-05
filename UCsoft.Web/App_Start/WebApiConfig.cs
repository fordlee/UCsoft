using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace UCsoft.Web
{
    /// <summary>
    /// Class WebApiConfig.
    /// 2014-10-13 02:05:08 修改 By 唐有炜
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            //Rpc方式的API
            //config.Routes.MapHttpRoute(
            //  name: "DefaultRpcApi",
            //   routeTemplate: "api/{controller}/{action}/{id}",
            //   defaults: new { id = RouteParameter.Optional }
            //);


            //注册Route（Web API支持Session）
            RouteTable.Routes.MapHttpRoute(
                name: "DefaultRpcApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
                ).RouteHandler = new SessionStateRouteHandler();


            //RestFul方式的API
            //config.Routes.MapHttpRoute(
            //    name: "DefaultRestApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            //config.EnableSystemDiagnosticsTracing();

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("format", "json", "application/json"));
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("format", "xml", "application/xml"));
        }
    }
}
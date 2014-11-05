using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace UCsoft.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    //public class MvcApplication : Spring.Web.Mvc.SpringMvcApplication
    {
        protected void Application_Start()
        {

            //注册区域
            AreaRegistration.RegisterAllAreas();
            //注册WebApi
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            //注册过滤器
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //注册路由
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //测试路由
            //RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);
            //注册捆绑压缩
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //配置全局设置
            Configure(GlobalConfiguration.Configuration);
        }






        /// <summary>
        ///配置全局设置
        /// </summary>
        /// <param name="config">config</param>
        protected static void Configure(HttpConfiguration config)
        {

            #region  日期返回格式化

            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            var timeConverter = new IsoDateTimeConverter();
            //这里使用自定义日期格式，如果不使用的话，默认是ISO8601格式     
            timeConverter.DateTimeFormat = "yyyy-MM-dd";
            json.SerializerSettings.Converters.Add(timeConverter);

            #endregion

        }

    }
}
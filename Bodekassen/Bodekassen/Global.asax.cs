using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Bodekassen
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{
        //    List<string> domains = new List<string> { "http://192.168.87.106:8100", "http://localhost:8100", "http://bodekassen.azurewebsites.net/" };

        //    string test = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
        //    string test2 = HttpContext.Current.Request.ServerVariables["SERVER_NAME"].ToString();
        //    string test3 = null;
        //    if (HttpContext.Current.Request.UrlReferrer != null)
        //    {
        //        test3 = HttpContext.Current.Request.UrlReferrer.ToString();
        //    }
        //    string port = HttpContext.Current.Request.ServerVariables["SERVER_PORT"].ToString();

        //    HttpContext.Current.Response.Headers.Remove("Access-Control-Allow-Origin");

        //    if (test3 != null && test3.Contains("localhost:8000"))
        //    {
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:8100");
        //    }
        //    else if (test3 != null && test3.Contains("localhost:8100"))
        //    {
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:8100");
        //    }
        //    else if (port.Contains("52011"))
        //    {
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:8100");
        //    }
        //    else if (test2.Contains("localhost"))
        //    {
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:" + port);
        //    }
        //    else if (test2.Contains("192.168.87.106"))
        //    {
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://192.168.87.106:8100");
        //    }
        //    else
        //    {
        //        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:8100");
        //    }

        //    if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
        //    {
        //        Response.Flush();
        //        Response.End();
        //    }
        //}

    }
}

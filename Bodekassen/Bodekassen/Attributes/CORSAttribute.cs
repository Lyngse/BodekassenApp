using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bodekassen.Attributes
{
    public class CORSAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var domains = new List<string> { "http://localhost:8100/", "http://bodekassen.azurewebsites.net/" };
            string test2 = filterContext.HttpContext.Request.ServerVariables["SERVER_NAME"].ToString();
            string port = filterContext.HttpContext.Request.ServerVariables["SERVER_PORT"].ToString();

            filterContext.HttpContext.Response.Headers.Remove("Access-Control-Allow-Origin");
            filterContext.HttpContext.Response.AddHeader("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
            filterContext.HttpContext.Response.AddHeader("Access-Control-Allow-Methods", "POST, GET, OPTIONS");
            filterContext.HttpContext.Response.AddHeader("Access-Control-Allow-Credential", "true");

            if (domains.Contains(filterContext.RequestContext.HttpContext.Request.UrlReferrer.Host))
            {
                filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", domains.ToString());
            }

            base.OnActionExecuting(filterContext);
        }

    }
}
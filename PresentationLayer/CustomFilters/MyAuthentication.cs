using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace PresentationLayer.CustomFilters
{
    public class MyAuthentication : ActionFilterAttribute
    {
        public string BasicRealm { get; set; }
        protected string Username { get; set; }
        protected string Password { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var req = filterContext.HttpContext.Request;

            //IMPLEMENT AUTHENTICATION HERE

            //var auth = req.Headers["Authorization"];
            //if (!String.IsNullOrEmpty(auth))
            //{
            //    var cred = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(auth.Substring(6))).Split(':');
            //    var user = new { Name = cred[0], Pass = cred[1] };
            //    if (user.Name == Username && user.Pass == Password) return;
            //}
            //filterContext.HttpContext.Response.AddHeader("WWW-Authenticate", String.Format("Basic realm=\"{0}\"", BasicRealm ?? "Ryadel"));
            //filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}
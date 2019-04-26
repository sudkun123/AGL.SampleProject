using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.CustomFilters
{
    public class PresentationLogger : ActionFilterAttribute
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log.Info("Action executing");
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log.Info("Action executed");
        }
    }
}
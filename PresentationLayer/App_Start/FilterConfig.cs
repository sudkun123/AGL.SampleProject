using PresentationLayer.CustomFilters;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MyAuthentication());
            filters.Add(new PresentationLogger());
        }
    }
}

using System.Web;
using System.Web.Mvc;

namespace WindowsServiceManager.WebGui
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

using System.Web.Mvc;

namespace Gazt.AssetTracking.Portal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new ActivationCheckActionFilterAttribute());
        }
    }
}

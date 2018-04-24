using Gazt.AssetTracking.Portal;
using Gazt.AssetTracking.Portal.App_Start;
using Serilog;
using SerilogWeb.Classic.Enrichers;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Gazt.AssetTracking.Portal
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

           
         

            // Blacklist certain URLs from being 'localized'.
            i18n.UrlLocalizer.QuickUrlExclusionFilter = new Regex(@"(?:sitemap\.xml|\.css|\.less|\.jpg|\.jpeg|\.png|\.gif|\.ico|\.svg|\.woff|\.woff2|\.ttf|\.eot)$|kendo|Unregistered|signalr", RegexOptions.IgnoreCase);

            
        }

        public void Application_BeginRequest()
        {
            var tempCulture = (CultureInfo)Thread.CurrentThread.CurrentUICulture.Clone();
            tempCulture.DateTimeFormat = new DateTimeFormatInfo();
            Thread.CurrentThread.CurrentCulture =
                Thread.CurrentThread.CurrentUICulture = tempCulture;
        }
    }
}

using System.Web.Optimization;

namespace Gazt.AssetTracking.Portal
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
          
            BundleTable.EnableOptimizations = false;
        }
    }
}

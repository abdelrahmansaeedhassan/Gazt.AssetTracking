using System;
using System.Configuration;

namespace Gazt.AssetTracking.Core.Infrastructure
{
    public static class ApplicationSettings
    {
      
        public static string UserImageUrl => ConfigurationManager.AppSettings["UserImageUrl"] ?? string.Empty;
      
   




    
    }
}

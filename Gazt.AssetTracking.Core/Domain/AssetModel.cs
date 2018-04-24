
using Gazt.AssetTracking.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gazt.AssetTracking.Core.Domain
{
    public class AssetModel : AuditableEntity<int>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }

    }
}

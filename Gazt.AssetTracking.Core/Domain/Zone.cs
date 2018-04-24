
using Gazt.AssetTracking.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.Core.Domain
{
   public class Zone : AuditableEntity<int>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}

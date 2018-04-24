
using Gazt.AssetTracking.Core.Enums;
using Gazt.AssetTracking.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.Core.Domain
{
   public class AssetTrackingHistory : AuditableEntity<int>
    {

        public int AssetId { get; set; }
        public int UserId { get; set; }
        public AssetStatus AssetStatus { get; set; }
        public Asset Asset { get; set; }
        public User User { get; set; }
    }
}

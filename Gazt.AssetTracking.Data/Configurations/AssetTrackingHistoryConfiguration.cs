using Gazt.AssetTracking.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.Data.Configurations
{
  public  class AssetTrackingHistoryConfiguration : EntityTypeConfiguration<AssetTrackingHistory>
    {
        public AssetTrackingHistoryConfiguration()
        {
            Property(log => log.CreatedBy).HasMaxLength(50);
            Property(log => log.CreatedOn);
            Property(log => log.UpdatedBy).HasMaxLength(50);
        }
    }
}

using Gazt.AssetTracking.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.Data.Configurations
{
    public class AssetConfiguration : EntityTypeConfiguration<Asset>
    {
        public AssetConfiguration()
        {
            Property(asset => asset.SerialNumber).HasMaxLength(50).IsRequired();
            
            Property(asset => asset.DescriptionAr).HasMaxLength(100);
            Property(asset => asset.DescriptionEn).HasMaxLength(100);
            Property(log => log.CreatedBy).HasMaxLength(50);
            Property(log => log.UpdatedBy).HasMaxLength(50);

        }
    }
}

using Gazt.AssetTracking.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.Data.Configurations
{
  public  class AssetModelConfiguration : EntityTypeConfiguration<AssetModel>
    {
        public AssetModelConfiguration()
        {
            Property(assetModel => assetModel.NameAr).HasMaxLength(50).IsRequired(); ;
            Property(assetModel => assetModel.NameEn).HasMaxLength(50).IsRequired(); ;
            Property(log => log.CreatedBy).HasMaxLength(50);
         
            Property(log => log.UpdatedBy).HasMaxLength(50);
        }
    }
}

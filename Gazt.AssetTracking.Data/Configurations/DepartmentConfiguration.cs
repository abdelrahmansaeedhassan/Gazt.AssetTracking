using Gazt.AssetTracking.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.Data.Configurations
{
   public class DepartmentConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            Property(department => department.NameAr).HasMaxLength(50).IsRequired(); ;
            Property(department => department.NameEn).HasMaxLength(50).IsRequired(); ;
            Property(log => log.CreatedBy).HasMaxLength(50);
            Property(log => log.CreatedOn).IsRequired();
            Property(log => log.UpdatedBy).HasMaxLength(50);
        }
    }
}

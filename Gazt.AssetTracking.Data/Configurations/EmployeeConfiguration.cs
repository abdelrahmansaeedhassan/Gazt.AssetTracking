using Gazt.AssetTracking.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.Data.Configurations
{
  public  class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            Property(employee => employee.NameAr).HasMaxLength(50).IsRequired(); ;
            Property(employee => employee.NameEn).HasMaxLength(50).IsRequired(); ;
            Property(employee => employee.JobNameAr).HasMaxLength(50).IsRequired(); ;
            Property(employee => employee.JobNameEn).HasMaxLength(50).IsRequired(); ;
            Property(employee => employee.MobileNumber).HasMaxLength(50).IsRequired(); ;
            Property(employee => employee.NationalityId).IsRequired(); ;
            Property(employee => employee.AddressAr).HasMaxLength(50);
            Property(employee => employee.AddressEn).HasMaxLength(50);
            Property(log => log.CreatedBy).HasMaxLength(50);
            Property(log => log.CreatedOn).IsRequired();
            Property(log => log.UpdatedBy).HasMaxLength(50);
        }
    }
}

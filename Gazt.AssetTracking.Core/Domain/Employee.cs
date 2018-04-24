
using Gazt.AssetTracking.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.Core.Domain
{
   public class Employee : AuditableEntity<int>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
     
        public string JobNameAr { get; set; }
        public string JobNameEn { get; set; }
        public string AddressEn { get; set; }
        public string AddressAr { get; set; }
        public string MobileNumber { get; set; }

        public int NationalityId { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime? RetirementDate { get; set; }
        public Department Department { get; set; }

        public Nationality Nationality { get; set; }
        public User User { get; set; }

    }
}

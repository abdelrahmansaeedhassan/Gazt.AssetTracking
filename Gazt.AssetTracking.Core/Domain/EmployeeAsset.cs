using Gazt.AssetTracking.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.Core.Domain
{
   public class EmployeeAsset : AuditableEntity<int>
    {
        public EmployeeAsset()
        {
            IsConfirmed = false;
        }
        public int EmployeeId { get; set; }
        public int AssetId { get; set; }
     
        public bool IsConfirmed { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public Employee Employee { get; set; }
        public Asset Asset { get; set; }

    }
}

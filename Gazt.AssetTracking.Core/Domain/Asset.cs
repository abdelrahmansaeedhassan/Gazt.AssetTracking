
using Gazt.AssetTracking.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gazt.AssetTracking.Core.Extensions;

using System.ComponentModel;
using Gazt.AssetTracking.Core.Infrastructure;

namespace Gazt.AssetTracking.Core.Domain
{
    public class Asset: AuditableEntity<int>
    {
        public Asset()
        {
            IsAssigned = false;
            IsPrinted = false;
        }
        [Required]
        public string SerialNumber { get; set; }

        [ForeignKey("AssetModel")]
        [Required]
        public int ModelId { get; set; }
        public AssetStatus AssetStatus { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int ZoneId { get; set; }
        public string Epc { get; set; }
        public DateTime? PrintedDate { get; set; }
    
        public bool IsPrinted { get; set; }
    
        public bool IsAssigned { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? LastAssignDate { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public AssetModel AssetModel { get; set; }
        public Employee Employee { get; set; }
        public Zone Zone { get; set; }
     
      
    }
}

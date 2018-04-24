using Gazt.AssetTracking.Core.Domain;
using Gazt.AssetTracking.Core.Enums;

using Gazt.AssetTracking.ViewModels.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.ViewModels
{
   public class AssetViewModel : ViewModelBase
    {
        public string SerialNumber { get; set; }
        public int ModelId { get; set; }
        public AssetStatus AssetStatus { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int ZoneId { get; set; }
        public string Epc { get; set; }
        public DateTime? PrintedDate { get; set; }
        public bool? IsPrinted { get; set; }
        public bool IsAssigned { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? LastAssignDate { get; set; }
        public string ZoneName { get; set; }
        public string ModelName { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public int LocationId { get; set; }
        public ZoneViewModel Zone { get; set; }
      
    }
}

using Gazt.AssetTracking.ViewModels.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.ViewModels
{
   public class ZoneViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}

using System;

namespace Gazt.AssetTracking.Core.Infrastructure
{
    public interface IAuditableEntity 
    {
        DateTime CreatedOn { get; set; }   
        string CreatedBy { get; set; }

        DateTime? UpdatedOn { get; set; }           
        string UpdatedBy { get; set; }
    }
}

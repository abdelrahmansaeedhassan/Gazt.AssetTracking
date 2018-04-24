﻿using System;

namespace Gazt.AssetTracking.Core.Infrastructure
{
    public abstract class AuditableEntity<T> : Entity<T>, IAuditableEntity    
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}

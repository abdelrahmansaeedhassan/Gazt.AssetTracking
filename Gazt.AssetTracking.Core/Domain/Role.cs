﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace Gazt.AssetTracking.Core.Domain
{
    public class Role : IdentityRole<int, UserRole>
    {
        public Role() { }
        public Role(string name) { Name = name; }
    }
}

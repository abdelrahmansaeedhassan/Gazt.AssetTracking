using Microsoft.AspNet.Identity.EntityFramework;

namespace Gazt.AssetTracking.Core.Domain
{
    public class UserRole : IdentityUserRole<int>
    {
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}

using Gazt.AssetTracking.Core.Domain;
using Gazt.AssetTracking.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazt.AssetTracking.Services.Users
{
    public class ApplicationUserStore : UserStore<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        public ApplicationUserStore(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}

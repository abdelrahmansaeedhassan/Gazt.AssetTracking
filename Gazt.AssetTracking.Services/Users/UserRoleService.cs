using System;
using System.Linq;

using Gazt.AssetTracking.Core.Domain;
using Gazt.AssetTracking.Data.Infrastructure;

namespace Gazt.AssetTracking.Services.Users
{
    public interface IUserRoleService
    {
        
    }

    public class UserRoleService : IUserRoleService
    {
        private readonly IRepository<UserRole> _userRoleRepository;

        public UserRoleService(IRepository<UserRole> userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

     

       
    }
}

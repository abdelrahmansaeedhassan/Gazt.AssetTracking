
using Gazt.AssetTracking.Core.Domain;
using Gazt.AssetTracking.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Gazt.AssetTracking.Services.Users
{
    public interface IRoleService
    {
     
    }

    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;

        public RoleService(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }


        public Role GetRoleById(int id)
        {
            return _roleRepository.GetById(id);
        }
    }
}

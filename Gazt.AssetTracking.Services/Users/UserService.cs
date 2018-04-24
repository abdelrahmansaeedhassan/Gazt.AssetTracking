using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using Gazt.AssetTracking.Core.Domain;
using Gazt.AssetTracking.Data.Infrastructure;

namespace Gazt.AssetTracking.Services.Users
{
    public interface IUserService
    {
       
    }

    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

      
    

    


       
    }
}

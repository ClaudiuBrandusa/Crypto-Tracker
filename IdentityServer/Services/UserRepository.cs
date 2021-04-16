using Library.IdentityServer.Data;
using Library.IdentityServer.Entities;
using Library.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthenticationContext _authenticationContext;

        public UserRepository(AuthenticationContext authenticationContext)
        {
            _authenticationContext = authenticationContext;
        }

        public ICollection<ApplicationUser> GetUsers()
        {
            return _authenticationContext.ApplicationUsers.ToList();
        }
    }
}
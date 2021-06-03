using Library.IdentityServer.Data;
using Library.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class ServerRepository : IServerRepository
    {
        private readonly ServerContext _serverContext;
        private readonly AuthenticationContext _userContext;

        public ServerRepository(ServerContext serverContext, AuthenticationContext userContext)
        {
            _serverContext = serverContext;
            _userContext = userContext;
        }

        public string GeCoinIdByName(string coinName)
        {
            if (coinName == null)
            {
                return "";
            }

            var coin = _serverContext.Coins.FirstOrDefault(r => r.Name.Equals(coinName));

            return coin.Id;
        }

        public string GetUserIdByName(string UserName)
        {
            if (UserName == null)
            {
                return "";
            }

            var user = _userContext.Users.FirstOrDefault(r => r.UserName.Equals(UserName));

            return user.Id;
        }
    }
}

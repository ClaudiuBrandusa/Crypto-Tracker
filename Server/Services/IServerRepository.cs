using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface IServerRepository
    {
        string GetUserIdByName(string userName);
        string GeCoinIdByName(string coinName);
    }
}

using Library.Server.Data;
using Library.Server.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly ServerContext _serverContext;
        private readonly IServerRepository _serverRepository;

        public WalletController(ServerContext serverContext, IServerRepository serverRepository)
        {
            _serverContext = serverContext;
            _serverRepository = serverRepository;
        }


        [HttpPost]
        [Route("GenerateWallet")]
        public async Task<IActionResult> GenerateWallet(Wallet model, string userName, string coinName)
        {
            Wallet wallet = new Wallet
            {
                Quantity = model.Quantity
            };

            wallet.UserId = _serverRepository.GetUserIdByName(userName);
            wallet.CoinId = _serverRepository.GeCoinIdByName(coinName);

            await _serverContext.Wallets.AddAsync(wallet);
            await _serverContext.SaveChangesAsync();

            return Ok(wallet);
        }

        [HttpGet]
        [Route("GetWallet")]
        public IActionResult GetWallet(string userName, string coinName)
        {
            var userId = _serverRepository.GetUserIdByName(userName);
            var coinId = _serverRepository.GeCoinIdByName(coinName);

            var wallet = _serverContext.Wallets.Where(x => x.UserId.Equals(userId)).Where(x => x.CoinId.Equals(coinId));

            return Ok(wallet);
        }
    }
}

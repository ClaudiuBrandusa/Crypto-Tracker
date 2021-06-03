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
    public class CoinController : ControllerBase
    {
        private readonly ServerContext _serverContext;
        private readonly IServerRepository _serverRepository;

        public CoinController(ServerContext serverContext, IServerRepository serverRepository)
        {
            _serverContext = serverContext;
            _serverRepository = serverRepository;
        }


        [HttpPost]
        [Route("AddNewCoin")]
        public async Task<IActionResult> AddNewCoin(Coin model)
        {
            Coin coin = new Coin
            {
                Name = model.Name,
                Value = model.Value
            };

            coin.Id = Guid.NewGuid().ToString();

            await _serverContext.Coins.AddAsync(coin);
            await _serverContext.SaveChangesAsync();

            return Ok(coin);
        }

        [HttpGet]
        [Route("GetCoin")]
        public IActionResult GetCoin(string coinName)
        {
            Coin coin = new Coin();
            coin = _serverContext.Coins.FirstOrDefault(x => x.Name.Equals(coinName));

            return Ok(coin);
        }
    }
}

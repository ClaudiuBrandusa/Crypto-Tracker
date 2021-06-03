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
    public class CreditController : ControllerBase
    {
        private readonly ServerContext _serverContext;
        private readonly IServerRepository _serverRepository;

        public CreditController(ServerContext serverContext, IServerRepository serverRepository)
        {
            _serverContext = serverContext;
            _serverRepository = serverRepository;
        }


        [HttpPost]
        [Route("AddCredit")]
        public async Task<IActionResult> AddCredit(Credit model, string userName)
        {
            Credit credit = new Credit
            {
                UserCredit = model.UserCredit
            };

            credit.UserId = _serverRepository.GetUserIdByName(userName);

            await _serverContext.Credits.AddAsync(credit);
            await _serverContext.SaveChangesAsync();

            return Ok(credit);
        }

        [HttpGet]
        [Route("GetCredit")]
        public IActionResult GetCredit(string userName)
        {
            Credit credit = new Credit();

            var userId = _serverRepository.GetUserIdByName(userName);
            credit = _serverContext.Credits.FirstOrDefault(x => x.UserId.Equals(userId));

            return Ok(credit);
        }

        [HttpPost]
        [Route("AddCreditHistory")]
        public async Task<IActionResult> AddCreditHistory(CreditHistory model, string userName)
        {
            Credit credit = new Credit();

            var userId = _serverRepository.GetUserIdByName(userName);
            credit = _serverContext.Credits.FirstOrDefault(x => x.UserId.Equals(userId));

            CreditHistory creditHistory = new CreditHistory
            {
                Date = model.Date,
                Type = model.Type
            };

            creditHistory.UserId = userId;
            creditHistory.Amount = credit.UserCredit;
            
            await _serverContext.CreditHistories.AddAsync(creditHistory);
            await _serverContext.SaveChangesAsync();

            return Ok(creditHistory);
        }

        [HttpGet]
        [Route("GetCreditHistory")]
        public IActionResult GetCreditHistory(string userName)
        {
            CreditHistory creditHistory = new CreditHistory();

            var userId = _serverRepository.GetUserIdByName(userName);
            creditHistory = _serverContext.CreditHistories.FirstOrDefault(x => x.UserId.Equals(userId));

            return Ok(creditHistory);
        }
    }
}

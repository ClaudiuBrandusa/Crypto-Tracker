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
    public class TransactionController : ControllerBase
    {
        private readonly ServerContext _serverContext;
        private readonly IServerRepository _serverRepository;

        public TransactionController(ServerContext serverContext, IServerRepository serverRepository)
        {
            _serverContext = serverContext;
            _serverRepository = serverRepository;
        }


        [HttpPost]
        [Route("AddTransaction")]
        public async Task<IActionResult> AddTransaction(Transaction model, string userName)
        {
            Transaction transaction = new Transaction
            {
                Quantity = model.Quantity,
                Date = model.Date
            };

            transaction.Id = Guid.NewGuid().ToString();
            transaction.UserId = _serverRepository.GetUserIdByName(userName);

            await _serverContext.Transactions.AddAsync(transaction);
            await _serverContext.SaveChangesAsync();

            return Ok(transaction);
        }

        [HttpGet]
        [Route("GetAllTransactions")]
        public IActionResult GetAllTransactions(string userName)
        {
            ICollection<Transaction> transactions = new List<Transaction>();
            var userId = _serverRepository.GetUserIdByName(userName);
            transactions = _serverContext.Transactions.Where(x => x.UserId.Equals(userId)).ToList();

            return Ok(transactions);
        }
    }
}

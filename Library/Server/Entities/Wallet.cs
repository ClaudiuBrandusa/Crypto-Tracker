using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Server.Entities
{
    public class Wallet
    {
        public string UserId { get; set; }
        public string CoinId { get; set; }
        public float Quantity { get; set; }

        public User User { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public Coin Coin { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Server.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<Wallet> Wallets { get; set; }
        public Credit Credit { get; set; }
        public CreditHistory CreditHistory { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Server.Entities
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<Wallet> Wallets { get; set; }
        public Credit Credit { get; set; }
        public CreditHistory CreditHistory { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
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

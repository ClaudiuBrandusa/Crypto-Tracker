using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        public float Quantity { get; set; }
        public DateTime Date { get; set; }

        public User User { get; set; }
        public Wallet Wallet { get; set; }
    }
}

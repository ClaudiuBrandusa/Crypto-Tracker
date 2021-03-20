using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Coin
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }

        public ICollection<Wallet> Wallets { get; set; }
    }
}

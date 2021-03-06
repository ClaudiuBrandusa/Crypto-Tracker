﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Server.Entities
{
    public class Coin
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public float Value { get; set; }

        public ICollection<Wallet> Wallets { get; set; }
    }
}

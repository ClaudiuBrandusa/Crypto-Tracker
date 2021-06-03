using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Server.Entities
{
    public class Transaction
    {
        [Key]
        public string Id { get; set; }
        public float Quantity { get; set; }
        public DateTime Date { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public Wallet Wallet { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Server.Entities
{
    public class CreditHistory
    {
        public string UserId { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public bool Type { get; set; }

        public User User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Server.Entities
{
    public class Credit
    {
        public string UserId { get; set; }
        public float UserCredit { get; set; }

        public User User { get; set; }
    }

}

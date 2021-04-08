using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Entities
{
    public class Credit
    {
        public string UserId { get; set; }
        public float UserCredit { get; set; }

        public User User { get; set; }
    }
}

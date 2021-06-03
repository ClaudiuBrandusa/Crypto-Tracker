using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library.Server.Entities
{
    public class Credit
    {
        [Key]
        public string UserId { get; set; }
        public float UserCredit { get; set; }

        public User User { get; set; }
    }

}

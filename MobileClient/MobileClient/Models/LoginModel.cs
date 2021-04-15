using MobileClient.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileClient.Models
{
    public class LoginModel
    {
        [LengthConstraint(4, 24)]
        [Required]
        public string Username { get; set; }

        [LengthConstraint(6, 24)]
        [Required]
        public string Password { get; set; }
    }
}

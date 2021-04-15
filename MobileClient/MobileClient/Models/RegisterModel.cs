using MobileClient.Attributes;

namespace MobileClient.Models
{
    public class RegisterModel
    {
        [LengthConstraint(4, 24)]
        [Required]
        public string Username { get; set; }

        [Email]
        [Required]
        public string Email { get; set; }

        [LengthConstraint(6, 24)]
        [Required]
        public string Password { get; set; }

        [CompareString(nameof(Password))]
        [Required]
        public string ConfirmPassword { get; set; }
    }
}

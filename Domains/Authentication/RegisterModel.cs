namespace Domains.Authentication
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]

        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^\+20\d{10}$", ErrorMessage = "Invalid mobile number format")]
        public string PhoneNumber { get; set; }
    }
}

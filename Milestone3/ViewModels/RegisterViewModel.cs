using System.ComponentModel.DataAnnotations;

namespace RoleBasedProductMgmt.ViewModels
{
    public class RegisterViewModel
    {
        [Required, Display(Name = "Username")]
        public string Username { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Role (Admin or Manager)")]
        public string? Role { get; set; }
    }
}

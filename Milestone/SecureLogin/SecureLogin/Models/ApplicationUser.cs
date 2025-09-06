using Microsoft.AspNetCore.Identity;


namespace SecureLoginRoleBasedMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? DisplayName { get; set; }
    }
}
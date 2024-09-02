using Microsoft.AspNetCore.Identity;

namespace Rabbit_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace AeroCore.Infrastructure.Identity
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}

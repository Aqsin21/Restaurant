using Microsoft.AspNetCore.Identity;

namespace Restaurant.DataContext.Entities
{
    public class AppUser :IdentityUser
    {
        public required string FullName { get; set; }
    }
}

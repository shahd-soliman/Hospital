using Microsoft.AspNetCore.Identity;

namespace P.Models
{
    public class ApplicationUser:IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Concrete
{
    public class AppUser : IdentityUser <int>
    {
        public string FirstName { get; set; }
        public string  LastName { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace hospitalManagement.Domain.Models.Users
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

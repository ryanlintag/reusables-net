using System.Security.Principal;

namespace IdentityServer.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Branch { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
    }
}

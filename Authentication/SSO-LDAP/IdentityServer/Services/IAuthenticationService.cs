using IdentityServer.Models;

namespace IdentityServer.Services
{
    public interface IAuthenticationService
    {
        Task<User> Login(string userName, string password);
    }
}

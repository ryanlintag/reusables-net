using IdentityServer.Models;

namespace IdentityServer.Repositories
{
    public interface IRepository
    {
        Task<User> GetUser(string email);
    }
}

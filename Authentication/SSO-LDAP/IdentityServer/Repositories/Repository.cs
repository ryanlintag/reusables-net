using IdentityServer.Helpers;
using IdentityServer.Models;

namespace IdentityServer.Repositories
{
    public class Repository : IRepository
    {
        private readonly List<User> _users = new() {
            new User()
            {
                Id = Guid.Parse("19A4D88A-B0E6-4024-B224-06A68F9CB065"),
                Email = "admin@email.com",
                Branch = "IT",
                Name = "IT User",
                Role = RoleConstants.AdminUser,
                IsActive = true,
            },
            new User()
            {
                Id = Guid.Parse("19A4D88A-B0E6-4024-B224-06A68F9CB065"),
                Email = "inactive.admin@email.com",
                Branch = "IT",
                Name = "Inactive IT User",
                Role = RoleConstants.AdminUser,
                IsActive = false,
            },
            new User()
            {
                Id = Guid.Parse("19A4D88A-B0E6-4024-B224-06A68F9CB065"),
                Email = "compliance@email.com",
                Branch = "Compliance",
                Name = "Compliance User",
                Role = RoleConstants.ComplianceUser,
                IsActive = true,
            },
            new User()
            {
                Id = Guid.Parse("19A4D88A-B0E6-4024-B224-06A68F9CB065"),
                Email = "inactive.compliance@email.com",
                Branch = "Compliance",
                Name = "Inactive Compliance User",
                Role = RoleConstants.ComplianceUser,
                IsActive = false,
            },
            new User()
            {
                Id = Guid.Parse("19A4D88A-B0E6-4024-B224-06A68F9CB065"),
                Email = "branch1@email.com",
                Branch = "Branch 1",
                Name = "Branch 1 User",
                Role = RoleConstants.BranchUser,
                IsActive = true,
            },
            new User()
            {
                Id = Guid.Parse("19A4D88A-B0E6-4024-B224-06A68F9CB065"),
                Email = "inactive.branch1@email.com",
                Branch = "Branch 1",
                Name = "Inactive Branch 1 User",
                Role = RoleConstants.BranchUser,
                IsActive = false,
            },
            new User()
            {
                Id = Guid.Parse("19A4D88A-B0E6-4024-B224-06A68F9CB065"),
                Email = "branch2@email.com",
                Branch = "Branch 2",
                Name = "Branch 2 User",
                Role = RoleConstants.BranchUser,
                IsActive = true,
            },
            new User()
            {
                Id = Guid.Parse("19A4D88A-B0E6-4024-B224-06A68F9CB065"),
                Email = "inactive.branch2@email.com",
                Branch = "Branch 2",
                Name = "Inactive Branch 2 User",
                Role = RoleConstants.BranchUser,
                IsActive = false,
            }
        };
        public Task<User> GetUser(string email)
        {
            return Task.FromResult(_users.FirstOrDefault(p => p.Email == email));
        }
    }
}

using IdentityServer.Models;
using IdentityServer.Repositories;
using Microsoft.Extensions.Options;
using System.DirectoryServices;

namespace IdentityServer.Services
{
    public class LdapAuthenticationService : IAuthenticationService
    {
        private const string DisplayNameAttribute = "DisplayName";
        private const string SAMAccountNameAttribute = "SAMAccountName";

        private readonly LdapConfig _config;
        private readonly IRepository _repository;
        private readonly ILogger<LdapAuthenticationService> _logger;

        public LdapAuthenticationService(IConfiguration configuration, ILogger<LdapAuthenticationService> logger, IRepository repository)
        {
            this._repository = repository;
            this._logger = logger;
            this._config = configuration.GetSection(LdapConfig.LDAP_Config).Get<LdapConfig>();
        }
        public async Task<User> Login(string userName, string password)
        {
            try
            {
                using (DirectoryEntry entry = new DirectoryEntry(_config.Path, _config.UserDomainName + "\\" + userName, password))
                {
                    using (DirectorySearcher searcher = new DirectorySearcher(entry))
                    {
                        searcher.Filter = String.Format("({0}={1})", SAMAccountNameAttribute, userName);
                        searcher.PropertiesToLoad.Add(DisplayNameAttribute);
                        searcher.PropertiesToLoad.Add(SAMAccountNameAttribute);
                        var result = searcher.FindOne();
                        if (result != null)
                        {
                            var displayName = result.Properties[DisplayNameAttribute];
                            var samAccountName = result.Properties[SAMAccountNameAttribute];

                            return await _repository.GetUser(samAccountName == null || samAccountName.Count <= 0 ? string.Empty : samAccountName[0].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User {UserName} encountered an exception while logging in.", userName);
            }
            return null;
        }
    }
}

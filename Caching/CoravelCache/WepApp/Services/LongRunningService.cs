using Coravel.Cache.Interfaces;
using WepApp.Helpers;
using WepApp.Models;
using WepApp.Repository;

namespace WepApp.Services
{
    public class LongRunningService : ILongRunningService
    {
        private IRepository _repository { get; set; }
        private ICache _cache { get; set; }

        public LongRunningService(IRepository repository, ICache cache)
        {
            _repository = repository;
            _cache = cache;
        }
        public async Task<ContainerViewModel> GetItems()
        {
            if(!(await _cache.HasAsync(CacheConstants.LongRunningServiceCache)))
            {
                return await this._cache.RememberAsync<ContainerViewModel>(CacheConstants.LongRunningServiceCache, this._getItems, TimeSpan.FromMinutes(30));
            }
            return await this._cache.GetAsync<ContainerViewModel>(CacheConstants.LongRunningServiceCache); ;
        }

         private async Task<ContainerViewModel> _getItems()
        {
            var branches = new ContainerViewModel { Branches = await _repository.GetList() };
            return branches;

        }
    }
}

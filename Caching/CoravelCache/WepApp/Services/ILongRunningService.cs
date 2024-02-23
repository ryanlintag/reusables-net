using WepApp.Models;

namespace WepApp.Services
{
    public interface ILongRunningService
    {
        Task<ContainerViewModel> GetItems();
    }
}

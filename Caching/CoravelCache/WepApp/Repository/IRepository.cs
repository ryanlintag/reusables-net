using WepApp.Models;

namespace WepApp.Repository
{
    public interface IRepository
    {
        Task<List<BankBranchViewModel>> GetList();
    }
}

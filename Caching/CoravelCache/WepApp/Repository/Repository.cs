using WepApp.Models;

namespace WepApp.Repository
{
    public class Repository : IRepository
    {
        public async Task<List<BankBranchViewModel>> GetList()
        {
            await Task.Delay(10000);

            return await Task.Run(() => new List<BankBranchViewModel>()
            {
                new BankBranchViewModel
                {
                   Id = Guid.NewGuid(),
                   BranchName = "Branch 1"
                },
                new BankBranchViewModel
                {
                   Id = Guid.NewGuid(),
                   BranchName = "Branch 2"
                },
                new BankBranchViewModel
                {
                   Id = Guid.NewGuid(),
                   BranchName = "Branch 3"
                },
                new BankBranchViewModel
                {
                   Id = Guid.NewGuid(),
                   BranchName = "Branch 4"
                },
                new BankBranchViewModel
                {
                   Id = Guid.NewGuid(),
                   BranchName = "Branch 5"
                },
                new BankBranchViewModel
                {
                   Id = Guid.NewGuid(),
                   BranchName = "Branch 6"
                }
            });
        }
    }
}

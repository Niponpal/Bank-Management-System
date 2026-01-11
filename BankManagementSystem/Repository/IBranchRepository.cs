using BankManagementSystem.Models;

namespace BankManagementSystem.Repository;

public interface IBranchRepository
{
    Task<IEnumerable<Branch>> GetAllBranchAsync(CancellationToken cancellationToken);
    Task<Branch?> GetBranchByIdAsync(long id, CancellationToken cancellationToken);
    Task<Branch> AddBranchAsync(Branch  branch, CancellationToken cancellationToken);
    Task<Branch?> UpdateBranchAsync(Branch  branch, CancellationToken cancellationToken);
    Task<Branch> DeleteBranchAsync(long id, CancellationToken cancellationToken);
}

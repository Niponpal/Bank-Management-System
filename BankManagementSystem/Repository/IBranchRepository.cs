using BankManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankManagementSystem.Repository;

public interface IBranchRepository
{
    Task<IEnumerable<Branch>> GetAllBranchAsync(CancellationToken cancellationToken);
    Task<Branch?> GetBranchByIdAsync(long id, CancellationToken cancellationToken);
    Task<Branch> AddBranchAsync(Branch  branch, CancellationToken cancellationToken);
    Task<Branch?> UpdateBranchAsync(Branch  branch, CancellationToken cancellationToken);
    Task<Branch> DeleteBranchAsync(long id, CancellationToken cancellationToken);
    Task<IEnumerable<SelectListItem>> DropdownAsync(CancellationToken cancellationToken);
}


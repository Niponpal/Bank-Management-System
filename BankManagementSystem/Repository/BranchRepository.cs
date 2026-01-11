using BankManagementSystem.Data;
using BankManagementSystem.Models;

namespace BankManagementSystem.Repository;

public class BranchRepository : IBranchRepository
{
    private readonly ApplicationDbContext _context;
    public BranchRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public Task<Branch> AddBranchAsync(Branch branch, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Branch> DeleteBranchAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Branch>> GetAllBranchAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Branch?> GetBranchByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Branch?> UpdateBranchAsync(Branch branch, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

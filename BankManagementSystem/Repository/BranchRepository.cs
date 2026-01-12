using BankManagementSystem.Data;
using BankManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Repository;

public class BranchRepository : IBranchRepository
{
    private readonly ApplicationDbContext _context;
    public BranchRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Branch> AddBranchAsync(Branch branch, CancellationToken cancellationToken)
    {
        await _context.Branches.AddAsync(branch, cancellationToken);
        await _context.SaveChangesAsync();
        return branch;

    }

    public async Task<IEnumerable<SelectListItem>> DropdownAsync(CancellationToken cancellationToken)
    {
        return await _context.AccountCustomers
            .Where(x => x.IsActive)
            .Select(x => new SelectListItem
            {
                Text = x.FullName,
                Value = x.Id.ToString()
            })
            .ToListAsync(cancellationToken);
    }
    public async Task<Branch> DeleteBranchAsync(long id, CancellationToken cancellationToken)
    {
         var data = await _context.Branches.FindAsync(id, cancellationToken);
        if (data != null)
        {
            _context.Branches.Remove(data);
            await _context.SaveChangesAsync(cancellationToken);
        }
        return null!;
    }

    public async Task<IEnumerable<Branch>> GetAllBranchAsync(CancellationToken cancellationToken)
    {
        var data = await _context.Branches.ToListAsync(cancellationToken);
        if (data != null)
        {
            return data;
        }
        return null;
    }

    public async Task<Branch?> GetBranchByIdAsync(long id, CancellationToken cancellationToken)
    {
      var data = await _context.Branches.FindAsync(id,cancellationToken);
        if (data != null)
        {
           return data;
        }
        return null;
    }

    public async Task<Branch?> UpdateBranchAsync(Branch branch, CancellationToken cancellationToken)
    {
       var data = await _context.Branches.FindAsync(branch.Id,cancellationToken);
        if (data != null)
        {
            data.BranchCode = branch.BranchCode;
            data.BranchName = branch.BranchName;
            data.Address = branch.Address;
            data.CreatedAt = branch.CreatedAt;
            await _context.SaveChangesAsync(cancellationToken);
            return data;
        }
        return null;
    }
}

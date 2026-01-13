using BankManagementSystem.Data;
using BankManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Repository;

public class AccountCustomerRepository : IAccountCustomerRepository
{
    private readonly ApplicationDbContext _context;
    public AccountCustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<AccountCustomer> AddMAccountCustomerAsync(AccountCustomer accountCustomer, CancellationToken cancellationToken)
    {
           await _context.AccountCustomers.AddAsync(accountCustomer, cancellationToken);
           await  _context.SaveChangesAsync(cancellationToken);
           return accountCustomer;
    }

    public async Task<AccountCustomer> DeleteAccountCustomerAsync(long id, CancellationToken cancellationToken)
    {
      var data = await _context.AccountCustomers.FindAsync(id,cancellationToken);
        if (data != null)
        {
            _context.AccountCustomers.Remove(data);
            await _context.SaveChangesAsync(cancellationToken);
        }
        return null!;
    }

    public async Task<IEnumerable<SelectListItem>> DropdownAsync(CancellationToken cancellationToken)
    {
        return await _context.AccountCustomers
            .Select(x => new SelectListItem
            {
                Text = x.FullName,
                Value = x.Id.ToString()
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<AccountCustomer?> GetAccountCustomerByIdAsync(long id, CancellationToken cancellationToken)
    {
        var data = await _context.AccountCustomers.FindAsync(id,cancellationToken);
        if (data != null)
        {
           return data;
        }
        return null;
    }

    public async Task<IEnumerable<AccountCustomer>> GetAllAccountCustomerAsync(CancellationToken cancellationToken)
    {
        var data = await _context.AccountCustomers.ToListAsync(cancellationToken);
        if (data != null)
        {
           return data;
        }
      return Enumerable.Empty<AccountCustomer>();
    }

    public async Task<AccountCustomer?> UpdateAccountCustomerAsync(AccountCustomer accountCustomer, CancellationToken cancellationToken)
    {
        var data = await _context.AccountCustomers.FindAsync(accountCustomer.Id,cancellationToken);
        if (data != null)
        {
            data.AccountNumber = accountCustomer.AccountNumber;
            data.Balance = accountCustomer.Balance;
            data.IsActive = accountCustomer.IsActive;
            data.FullName = accountCustomer.FullName;
            data.Phone = accountCustomer.Phone;
            data.NID = accountCustomer.NID;
            data.BranchId = accountCustomer.BranchId;
            data.CreatedAt = accountCustomer.CreatedAt;
            _context.AccountCustomers.Update(data);
            await _context.SaveChangesAsync(cancellationToken);
            return data;
        }
        else
        {
            return null;
        }
    }
}

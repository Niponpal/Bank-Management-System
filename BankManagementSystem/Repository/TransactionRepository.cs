using BankManagementSystem.Data;
using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Repository;

public class TransactionRepository : ITransactionRepository
{
    private readonly ApplicationDbContext _context;
    public TransactionRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Transaction> AddMTransactionAsync(Transaction transaction, CancellationToken cancellationToken)
    {
         await _context.Transactions.AddAsync(transaction, cancellationToken);
         await  _context.SaveChangesAsync(cancellationToken);
         return transaction;
    }

    public async Task<Transaction> DeleteTransactionAsync(long id, CancellationToken cancellationToken)
    {
         var data = await _context.Transactions.FindAsync(id, cancellationToken);
          if (data != null)
            {
                _context.Transactions.Remove(data);
                await _context.SaveChangesAsync(cancellationToken);
                return data;
            }
            return null!;

    }

    public async Task<IEnumerable<Transaction>> GetAllTransactionAsync(CancellationToken cancellationToken)
    {
       var data = await _context.Transactions.Include(x=>x.AccountCustomer).ToListAsync(cancellationToken);
        if (data != null && data.Count > 0)
        {
            return data;
        }
        return null!;
    }

    public async Task<Transaction?> GetTransactionByIdAsync(long id, CancellationToken cancellationToken)
    {
        var data = await _context.Transactions.FindAsync(id, cancellationToken);
        if (data != null)
        {
            return data;
        }
        return null;
    }

    public async Task<Transaction?> UpdateTransactionAsync(Transaction transaction, CancellationToken cancellationToken)
    {
      var data = await _context.Transactions.FindAsync(transaction.Id, cancellationToken);
        if (data != null)
        {
         
            data.Amount = transaction.Amount;
            data.TransactionType = transaction.TransactionType;
            data.Reference = transaction.Reference;
            data.CreatedAt = transaction.CreatedAt;
            await _context.SaveChangesAsync(cancellationToken);
            return data;
        }
        return null;
    }
}

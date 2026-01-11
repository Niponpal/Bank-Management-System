using BankManagementSystem.Models;

namespace BankManagementSystem.Repository;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetAllTransactionAsync(CancellationToken cancellationToken);
    Task<Transaction?> GetTransactionByIdAsync(long id, CancellationToken cancellationToken);
    Task<Transaction> AddMTransactionAsync(Transaction  transaction, CancellationToken cancellationToken);
    Task<Transaction?> UpdateTransactionAsync(Transaction  transaction, CancellationToken cancellationToken);
    Task<Transaction> DeleteTransactionAsync(long id, CancellationToken cancellationToken);
}

using BankManagementSystem.Models;

namespace BankManagementSystem.Repository;

public interface IAccountCustomerRepository
{
    Task<IEnumerable<AccountCustomer>> GetAllAccountCustomerAsync(CancellationToken cancellationToken);
    Task<AccountCustomer?> GetAccountCustomerByIdAsync(long id, CancellationToken cancellationToken);
    Task<AccountCustomer> AddMAccountCustomerAsync(AccountCustomer  accountCustomer, CancellationToken cancellationToken);
    Task<AccountCustomer?> UpdateAccountCustomerAsync(AccountCustomer  accountCustomer, CancellationToken cancellationToken);
    Task<AccountCustomer> DeleteAccountCustomerAsync(long id, CancellationToken cancellationToken);
}

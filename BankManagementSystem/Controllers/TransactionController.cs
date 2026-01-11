using BankManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankManagementSystem.Controllers;

public class TransactionController : Controller
{
    private readonly ITransactionRepository _transactionRepository;
    public TransactionController(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var data =await _transactionRepository.GetAllTransactionAsync(cancellationToken);
        return View(data);
    }
}

using BankManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankManagementSystem.Controllers;

public class TransactionController : Controller
{
    private readonly ITransactionRepository _transactionRepository;

    private readonly IAccountCustomerRepository _accountCustomerRepository;

    public TransactionController(ITransactionRepository transactionRepository, IAccountCustomerRepository accountCustomerRepository)
    {
        _transactionRepository = transactionRepository;
        _accountCustomerRepository = accountCustomerRepository;
    }
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var data =await _transactionRepository.GetAllTransactionAsync(cancellationToken);
        return View(data);
    }
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(long id,CancellationToken cancellationToken)
    {
        ViewData["AccountCustomerId"] = await _accountCustomerRepository.DropdownAsync(cancellationToken);
        if (id== 0)
        {
            return View(new Models.Transaction());
        }
        else
        {
            var data = await _transactionRepository.GetTransactionByIdAsync(id,cancellationToken);
            if(data != null)
            {
                return View(data);
               
            }
            return NotFound();
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(Models.Transaction transaction,CancellationToken cancellationToken)
    {
        ViewData["AccountCustomerId"] = await _accountCustomerRepository.DropdownAsync(cancellationToken);
        if (transaction.Id == 0)
            {
                await _transactionRepository.AddMTransactionAsync(transaction,cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                await _transactionRepository.UpdateTransactionAsync(transaction,cancellationToken);
                return RedirectToAction(nameof(Index));
            }
    }
    [HttpGet]
    public async Task<IActionResult> Details(long id,CancellationToken cancellationToken)
    {
        var data = await _transactionRepository.GetTransactionByIdAsync(id,cancellationToken);
        if(data != null)
        {
            return View(data);
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> Delete(long id,CancellationToken cancellationToken)
    {
        var data = await _transactionRepository.DeleteTransactionAsync(id,cancellationToken);
        if(data != null)
        {
            return RedirectToAction(nameof(Index));
        }
        return NotFound();
    }
}

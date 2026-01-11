using BankManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankManagementSystem.Controllers;

public class AccountCustomerController : Controller
{
    private readonly IAccountCustomerRepository _accountCustomerRepository;
    public AccountCustomerController(IAccountCustomerRepository accountCustomerRepository)
    {
        _accountCustomerRepository = accountCustomerRepository;
    }
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var data = await _accountCustomerRepository.GetAllAccountCustomerAsync(cancellationToken);
        return View(data);
    }
}

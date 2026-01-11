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
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(long id,CancellationToken cancellationToken) 
    {
        if(id== 0)
        {
            return View(new Models.AccountCustomer());
        }
        else
        {
            var data = await _accountCustomerRepository.GetAccountCustomerByIdAsync(id,cancellationToken);
            if(data != null)
            {
                return View(data);
               
            }
            return NotFound();
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(Models.AccountCustomer accountCustomer,CancellationToken cancellationToken)
    {
      
            if(accountCustomer.Id == 0)
            {
                await _accountCustomerRepository.AddMAccountCustomerAsync(accountCustomer,cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                await _accountCustomerRepository.UpdateAccountCustomerAsync(accountCustomer,cancellationToken);
                return RedirectToAction(nameof(Index));
            }  
    }

    [HttpGet]
    public async Task<IActionResult> Details(long id,CancellationToken cancellationToken)
    {
        var data = await _accountCustomerRepository.GetAccountCustomerByIdAsync(id,cancellationToken);
        if(data != null)
        {
            return View(data);
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> Delete(long id,CancellationToken cancellationToken)
    {
        await _accountCustomerRepository.DeleteAccountCustomerAsync(id,cancellationToken);
        return RedirectToAction(nameof(Index));
    }

}

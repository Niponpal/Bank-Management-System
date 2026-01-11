using BankManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankManagementSystem.Controllers;

public class BranchController : Controller
{
    private readonly IBranchRepository _branchRepository;
    public BranchController(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var data = await _branchRepository.GetAllBranchAsync(cancellationToken);
        return View(data);
    }
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(int id,CancellationToken cancellationToken) 
    {
        if(id== 0)
        {
            return View(new Models.Branch());
        }
        else
        {
            var data = await _branchRepository.GetBranchByIdAsync(id,cancellationToken);
            if(data != null)
            {
                return View(data);
               
            }
            return NotFound();
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(Models.Branch branch,CancellationToken cancellationToken)
    {
      
            if(branch.Id == 0)
            {
                await _branchRepository.AddBranchAsync(branch,cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                await _branchRepository.UpdateBranchAsync(branch,cancellationToken);
                return RedirectToAction(nameof(Index));
            }
    }
    [HttpGet]
    public async Task<IActionResult> Details(int id,CancellationToken cancellationToken)
    {
        var data = await _branchRepository.GetBranchByIdAsync(id,cancellationToken);
        if(data != null)
        {
            return View(data);
        }
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id,CancellationToken cancellationToken)
    {
        await _branchRepository.DeleteBranchAsync(id,cancellationToken);
        return RedirectToAction(nameof(Index));
    }
}

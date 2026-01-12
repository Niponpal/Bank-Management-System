using Microsoft.AspNetCore.Mvc;

namespace BankManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

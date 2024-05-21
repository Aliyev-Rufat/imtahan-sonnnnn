using Microsoft.AspNetCore.Mvc;
using WebApplication15.DAL;

namespace WebApplication15.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}

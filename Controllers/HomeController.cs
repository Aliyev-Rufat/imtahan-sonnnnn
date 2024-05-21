using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication15.DAL;

namespace WebApplication15.Controllers
{
    public class HomeController : Controller
    {
     
        public IActionResult Index()
        {
            return View();
        }


    }
}
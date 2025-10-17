using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // TEMPORARY: Return a simple view instead of redirecting
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace BuanaBike.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

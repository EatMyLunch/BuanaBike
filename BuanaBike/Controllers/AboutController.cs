using Microsoft.AspNetCore.Mvc;

namespace BuanaBike.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

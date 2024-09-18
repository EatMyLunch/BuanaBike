using Microsoft.AspNetCore.Mvc;

namespace BuanaBike.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

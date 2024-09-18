using BuanaBike.Data;
using Microsoft.AspNetCore.Mvc;

namespace BuanaBike.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var articles = _context.Articles.OrderByDescending(a => a.PublishDate).ToList();
            return View(articles);
        }

        public IActionResult Details(int id)
        {
            var article = _context.Articles.FirstOrDefault(a => a.Id == id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }
    }
}

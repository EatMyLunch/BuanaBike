using BuanaBike.Data;
using Microsoft.AspNetCore.Mvc;

namespace BuanaBike.Controllers
{
    public class GalleryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GalleryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var galleryItems = _context.Galleries.ToList();
            return View(galleryItems);
        }
    }
}

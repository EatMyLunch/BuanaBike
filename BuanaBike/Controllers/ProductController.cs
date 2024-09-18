using BuanaBike.Data;
using BuanaBike.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuanaBike.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.OrderByDescending(p => p.DateCreated).ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult AddRecord(int productId, int quantity)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                return NotFound();
            }

            var record = new ProductRecord
            {
                ProductId = productId,
                Quantity = quantity,
                TotalPrice = product.Price * quantity
            };

            _context.ProductRecords.Add(record);
            _context.SaveChanges();

            return Json(new { success = true, message = "Record added successfully" });
        }
    }
}

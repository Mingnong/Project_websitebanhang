using Microsoft.AspNetCore.Mvc;
using Website_banhang.Models;
using Microsoft.EntityFrameworkCore;

namespace Website_banhang.Controllers
{
    public class ProductController : Controller
    {
        private readonly QlbhContext _context;
        public ProductController(QlbhContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int? ProductId)
        {   
            var item = _context.Products.FirstOrDefault(p => p.ProductId == ProductId);
            return View(item);
        }
    }
}

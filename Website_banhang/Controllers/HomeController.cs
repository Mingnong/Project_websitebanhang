using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Website_banhang.Models;

namespace Website_banhang.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QlbhContext _context;
        public HomeController(ILogger<HomeController> logger, QlbhContext context)
        {
            _logger = logger;
            _context = context; 
        }

        public IActionResult Index(int page = 1, int? CategoryId = null)
        {
            if (page == 0)
            {
                page = 1;
            }

            HomeData data = new HomeData();
            int limit = 8;
            int skip = ((page - 1) * limit);
            
            
            if(CategoryId.HasValue)
            {
                var product = _context.Products.Where(p => p.CategoryId == CategoryId).ToList();
                var category = _context.Categories.ToList();
                data.ProductList = product;
                data.CategoriesList = category;
            }
            else
            {
            var product = _context.Products.Where(p => p.IsActive == true).Skip(skip).Take(limit).ToList();

            var category = _context.Categories.ToList();
            data.ProductList = product;
            data.CategoriesList = category;
            }

            ViewBag.CurrentPage = page;
            return View(data);
        }

        public IActionResult _partialCategory()
        {
            return PartialView();
        }

        public IActionResult _partialProduct()
        {
            return PartialView();
        }


        public IActionResult Search(string searchData)
        {
            if (!String.IsNullOrEmpty(searchData))
            {
                var item = _context.Products
                    .Where(x => x.Filter.Contains(searchData) && x.IsActive == true)
                    .ToList();
                return Json(item);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
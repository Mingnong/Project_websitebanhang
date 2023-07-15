using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Website_banhang.Models;
using Website_banhang.Services;

namespace Website_banhang.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QlbhContext _context;
        private readonly IProductService _productService;
        public HomeController(ILogger<HomeController> logger, QlbhContext context, IProductService productService)
        {
            _logger = logger;
            _context = context;
            _productService = productService;
        }

        public IActionResult Index(int page = 1, int? CategoryId = null)
        {
            if (page == 0)
            {
                page = 1;
            }

            HomeData data = new HomeData();
            int take = 8;
            int skip = ((page - 1) * take);
            
            
            if(CategoryId != null)
            {
                var product = _productService.GetProductBycategory(CategoryId);
                var category = _context.Categories.ToList();
                data.ProductList = product;
                data.CategoriesList = category;
            }
            else
            {
            var product = _productService.GetAllProduct(skip, take);

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
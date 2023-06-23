using Microsoft.AspNetCore.Mvc;
using Website_banhang.Models;
using Microsoft.EntityFrameworkCore;

namespace Website_banhang.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly QlbhContext _context;
        public ProductController(QlbhContext context)
        {
            _context = context;
        }

        [Route("Admin/San-Pham")]
        public IActionResult Index()
        {
            var item = _context.Products.ToList();
            return View(item);
        }

        // Edit Product

        [Route("Admin/San-Pham/Chi-Tiet/{productid}")]
        public IActionResult Details(int? productid)
        {
            var item = _context.Products.FirstOrDefault(x => x.ProductId == productid);
            return View(item);
        }

        // Update Product


        [HttpPost]
        public IActionResult Update(int productId, Product model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var item = _context.Products.FirstOrDefault(x => x.ProductId == productId);
                    
                    if(item != null)
                    {
                        item.ProductName = model.ProductName;
                        item.ProductDescription = model.ProductDescription;
                        item.ProductPrice = model.ProductPrice;
                        
                        // save Value in DB
                        _context.SaveChanges();
                        return RedirectToAction("Index", "Product", new {area = "Admin"});
                    }
                    else
                    {
                        return NotFound();
                    }
                } 
                catch(Exception ex)
                {

                }
            }
            return View("Index");
        }



    }
}

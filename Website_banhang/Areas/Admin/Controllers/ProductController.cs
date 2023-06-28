using Microsoft.AspNetCore.Mvc;
using Website_banhang.Models;
using Microsoft.EntityFrameworkCore;
using Website_banhang.Areas.Admin.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace Website_banhang.Areas.Admin.Controllers
{

    [Area("Admin")]
    [AuthorizeAdmin]
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly QlbhContext _context;
        public ProductController(QlbhContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
        public IActionResult Update(int productId, Product model, bool IsActive)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var item = _context.Products.FirstOrDefault(x => x.ProductId == productId);
                    
                    if(item != null)
                    {
                        item.ProductName = model.ProductName;
                        item.ProductDescription = model.ProductDescription;
                        item.ProductPrice = model.ProductPrice;
                        item.IsActive = IsActive;
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
            return RedirectToAction("Index", "Product", new {area = "Admin"});
        }



        // Create Product
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model, IFormFile imageFile)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var product = new Product

                    {
                        ProductName = model.ProductName,
                        ProductPrice = model.ProductPrice,
                        ProductDescription = model.ProductDescription,

                        // dữ liệu set mặc đinh để test chức năng chưa xử lý thêm hình ảnh và danh mục
                        IsActive = true,
                        CategoryId = 1

                    };

                    var entry = _context.Entry(product);
                    entry.State = EntityState.Added;
                    entry.Property("Filter").IsModified = false;
                    _context.SaveChanges();

                    if(imageFile != null && imageFile.Length > 0)
                    {
                        var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", imageFile.FileName);
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            imageFile.CopyTo(stream);
                        }

                        product.ProductImage = "/images/" + imageFile.FileName;
                        _context.SaveChanges();
                    }




                    return RedirectToAction("Index", "Product", new { area = "Admin" });
                }
                catch (Exception ex)
                {

                }
            }
            return View(model);
        }

    }
}

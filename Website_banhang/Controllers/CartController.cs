using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Website_banhang.Models;


namespace Website_banhang.Controllers
{


    public class CartController : Controller
    {
        private readonly QlbhContext _context;

        public CartController(QlbhContext context)
        {
            _context = context;
        } 


        public IActionResult Index()
        {
            return View();
        }

        // xử lí action thêm sản phẩm vào giỏ hàng (thêm sản phẩm vào cookie)
        public IActionResult AddToCart(int ProductId)
        {

            return View();
        }
        // xử lý lấy Cookie để hiện thị ngược ra view
        public IActionResult Cart()
        {
            return
        }

        // xử lý Get cookie
        private List<CartList> GetCookie()
        {

        }

        // xử lý Set cookie
        private void SetCookie(List<CartList> cartList) 
        {


        }

    }
}

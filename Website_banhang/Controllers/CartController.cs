using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Website_banhang.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;


namespace Website_banhang.Controllers
{


    public class CartController : Controller
    {
        private readonly QlbhContext _context;

        public CartController(QlbhContext context)
        {
            _context = context;
        } 


        public IActionResult Cart()
        {
            return View();
        }





        [HttpPost]
        // xử lí action thêm sản phẩm vào giỏ hàng (thêm sản phẩm vào cookie)
        public IActionResult AddToCart(int ProductId)
        {
            List<CartList> cartList = GetListFromCookie();

            CartList existItem = cartList.Find(x => x.ProductId == ProductId);
            if(existItem != null)
            {
                existItem.Quantity += 1;
            }
            else
            {
                CartList cartlist = new CartList()
                {
                    ProductId = ProductId,
                    Quantity = 1,
                };
                cartList.Add(cartlist);
            }
            SaveListToCookie(cartList);
            return Ok();
        }



        // xử lý lấy danh sách sản phẩm từ cookie
        private List<CartList> GetListFromCookie()
        {
            // check xem da co CartList trong cookie hay chua
            if (Request.Cookies.ContainsKey("CartList"))
            {
                // nếu có lấy ra từ cookie chuyển thành json và lưu vào List và trả về cho action addtocart
                string CartItemJson = Request.Cookies["CartList"];
                return JsonConvert.DeserializeObject<List<CartList>>(CartItemJson);

            }
            else
            {
            return new List<CartList>();
    
            }
        }

        // xử lý luu danh sách sản phẩm vào cookie
        private void SaveListToCookie(List<CartList> cartList)
        {
            string cartlistJson = JsonConvert.SerializeObject(cartList);

            // save vào cookie

            Response.Cookies.Append("CartList", cartlistJson, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(100),
                SameSite = SameSiteMode.Strict
            });
        }
    }
}

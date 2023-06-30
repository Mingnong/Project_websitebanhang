using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Website_banhang.Models;

namespace Website_banhang.Controllers
{
    public class OrderController : Controller
    {

        private readonly QlbhContext _context;

        public  OrderController(QlbhContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }


        // tạo Action Order

        public IActionResult CreateOrder()
        {
            // lấy userId từ session
            int userId = int.Parse(HttpContext.Session.GetString("UserId"));

            // lấy danh sách sản phẩm từ cookies

            List<CartList> cartLists = GetListFromCookie();

            // tính tổng Total Price

            decimal? totalPrice = cartLists.Sum(i => i.Quantity * i.Price);

            Order order = new Order()
            {
                UserId = userId,
                TotalPrice = totalPrice,
                PurchaseDate = DateTime.Now,

            };

            _context.Orders.Add(order);
            _context.SaveChanges();





            // lưu thông tin chi tiết vào bảng OrderItem

            foreach (var item in cartLists)
            {
                OrderItem orderItem = new OrderItem()
                {
                    OrderItem1 = 1,
                    OrderId = order.OrderId,
                    ProductId = item.ProductId,
                    OrderQuantity = item.Quantity,
                    OrderPrice = item.Price,
                    OrderTotalprice = item.Quantity * item.Price,
                };


                _context.Entry(orderItem).State = EntityState.Added;
                _context.SaveChanges();
            }



            ClearCookie();

            return RedirectToAction("OrderConfirm", new { orderId = order.OrderId });

        }

        // lấy thông tin trả về view order
        public IActionResult OrderConfirm(int orderId)
        {
            // lấy thông tin đơn hàng từ db

            Order order = _context.Orders.FirstOrDefault(i => i.OrderId == orderId);

            // lấy thông tin sản phẩm trong đơn hàng 
            List<OrderItem> orderItems = _context.OrderItems.Where(i => i.OrderId == orderId).ToList();

            return View(new OrderConfirmationViewModel
            {
                Order = order,
                OrderItems = orderItems
            });

        }





        // Xóa đi cookie

        private void ClearCookie()
        {
            Response.Cookies.Delete("CartList");
        }

        // get list form cookie

        private List<CartList> GetListFromCookie()
        {
            if (Request.Cookies.ContainsKey("CartList"))
            {
                string cartItemJson = Request.Cookies["CartList"];
                return JsonConvert.DeserializeObject<List<CartList>>(cartItemJson);
            }
            else
            {
                return new List<CartList>();
            }
        }

    }
}

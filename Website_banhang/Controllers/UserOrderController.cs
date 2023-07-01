
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using Newtonsoft.Json;
using Website_banhang.Models;


namespace Website_banhang.Controllers
{
    public class UserOrderController : Controller
    {

        private readonly QlbhContext _context;
        public UserOrderController(QlbhContext context)
        {
            _context = context;
        }

        public IActionResult GetOrder()
        {
            int userId = int.Parse(HttpContext.Session.GetString("UserId"));

            var OrderItem = _context.Orders.Where(o => o.UserId == userId).ToList();

            return View(OrderItem);
        }

        public IActionResult OrderDetail(int orderId)
        {
            // lấy thông tin đơn hàng từ db

            var Orderdetail = _context.OrderItems.Where(o => o.OrderId == orderId).ToList();
            

            return View(Orderdetail);

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

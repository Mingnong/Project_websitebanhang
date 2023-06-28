using Microsoft.AspNetCore.Mvc;
using Website_banhang.Models;
using Microsoft.EntityFrameworkCore;

namespace Website_banhang.Controllers
{
    public class UserController : Controller
    {
        private readonly QlbhContext _context;

        public UserController(QlbhContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        // xử lý đăng ký tài khoản
        [HttpPost]
        public IActionResult Register(User model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var ExistedAccount = _context.Users.FirstOrDefault(x => x.UserId == model.UserId);

                    if (ExistedAccount == null)
                    {
                        var User = new User
                        {
                            Username = model.Username,
                            UserAddress = model.UserAddress,
                            Password = model.Password,
                            RoleId = 1,
                            IsActive = true,
                            CreatedAt = DateTime.Now,
                        };

                        _context.Users.Add(User);
                        _context.SaveChanges();
                        return View("Index" , "User");
                    }
                    
                    return View("Index");

                }
                catch (Exception ex)
                {

                }
            }

            return View();
        }



        // Xử lý đăng nhập
        [HttpPost]
        public IActionResult Login(string Username, string Password )
        {
            if(Username == null && Password == null)
            {
                ViewBag.Error = "Vui lòng nhập đủ thông tin";
                return View("Index");
            }
            else
            {
                var existUser = _context.Users.FirstOrDefault(x => x.Username == Username);
                if(existUser == null || existUser.Password != Password)
                {
                    ViewBag.Error = "Email hoặc Password không chính xác";
                    return View("Index");
                }


                if(existUser.RoleId == 0)
                {
                    if (HttpContext.Session.GetString("AdminUserId") == null)
                    {
                        HttpContext.Session.SetString("AdminUserId", existUser.UserId.ToString());
                    }
                    return RedirectToAction("Index", "Home", new {area = "Admin"});
                }
                else
                {
                    if (HttpContext.Session.GetString("UserId") == null)
                    {
                        HttpContext.Session.SetString("UserId", existUser.UserId.ToString());
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
        }


        // Xử lý Log-out

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            Response.Cookies.Delete("CartList");

            return RedirectToAction("Index", "Home");
        }






    }
}

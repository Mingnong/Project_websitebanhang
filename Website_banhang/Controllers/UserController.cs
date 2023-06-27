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

        // xử lý đăng ký tài khoản
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



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
                return RedirectToAction("Index", "Home");
            }
        }









    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace Website_banhang.Areas.Admin.Authorization
{
    public class AuthorizeAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Kiểm tra xem có session "AdminUserId" tồn tại hay không
            if (context.HttpContext.Session.GetString("AdminUserId") == null)
            {
                // Chuyển hướng đến trang không được phép nếu session không tồn tại
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"area", "" },
                        { "controller", "User" },
                        { "action", "Index" },
                    });
            }

            base.OnActionExecuting(context);
        }
    }
}

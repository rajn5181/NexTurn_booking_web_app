using Microsoft.AspNetCore.Mvc;
using TravelBookingWebApp.Common;

namespace TravelBookingWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password, bool rememberMe)
        {
            var obj = new LoginCommon();
            var dtResult = obj.Get(email, password);
            if (dtResult != null)
            {
                // Store the user's login information in session or cookies
                if (rememberMe)
                {
                    // Store in cookies
                    Response.Cookies.Append("UserId", email);
                    Response.Cookies.Append("Password", password);
                }
                else
                {
                    // Store in session
                    HttpContext.Session.SetString("UserId", email);
                    HttpContext.Session.SetString("Password", password);
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

    }
}

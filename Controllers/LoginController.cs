
using Microsoft.AspNetCore.Mvc;
using TravelBookingWebApp.Models;

namespace TravelBookingWebApp.Controllers
{
    public class LoginController : Controller
    {
      
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel obj)
        {
            return View();
        }


    }
}

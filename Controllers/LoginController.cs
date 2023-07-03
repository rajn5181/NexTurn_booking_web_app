
using Microsoft.AspNetCore.Mvc;
namespace TravelBookingWebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace TravelBookingWebApp.Controllers
{
    public class TrainBookingController : Controller
    {
        public IActionResult TicketBook() 
        {
            return View();
        }
    }
}

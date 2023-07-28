using Microsoft.AspNetCore.Mvc;
using TravelBookingWebApp.Common;
using TravelBookingWebApp.Models;

namespace TravelBookingWebApp.Controllers
{
    public class BookingDetailsController : Controller
    {
        private BookingDetailsCommon bookingDetailsCommon;
        private TrainBookingModel trainBookingModels;

        public BookingDetailsController()
        {
            bookingDetailsCommon = new BookingDetailsCommon();
        }

        public IActionResult BookingDetails()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BookingDetails(int id)
        {

            // If the user is logged in, proceed to the booking details page
            var obj = new BookingDetailsCommon();
            var dtResult = obj.Get(id);
            return View(dtResult);

        }
    }
}

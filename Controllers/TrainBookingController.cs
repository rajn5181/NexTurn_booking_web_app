using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBookingWebApp.Common;
using TravelBookingWebApp.Models;

namespace TravelBookingWebApp.Controllers
{
    public class TrainBookingController : Controller
    {
        private CommonFunctions commonFunctions;

        public TrainBookingController()
        {
            commonFunctions = new CommonFunctions();
        }

        [HttpGet]
        public IActionResult TicketBook()
        {
            TrainBookingModel trainBookingModel = new TrainBookingModel();
            trainBookingModel.From = CommonFunctions.GetTrainListCode(true);
            trainBookingModel.To = CommonFunctions.GetTrainToCode(true);
            return View(trainBookingModel);
        }

        [HttpPost]
        public async Task<IActionResult> TicketBook([FromBody] TrainBookingModel model)
        {
            var bookingCommon = new TrainBookingCommon(); // Create an instance of TrainBookingCommon
            var dtResult = await Task.Run(() => bookingCommon.Get(model)); // Call Get method on the instance
            return Json(dtResult);
        }
        [HttpPost]
        public IActionResult Trainlist(TrainBookingModel model)
        {
            return View(model);
        }
    }
}

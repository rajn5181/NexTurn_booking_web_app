using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBookingWebApp.Common;
using TravelBookingWebApp.Models;
using Newtonsoft.Json;


namespace TravelBookingWebApp.Controllers
{
    public class TrainBookingController : Controller
    {
        private CommonFunctions commonFunctions;
        private DataTableCommon dataTableCommon;
        private List<TrainBookingModel> trainBookingModels = new List<TrainBookingModel>();

        public TrainBookingController()
        {
            commonFunctions = new CommonFunctions();
            dataTableCommon = new DataTableCommon();
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
            var bookingCommon = new TrainBookingCommon();
            var dtResult = await Task.Run(() => bookingCommon.Get(model));
            var trainDataTable = dataTableCommon.ConvertToDataTable(dtResult);

            trainBookingModels.Clear(); // Clear the existing list

            foreach (DataRow row in trainDataTable.Rows)
            {
                var trainBookingModel = new TrainBookingModel();
                trainBookingModel.TNo = Convert.ToInt32(row["TrainNo"]);
                trainBookingModel.TName = row["TrainName"].ToString();
                trainBookingModel.SEQ = Convert.ToInt32(row["SEQ"]);
                trainBookingModel.SCode = row["StationCode"].ToString();
                trainBookingModel.SName = row["StationName"].ToString();
                trainBookingModel.Distance = Convert.ToInt32(row["Distance"]);
                trainBookingModel.SSName = row["SourceStation"].ToString();
                trainBookingModel.DestStName = row["DestinationStation"].ToString();
                trainBookingModel.Atime = row["ArrivalTime"].ToString();
                trainBookingModel.DTime = row["DepartureTime"].ToString();

                trainBookingModels.Add(trainBookingModel);
            }

            return Json(trainBookingModels);
        }

    }
}

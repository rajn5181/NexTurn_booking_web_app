using Microsoft.AspNetCore.Mvc;
using TravelBookingWebApp.Common;
using TravelBookingWebApp.Models;

namespace TravelBookingWebApp.Controllers
{
    public class BookStatusController : Controller
    {
        public IActionResult Booklist()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Booklist(int trainNo, string trainName, string distance, string source, string destination,
           string name, string email, string phone, int age, int passengers)
        {
            UserBookingModel obj= new UserBookingModel();
            {
                obj.trainNo = trainNo;
                obj.trainName = trainName;
                obj.distance = distance;
                obj.source = source;
                obj.destination = destination;
                obj.name = name;
                obj.email = email;
                obj.phone = phone;
                obj.age = age;
                obj.passengers = passengers;
                var datasave = new BookStatusCommon();
                datasave.Save(obj);
            }
            return View();
        }
    }
}

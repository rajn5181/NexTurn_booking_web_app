using Microsoft.AspNetCore.Mvc.Rendering;

namespace TravelBookingWebApp.Models
{
    public class TrainBookingModel
    {
        public List<SelectListItem> From { get; set; }
        public string Source { get; set; } 
        public string Destination { get; set; }
        public List<SelectListItem> To { get; set; }
        public string? Name { get; set; }
        public DateTime TravelDate { get; set; }
        public int Adult { get; set; }
        public int Children { get; set; }
        public int TNo { get; set; }
        public string? TName { get; set; }
        public int SEQ { get; set; }
        public string? SCode { get; set; }
        public string ?SName { get; set; }
        public TimeZone? Atime { get; set; }
        public TimeZone ?DTime { get; set; }
        public int Distance { get; set; }
        public string SSName { get; set; }
        public List<SelectListItem> SStation { get; set; }
       
        public List<SelectListItem> DSName { get; set; }
        public string DestStName { get; set; }

    }
}

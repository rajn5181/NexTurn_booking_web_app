using System.ComponentModel.DataAnnotations;

namespace TravelBookingWebApp.Models
{
    public class LoginModel
    {
        [Required]
        public string userid { get;set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string email { get; set; }
        public bool rememberMe { get; set; }
    }
}

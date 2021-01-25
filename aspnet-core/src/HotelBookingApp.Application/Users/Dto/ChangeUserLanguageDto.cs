using System.ComponentModel.DataAnnotations;

namespace HotelBookingApp.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
using Abp.Application.Services.Dto;

namespace HotelBookingApp.Hotels.Dto
{
    public class PagedHotelResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

using Abp.Application.Services;
using HotelBookingApp.Hotels.Dto;

namespace HotelBookingApp.Hotels
{
    public interface IHotelAppService : IAsyncCrudAppService<HotelDto, int, PagedHotelResultRequestDto>
    {

    }
}

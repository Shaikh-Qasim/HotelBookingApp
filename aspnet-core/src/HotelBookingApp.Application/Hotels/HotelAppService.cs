using Abp.Application.Services;
using Abp.Domain.Repositories;
using HotelBookingApp.Hotels.Dto;

namespace HotelBookingApp.Hotels
{
    public class HotelAppService : AsyncCrudAppService<Hotel, HotelDto, int, PagedHotelResultRequestDto>, IHotelAppService
    {
        public HotelAppService(IRepository<Hotel, int> repository) : base(repository)
        {
        }
    }
}

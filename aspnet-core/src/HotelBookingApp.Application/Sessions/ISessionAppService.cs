using System.Threading.Tasks;
using Abp.Application.Services;
using HotelBookingApp.Sessions.Dto;

namespace HotelBookingApp.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

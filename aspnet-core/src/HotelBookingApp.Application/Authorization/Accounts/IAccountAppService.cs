using System.Threading.Tasks;
using Abp.Application.Services;
using HotelBookingApp.Authorization.Accounts.Dto;

namespace HotelBookingApp.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

using Abp.Application.Services;
using HotelBookingApp.MultiTenancy.Dto;

namespace HotelBookingApp.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


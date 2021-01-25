using System.Threading.Tasks;
using HotelBookingApp.Configuration.Dto;

namespace HotelBookingApp.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

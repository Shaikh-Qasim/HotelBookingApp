using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using HotelBookingApp.Configuration.Dto;

namespace HotelBookingApp.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : HotelBookingAppAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

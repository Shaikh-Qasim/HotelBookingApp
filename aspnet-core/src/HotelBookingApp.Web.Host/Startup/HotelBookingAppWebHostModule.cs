using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HotelBookingApp.Configuration;

namespace HotelBookingApp.Web.Host.Startup
{
    [DependsOn(
       typeof(HotelBookingAppWebCoreModule))]
    public class HotelBookingAppWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public HotelBookingAppWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HotelBookingAppWebHostModule).GetAssembly());
        }
    }
}

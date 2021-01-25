using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HotelBookingApp.Authorization;

namespace HotelBookingApp
{
    [DependsOn(
        typeof(HotelBookingAppCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class HotelBookingAppApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<HotelBookingAppAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(HotelBookingAppApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}

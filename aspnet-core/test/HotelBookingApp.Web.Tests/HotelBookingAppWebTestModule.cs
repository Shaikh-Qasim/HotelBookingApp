using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HotelBookingApp.EntityFrameworkCore;
using HotelBookingApp.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace HotelBookingApp.Web.Tests
{
    [DependsOn(
        typeof(HotelBookingAppWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class HotelBookingAppWebTestModule : AbpModule
    {
        public HotelBookingAppWebTestModule(HotelBookingAppEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HotelBookingAppWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(HotelBookingAppWebMvcModule).Assembly);
        }
    }
}
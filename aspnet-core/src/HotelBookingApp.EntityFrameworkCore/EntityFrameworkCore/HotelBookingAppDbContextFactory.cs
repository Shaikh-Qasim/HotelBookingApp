using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using HotelBookingApp.Configuration;
using HotelBookingApp.Web;

namespace HotelBookingApp.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class HotelBookingAppDbContextFactory : IDesignTimeDbContextFactory<HotelBookingAppDbContext>
    {
        public HotelBookingAppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<HotelBookingAppDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            HotelBookingAppDbContextConfigurer.Configure(builder, configuration.GetConnectionString(HotelBookingAppConsts.ConnectionStringName));

            return new HotelBookingAppDbContext(builder.Options);
        }
    }
}

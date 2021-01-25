using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.EntityFrameworkCore
{
    public static class HotelBookingAppDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<HotelBookingAppDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<HotelBookingAppDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

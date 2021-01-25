using Abp.Zero.EntityFrameworkCore;
using HotelBookingApp.Authorization.Roles;
using HotelBookingApp.Authorization.Users;
using HotelBookingApp.Hotels;
using HotelBookingApp.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.EntityFrameworkCore
{
    public class HotelBookingAppDbContext : AbpZeroDbContext<Tenant, Role, User, HotelBookingAppDbContext>
    {

        public HotelBookingAppDbContext(DbContextOptions<HotelBookingAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
    }
}

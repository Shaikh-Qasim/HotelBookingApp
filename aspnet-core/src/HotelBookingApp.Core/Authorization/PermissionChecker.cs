using Abp.Authorization;
using HotelBookingApp.Authorization.Roles;
using HotelBookingApp.Authorization.Users;

namespace HotelBookingApp.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

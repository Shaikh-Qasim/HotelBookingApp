using System.Threading.Tasks;
using HotelBookingApp.Models.TokenAuth;
using HotelBookingApp.Web.Controllers;
using Shouldly;
using Xunit;

namespace HotelBookingApp.Web.Tests.Controllers
{
    public class HomeController_Tests: HotelBookingAppWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
using Moq;
using RiverLoggerApi.Controllers;
using RiverLoggerApi.Models;
using RiverLoggerApi.Services;

namespace RiverLoggerApi.Test.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        public UserControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
        }
        [Fact]
        public void GivenACalltoCreateUser_WhenAUserIsPassed_ThenUserServiceShouldBeCalledOnce()
        {
            //Arrage
            var user = GeAUser();
            _userServiceMock.Setup(x => x.Create(user)).Verifiable();
            var uc = new UserController(_userServiceMock.Object);

            //Act
            uc.CreateUser(user);

            //Assert
            _userServiceMock.Verify(x=>x.Create(user),Times.Once);

        }

        private static User GeAUser()
        {
            return new User
            {
                Name = "John",
                LastName = "Kahn",
                Email = "jjjkahn@gmail.com",
                Password = "password",
                EmailConfirmed = "jjjkahn@gmail.com",
                UserId = Guid.NewGuid()
            };
        }
    }
}

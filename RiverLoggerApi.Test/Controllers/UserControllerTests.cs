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
        public void GivenACalltoRegisterUser_WhenAUserIsPassed_ThenUserServiceShouldBeCalledOnce()
        {
            //Arrage
            var user = GeAUser();
            _userServiceMock.Setup(x => x.Create(user)).Verifiable();
            var uc = new UserController(_userServiceMock.Object);

            //Act
            uc.RegisterUser(user);

            //Assert
            _userServiceMock.Verify(x => x.Create(user), Times.Once);
        }

        [Fact]
        public async Task GivenACalltoGetAll_WhenIsCalled_ThenUserServiceShouldBeCalledOnceAsync()
        {
            //Arrage
            _userServiceMock.Setup(x => x.GetAll()).Verifiable();
            var uc = new UserController(_userServiceMock.Object);

            //Act
             await uc.Get();

            //Assert
            _userServiceMock.Verify(x => x.GetAll(), Times.Once);
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

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


    }
}

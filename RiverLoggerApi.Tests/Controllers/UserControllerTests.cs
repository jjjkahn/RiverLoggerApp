

using Moq;
using NUnit.Framework;
using RiverLoggerApi.Services;

namespace RiverLoggerApi.Tests.Controllers
{
    [TestFixture]
    public class UserControllerTests
    {
        private readonly new Mock<IUserService> _userService;
        public UserControllerTests(IUserService userService)
        {
                _userService = userService;
        }

        [SetUp]
        public void Setup()
        {

        }

    }
}

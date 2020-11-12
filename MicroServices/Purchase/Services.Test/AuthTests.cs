using Core;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using Services.AuthServices;

namespace Services.Test
{
    public class AuthTests
    {
        IAuthService _authService;
        [SetUp]
        public void Setup()
        {
            var options = Options.Create<AppSettings>(new AppSettings() { Secret = "ouNtF8Xds1jE55/d+iVZ99u0f2U6lQ+AHdiPFwjVW3o=" });
            _authService = new AuthService(options);
        }

        [Test]
        [TestCase(1)]
        public void MustSuccess(int userId)
        {
            var model = _authService.GetUserById(userId);
            Assert.IsNotNull(model);
        }

        [Test]
        [TestCase(0)]
        public void MustFail(int userId)
        {
            var model = _authService.GetUserById(userId);
            Assert.IsNull(model);
        }
    }
}
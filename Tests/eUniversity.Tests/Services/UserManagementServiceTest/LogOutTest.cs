using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ManagementServices.Auth;
using eUniversity.Business.Services.Auth;
using eUniversity.Data.Contracts;
using Moq;
using NUnit.Framework;

namespace eUniversity.Tests.Services.UserServiceTest
{
    [TestFixture]
    public class LogOutTest
    {
        [Test]
        public void LogOut_Success()
        {
            // Setup
            var formsAuthentication = new Mock<IFormsAuthenticationService>();

            var userService = new Mock<IUserService>();
            IUserManagementService userManagementService = new UserManagementService(userService.Object, formsAuthentication.Object, new Mock<IEUniversityUow>().Object);
            // Action
            userManagementService.LogOut();
            // Verify the result
            formsAuthentication.Verify(x => x.LogOut(), Times.Once());
        }
    }
}

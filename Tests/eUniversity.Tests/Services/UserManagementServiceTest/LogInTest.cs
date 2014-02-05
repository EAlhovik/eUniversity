using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ManagementServices.Auth;
using eUniversity.Business.ViewModels.Auth;
using eUniversity.Data.Contracts;
using Moq;
using NUnit.Framework;

namespace eUniversity.Tests.Services.UserServiceTest
{
    [TestFixture]
    public class LogInTest
    {
        [Test]
        public void ValidUserTryLogIn_UserLogIn()
        {
            // Setup
            var user = new LoginViewModel() { UserName = "Matthew", Password = "MacDonald", RememberMe = false };
            var formsAuthentication = new Mock<IFormsAuthenticationService>();

            var userService = new Mock<IUserService>();
            userService.Setup(f => f.ValidateUser(user.UserName, user.Password)).Returns(true);

            IMembershipManagementService membershipManagementService = new MembershipManagementService(userService.Object, formsAuthentication.Object, new Mock<IEUniversityUow>().Object,
                new Mock<IAuthorizationService>().Object, new Mock<IRoleService>().Object);
            // Action
            var isLogIn = membershipManagementService.LogIn(user);
            // Verify the result
            formsAuthentication.Verify(x => x.SetAuthCookie(It.IsAny<string>(), false), Times.Once());
            Assert.IsTrue(isLogIn);
        }

        [Test]
        public void InvalidUserTryLogIn_UserDoesntLogIn()
        {
            // Setup
            var user = new LoginViewModel() { UserName = "Matthew", Password = "MacDonald", RememberMe = false };
            var formsAuthentication = new Mock<IFormsAuthenticationService>();

            var userService = new Mock<IUserService>();
            userService.Setup(f => f.ValidateUser(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

            IMembershipManagementService membershipManagementService = new MembershipManagementService(userService.Object, formsAuthentication.Object, new Mock<IEUniversityUow>().Object,
                new Mock<IAuthorizationService>().Object, new Mock<IRoleService>().Object);
            // Action
            var isLogIn = membershipManagementService.LogIn(user);
            // Verify the result
            formsAuthentication.Verify(x => x.SetAuthCookie(It.IsAny<string>(), false), Times.Never());
            Assert.IsFalse(isLogIn);
        }
    }
}

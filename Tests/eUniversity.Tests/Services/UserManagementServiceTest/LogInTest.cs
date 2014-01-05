using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Services.Auth;
using eUniversity.Business.ViewModels.Auth;
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

            IUserManagementService userManagementService = new UserManagementService(userService.Object, formsAuthentication.Object);
            // Action
            var isLogIn = userManagementService.LogIn(user);
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

            IUserManagementService userManagementService = new UserManagementService(userService.Object, formsAuthentication.Object);
            // Action
            var isLogIn = userManagementService.LogIn(user);
            // Verify the result
            formsAuthentication.Verify(x => x.SetAuthCookie(It.IsAny<string>(), false), Times.Never());
            Assert.IsFalse(isLogIn);
        }
    }
}

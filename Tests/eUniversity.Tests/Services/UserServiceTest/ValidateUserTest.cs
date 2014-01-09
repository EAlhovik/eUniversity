using System.Collections.Generic;
using System.Linq;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Services.Auth;
using eUniversity.Data.Contracts;
using Moq;
using NUnit.Framework;

namespace eUniversity.Tests.Services.UserServiceTest
{
    [TestFixture]
    public class ValidateUserTest
    {
        private IUserService userService;

        [SetUp]
        public void Init()
        {
            var repository = new Mock<IRepository<User>>();
            var data = new List<User>
            {
                new User {UserName = "John", Password = "wdasd"},
                new User {UserName = "Jane", Password = "Doe"},
                new User {UserName = "John", Password = "Smith"},
                new User {UserName = "Matthew", Password = "MacDonald"},
                new User {UserName = "Andrew", Password = "MacDonald"}
            };
            repository.Setup(r => r.All()).Returns(data.AsQueryable());

            var formsAuthentication = new Mock<IFormsAuthenticationService>();
            formsAuthentication.Setup(f => f.CreatePasswordHash("Doe", "SHA1")).Returns("wdasd");
            userService = new UserService(repository.Object, formsAuthentication.Object, new Mock<IRepository<Role>>().Object );
        }

        [Test]
        public void CorrectUserNameAndPasword_UserValidated()
        {
            // Setup
      
            // Action
            var isValidated = userService.ValidateUser("John", "Doe");

             // Verify the result
            Assert.IsTrue(isValidated);
        }

        [Test]
        public void IncorectPasword_UserNotValidated()
        {
            // Setup
      
            // Action
            var isValidated = userService.ValidateUser("John", "Do123e");

             // Verify the result
            Assert.IsFalse(isValidated);
        }

        [Test]
        public void NotExistUserName_UserNotValidated()
        {
            var isValidated = userService.ValidateUser("Matthew", "Doe");

            Assert.IsFalse(isValidated);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers.Enums;
using eUniversity.Business.Services.Auth;
using eUniversity.Data.Contracts;
using Moq;
using NUnit.Framework;

namespace eUniversity.Tests.Services.UserServiceTest
{
    [TestFixture]
    public class GetRolesTest
    {
        private IRepository<Role> roleRepository;
        [SetUp]
        public void Init()
        {
            var roles = new List<Role>()
            {
                new Role() {Id = 1, RoleName = "Student", RoleType = RoleEnum.Student},
                new Role() {Id = 2, RoleName = "Professor", RoleType = RoleEnum.Professor},
                new Role() {Id = 3, RoleName = "Admin", RoleType = RoleEnum.Admin},
            };
            var mockRepository = new Mock<IRepository<Role>>();
            mockRepository.Setup(f => f.All()).Returns(roles.AsQueryable());

            roleRepository = mockRepository.Object;
        }

        [Test]
        public void GetAllRoles_Success()
        {
            // Setup
            IRoleService roleService = new UserService(new Mock<IRepository<User>>().Object, new Mock<IFormsAuthenticationService>().Object, roleRepository);

            // Action
            var data = roleService.GetRoles();

            // Verify the result
            Assert.AreEqual(roleRepository.All().Count(), data.Count());
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers.Enums;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.Services.Auth
{
    /// <summary>
    /// Represents user service
    /// </summary>
    public class UserService : IUserService, IRoleService
    {
        private readonly IRepository<User> userRepository;
        private readonly IFormsAuthenticationService formsAuthenticationService;

        private readonly IRepository<Role> roleRepository;

        public UserService(IRepository<User> userRepository, IFormsAuthenticationService formsAuthenticationService, IRepository<Role> roleRepository)
        {
            this.userRepository = userRepository;
            this.formsAuthenticationService = formsAuthenticationService;
            this.roleRepository = roleRepository;
        }

        #region IUserService Members

        /// <summary>
        /// Validates the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// true if the supplied user name and password are valid; otherwise, false.
        /// </returns>
        public bool ValidateUser(string userName, string password)
        {
            var hashedPassword = formsAuthenticationService.CreatePasswordHash(password);
            return userRepository.All().Any(user => user.UserName == userName && user.Password == hashedPassword);
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void RegisterUser(User user)
        {
            var hashedPassword = formsAuthenticationService.CreatePasswordHash(user.Password);
            user.Password = hashedPassword;
            userRepository.InsertOrUpdate(user);

        }

        /// <summary>
        /// Gets the name of the user by.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>User</returns>
        public User GetUserByName(string userName)
        {
            var user = userRepository.All().First(u => u.UserName == userName);
            return user;
        }

        #endregion

        #region IRoleService Members

        /// <summary>
        /// Gets the user roles.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public string[] GetUserRoles(string userName)
        {
            var user = GetUserByName(userName);
            return user.Roles.Select(role => role.RoleName).ToArray();
        }

        public IEnumerable<Role> GetRoles()
        {
            return roleRepository.All();
        }

        public bool IsUserInRole(User user, RoleEnum role)
        {
            throw new System.NotImplementedException();
        }

        public void AddUserToRole(User user, RoleEnum role)
        {
            throw new System.NotImplementedException();
        }

        #endregion

    }
}
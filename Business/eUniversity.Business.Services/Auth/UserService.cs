using System;
using System.Collections.Generic;
using System.Linq;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers.Enums;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;
using eUniversity.Data.Entities;

namespace eUniversity.Business.Services.Auth
{
    /// <summary>
    /// Represents user service
    /// </summary>
    public class UserService :BaseService<User>, IUserService, IRoleService
    {
        private readonly IFormsAuthenticationService formsAuthenticationService;

        private readonly IRepository<Role> roleRepository;

        public UserService(IRepository<User> userRepository, IFormsAuthenticationService formsAuthenticationService, IRepository<Role> roleRepository)
            : base(userRepository)
        {
            this.formsAuthenticationService = formsAuthenticationService;
            this.roleRepository = roleRepository;
        }

        #region IUserService Members

        public IEnumerable<User> GetUsersByRole(RoleEnum role)
        {
            return roleRepository.All().Where(r => r.RoleType == role).SelectMany(r => r.Users);
        }

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
            return Repository.All().Any(user => user.UserName == userName && user.Password == hashedPassword);
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="accountType"> Account type </param>
        public void RegisterUser(User user, AccountTypeEnum accountType)
        {
            var hashedPassword = formsAuthenticationService.CreatePasswordHash(user.Password);
            user.Password = hashedPassword;
            Save(user);
            var role = GetRoleByType(GetDefaultRoleForAccountType(accountType));
            user.Roles = new List<Role> { role };
        }

        /// <summary>
        /// Gets the name of the user by.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>User</returns>
        public User GetUserByName(string userName)
        {
            var user = Repository.All()
                .SingleOrDefault(u => u.UserName == userName);
            return user;
        }

        #endregion

        private RoleEnum GetDefaultRoleForAccountType(AccountTypeEnum accountType)
        {
            switch (accountType)
            {
                case AccountTypeEnum.Student:
                    return RoleEnum.Student;
                case AccountTypeEnum.Professor:
                    return RoleEnum.Professor;
                default:
                    throw new ArgumentOutOfRangeException("accountType");
            }
        }

        private Role GetRoleByType(RoleEnum role)
        {
            return roleRepository.All().First(r => r.RoleType == role);
        }

        #region IRoleService Members

        /// <summary>
        /// Gets the user roles.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        public string[] GetUserRoles(string userName)
        {
            var user = GetUserByName(userName);
            if (user == null) return new List<string>().ToArray();
            return roleRepository.All().Where(r => r.Users.Any(u => u.Id == user.Id)).Select(role => role.RoleName).ToArray(); ;
            return user.Roles.Select(role => role.RoleName).ToArray(); // todo: remove  
        }

        public IEnumerable<Role> GetRoles()
        {
            return roleRepository.All();
        }

        public bool IsUserInRole(string userName, RoleEnum role)
        {
            var user = GetUserByName(userName);
            return roleRepository.All().Any(r => r.Users.Any(u => u.Id == user.Id) && r.RoleType == role);
        }

        public void AddUserToRole(User user, RoleEnum role)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region BaseService Members

        protected override User CreateItem()
        {
            throw new NotImplementedException();
        }

        protected override SelectedItemModel CreateSelectedItem(User item)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
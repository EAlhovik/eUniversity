using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers.Enums;
using eUniversity.Business.ViewModels.Auth;
using eUniversity.Business.ViewModels.Membership;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.ManagementServices.Auth
{
    /// <summary>
    /// Represents user management service
    /// </summary>
    public class MembershipManagementService : IMembershipManagementService
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly IFormsAuthenticationService formsAuthenticationService;
        private readonly IEUniversityUow eUniversityUow;
        private readonly IAuthorizationService authorizationService;

        public MembershipManagementService(IUserService userService, IFormsAuthenticationService formsAuthenticationService, 
            IEUniversityUow eUniversityUow, IAuthorizationService authorizationService, IRoleService roleService)
        {
            this.userService = userService;
            this.formsAuthenticationService = formsAuthenticationService;
            this.eUniversityUow = eUniversityUow;
            this.authorizationService = authorizationService;
            this.roleService = roleService;
        }

        #region IMembershipManagementService Members

        public IEnumerable<UserRowViewModel> GetUsers()
        {
            var users = GetAvailableUsers();
            var viewModels = users.Select(Mapper.Map<User, UserRowViewModel>);
            return viewModels;
        }

        private IEnumerable<User> GetAvailableUsers()
        {
            if (roleService.IsUserInRole(authorizationService.User.Identity.Name, RoleEnum.Admin))
            {
                return userService.All();
            }
            if (roleService.IsUserInRole(authorizationService.User.Identity.Name, RoleEnum.Professor))
            {
                return userService.GetUsersByRole(RoleEnum.Student);
            }
            throw new SecurityException();
        }

        /// <summary>
        /// Logs the in.
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns> true if the supplied user name and password are valid; otherwise, false. </returns>
        public bool LogIn(LoginViewModel loginViewModel)
        {
            if (userService.ValidateUser(loginViewModel.UserName, loginViewModel.Password))
            {
                formsAuthenticationService.SetAuthCookie(loginViewModel.UserName, loginViewModel.RememberMe);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Log out.
        /// </summary>
        public void LogOut()
        {
            formsAuthenticationService.LogOut();
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="registerViewModel">The register view model.</param>
        public void RegisterUser(RegisterViewModel registerViewModel)
        {
            var user = Mapper.Map<RegisterViewModel, User>(registerViewModel);
            userService.RegisterUser(user, registerViewModel.AccountType);
            eUniversityUow.Commit();
        }

        public bool Validate(RegisterViewModel registerViewModel)
        {
            throw new NotImplementedException();
        }
        
        #endregion

    }
}
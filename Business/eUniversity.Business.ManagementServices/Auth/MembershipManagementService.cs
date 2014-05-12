using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.Base;
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
        private readonly IStudentProfileService studentProfileService;

        public MembershipManagementService(IUserService userService, IFormsAuthenticationService formsAuthenticationService, 
            IEUniversityUow eUniversityUow, IAuthorizationService authorizationService, IRoleService roleService, IStudentProfileService studentProfileService)
        {
            this.userService = userService;
            this.formsAuthenticationService = formsAuthenticationService;
            this.eUniversityUow = eUniversityUow;
            this.authorizationService = authorizationService;
            this.roleService = roleService;
            this.studentProfileService = studentProfileService;
        }

        #region IMembershipManagementService Members

        public bool IsCurrentUserInRole(ViewModels.Enums.RoleEnum role)
        {
            var userName = authorizationService.User.Identity.Name;
            switch (role)
            {
                case ViewModels.Enums.RoleEnum.Student:
                    return roleService.IsUserInRole(userName, RoleEnum.Student);
                case ViewModels.Enums.RoleEnum.Professor:
                    return roleService.IsUserInRole(userName, RoleEnum.Professor);
                default:
                    throw new ArgumentOutOfRangeException("role");
            }
        }

        public void ApproveUsers(IEnumerable<long> userIds)
        {
            foreach (var userId in userIds)
            {
                userService.ApproveUser(userId);
            }
            eUniversityUow.Commit();
        }

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
            if (userService.ValidateUser(loginViewModel.Email, loginViewModel.Password))
            {
                formsAuthenticationService.SetAuthCookie(loginViewModel.Email, false);
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
        /// <returns>
        ///   <c>true</c> if user successful registered; otherwise, <c>false</c>.
        /// </returns>
        public bool Register(RegisterFormViewModel registerViewModel)
        {
            if (Validate(registerViewModel))
            {
                var user = RegisterUser(registerViewModel.Register);
                CreateProfile(registerViewModel.Profile, user);

                eUniversityUow.Commit();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Validates the specified register view model.
        /// </summary>
        /// <param name="registerViewModel">The register view model.</param>
        /// <returns>
        ///    <c>true</c> if Register and Profile valid; otherwise, <c>false</c>.
        /// </returns>
        public bool Validate(RegisterFormViewModel registerViewModel)
        {
            bool isValid = ValidateRegister(registerViewModel);
            if (isValid)
            {
                isValid = ValidateProfile(registerViewModel);
            }
            registerViewModel.Errors = errors;
            return isValid;
        }

        #endregion

        private List<string> errors = new List<string>();

        private bool ValidateProfile(RegisterFormViewModel registerViewModel)
        {
            if (registerViewModel.Profile == null)
            {
                registerViewModel.Profile = new ProfileViewModel();
                return false;
            }
            if (string.IsNullOrEmpty(registerViewModel.Profile.FirstName))
            {
                
            }
            if (string.IsNullOrEmpty(registerViewModel.Profile.LastName))
            {
                
            }
            if (registerViewModel.Register.AccountType == AccountTypeEnum.Student)
            {
                if (registerViewModel.Profile.Group == null)
                {
                    
                }
                else
                {
                    //todo: additional group checks, if need
                }
            }
            return !errors.Any();
        }

        private bool ValidateRegister(RegisterFormViewModel registerViewModel)
        {
            if (string.IsNullOrEmpty(registerViewModel.Register.Email))
            {
                
            }
            if (string.IsNullOrEmpty(registerViewModel.Register.Password))
            {
                
            }
            if(!registerViewModel.Register.Password.Equals(registerViewModel.Register.ConfirmPassword))
            {

            }
            return !errors.Any();
        }

        private User RegisterUser(RegisterViewModel registerViewModel)
        {
            var user = Mapper.Map<RegisterViewModel, User>(registerViewModel);
            userService.RegisterUser(user, registerViewModel.AccountType);
            return user;
        }

        private void CreateProfile(ProfileViewModel profileViewModel, User user)
        {
            var profile = Mapper.Map<ProfileViewModel, StudentProfile>(profileViewModel);
            profile.User = user;
            studentProfileService.Save(profile);
        }
    }
}
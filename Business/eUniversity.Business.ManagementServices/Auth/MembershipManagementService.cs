using System;
using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ViewModels.Auth;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.ManagementServices.Auth
{
    /// <summary>
    /// Represents user management service
    /// </summary>
    public class MembershipManagementService : IMembershipManagementService
    {
        private readonly IUserService userService;
        private readonly IFormsAuthenticationService formsAuthenticationService;
        private readonly IEUniversityUow eUniversityUow;

        public MembershipManagementService(IUserService userService, IFormsAuthenticationService formsAuthenticationService, IEUniversityUow eUniversityUow)
        {
            this.userService = userService;
            this.formsAuthenticationService = formsAuthenticationService;
            this.eUniversityUow = eUniversityUow;
        }

        #region IMembershipManagementService Members

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
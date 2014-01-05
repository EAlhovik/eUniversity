using System;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels.Auth;

namespace eUniversity.Business.Services.Auth
{
    /// <summary>
    /// Represents user management service
    /// </summary>
    public class UserManagementService : IUserManagementService
    {
        private readonly IUserService userService;
        private readonly IFormsAuthenticationService formsAuthenticationService;

        public UserManagementService(IUserService userService, IFormsAuthenticationService formsAuthenticationService)
        {
            this.userService = userService;
            this.formsAuthenticationService = formsAuthenticationService;
        }

        #region IUserManagementService Members

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

        #endregion

    }
}
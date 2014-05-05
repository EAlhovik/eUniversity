using System.Collections.Generic;
using eUniversity.Business.ViewModels.Auth;
using eUniversity.Business.ViewModels.Enums;
using eUniversity.Business.ViewModels.Membership;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for user management service
    /// </summary>
    public interface IMembershipManagementService
    {
        /// <summary>
        /// Logs the in.
        /// </summary>
        /// <returns> true if the supplied user name and password are valid; otherwise, false. </returns>
        bool LogIn(LoginViewModel loginViewModel);

        void LogOut();

        bool Register(RegisterFormViewModel registerViewModel);

        bool Validate(RegisterFormViewModel registerViewModel);

        IEnumerable<UserRowViewModel> GetUsers();
        void ApproveUsers(IEnumerable<long> userIds);
        bool IsCurrentUserInRole(RoleEnum role);
    }
}
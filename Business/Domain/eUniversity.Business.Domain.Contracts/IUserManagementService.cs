using eUniversity.Business.ViewModels.Auth;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for user management service
    /// </summary>
    public interface IUserManagementService
    {
        /// <summary>
        /// Logs the in.
        /// </summary>
        /// <returns> true if the supplied user name and password are valid; otherwise, false. </returns>
        bool LogIn(LoginViewModel loginViewModel);

        void LogOut();

        void RegisterUser(RegisterViewModel registerViewModel);

        bool Validate(RegisterViewModel registerViewModel);
    }
}
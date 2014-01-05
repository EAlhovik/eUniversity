using System.Linq;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.Services.Auth
{
    /// <summary>
    /// Represents user service
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IFormsAuthenticationService formsAuthenticationService;

        public UserService(IRepository<User> userRepository, IFormsAuthenticationService formsAuthenticationService)
        {
            this.userRepository = userRepository;
            this.formsAuthenticationService = formsAuthenticationService;
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
            return userRepository.All().Any(user => user.UserName == userName && user.Password == hashedPassword);
        }

//        /// <summary>
//        /// Logs in to site.
//        /// </summary>
//        /// <param name="userName">Name of the user.</param>
//        /// <param name="password">The password.</param>
//        /// <returns>
//        /// true if the supplied user name and password are valid; otherwise, false.
//        /// </returns>
//        public bool LogIn(string userName, string password)
//        {
//            if (ValidateUser(userName, password))
//            {
//                formsAuthenticationService.SetAuthCookie(userName, false);
//                return true;
//            }
//            return false;
//        }
//
//        /// <summary>
//        /// log out user from the browser.
//        /// </summary>
//        public void LogOut()
//        {
//            formsAuthenticationService.LogOut();
//        }
    }
}
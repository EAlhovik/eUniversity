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

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
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
            return userRepository.All().Any(user => user.UserName == userName && user.Password == password);
        }
    }
}
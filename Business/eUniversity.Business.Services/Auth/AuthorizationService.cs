using System.Security.Principal;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Business.Services.Auth
{
    /// <summary>
    /// Represents authorization service
    /// </summary>
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserService userService;

        public AuthorizationService(IUserService userService)
        {
            this.userService = userService;
        }

        public IPrincipal User
        {
            get;
            set;
        }

        public User CurrentUser
        {
            get
            {
                return currentUser ?? (currentUser = userService.GetUserByName(User.Identity.Name));
            }
            set
            {
                currentUser = value;
            }
        }

        private User currentUser;
    }
}
using System.Security.Principal;
using eUniversity.Business.Domain.Contracts;

namespace eUniversity.Business.Services.Auth
{
    /// <summary>
    /// Represents authorization service
    /// </summary>
    public class AuthorizationService : IAuthorizationService
    {
        public IPrincipal User
        {
            get;
            set;
        }
    }
}
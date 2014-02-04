using System.Security.Principal;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interafce for authorization service
    /// </summary>
    public interface IAuthorizationService
    {
        IPrincipal User { get; set; }
    }
}
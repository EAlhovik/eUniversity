using System.Security.Principal;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interafce for authorization service
    /// </summary>
    public interface IAuthorizationService
    {
        IPrincipal User { get; set; }

        User CurrentUser { get; set; }
    }
}
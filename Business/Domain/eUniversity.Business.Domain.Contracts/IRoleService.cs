using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.Base;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers.Enums;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for rolse service
    /// </summary>
    public interface IRoleService
    {
        IEnumerable<Role> GetRoles();

        bool IsUserInRole(string userName, RoleEnum role);

        void AddUserToRole(User user, RoleEnum role);

        string[] GetUserRoles(string userName);
    }
}
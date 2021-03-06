﻿using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.Base;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers.Enums;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for User service
    /// </summary>
    public interface IUserService : IBaseService<User>
    {
        /// <summary>
        /// Validates the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns> true if the supplied user name and password are valid; otherwise, false.  </returns>
        bool ValidateUser(string userName, string password);

        void RegisterUser(User user, AccountTypeEnum accountType);

        User GetUserByName(string userName);

        IEnumerable<User> GetUsersByRole(RoleEnum role);
        void ApproveUser(long userId);
    }
}
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using Autofac;
using eUniversity.Business.Domain.Contracts;

namespace eUniversity.Web.Extensions
{
    public class CustomRoleProvider:RoleProvider
    {
        public override string[] GetAllRoles()
        {
            throw new System.NotImplementedException();
        }
        public override string[] GetRolesForUser(string username)
        {
            var roleService = DependencyResolver.Current.GetService<IRoleService>();
//                var roleService = MvcApplication.Container.Resolve<IRoleService>();
                return roleService.GetUserRoles(username);
        }   

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new System.NotImplementedException();
        }

        #region Not Implemented

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }


        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }

        #endregion

    }
}
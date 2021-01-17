﻿using Inveon.DataAccess.Abstract;
using Inveon.DataAccess.Concrete.EntityFramework;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Inveon.WebUI.Models
{
    public class UserRoleProvider : RoleProvider
    {
        private readonly IAccountRepository _accountService;

        public UserRoleProvider()
        {
            
            _accountService = (IAccountRepository)DependencyResolver.Current.GetService(typeof(AccountRepository));
        }

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            var roles = _accountService.GetUser(username).Roles.ToList();
            return roles.Select(r => r.Name).ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
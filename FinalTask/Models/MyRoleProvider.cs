using FinalTask.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Users.Ioc;

namespace FinalTask.Models
{
    public class MyRoleProvider : RoleProvider
    {
        private static IUserLogic _userLogic = DependencyResolver.UserLogic;
        public override bool IsUserInRole(string username, string roleName)
        {
            
            return username == _userLogic.GetByLogin(username).Login&&roleName=="User";
        }
        public override string[] GetRolesForUser(string username)
        {
            if (username == _userLogic.GetByLogin(username).Login) return new string[] { "User" };
            else return new string[] { };

        }
        #region NOT IMPLEMENTED
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
        public override string[] GetUsersInRole(string roleName)
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
    #endregion
}
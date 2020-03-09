using FinalTask.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Users.Ioc;

namespace FinalTask.Models
{
    public static class CheckUser
    {
        private static ICommonLogic _commonLogic;

        public static bool CheckLogin(string login)
        {
            _commonLogic = DependencyResolver.CommonLogic;
            foreach(var item in _commonLogic.GetUserLogins())
            {
                if (item == login)
                {
                    return true;
                } 
            }
            return false;
        }
        public static bool CheckPassword(string password)
        {
            _commonLogic = DependencyResolver.CommonLogic;
            foreach (var item in _commonLogic.GetUserPasswords())
            {
                if (item == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
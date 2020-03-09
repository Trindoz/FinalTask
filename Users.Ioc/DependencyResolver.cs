using DAL;
using DAL.Interfaces;
using FinalTask.BLL;
using FinalTask.BLL.Interfaces;
using FinalTask.DAL;
using FinalTask.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Ioc
{
    public class DependencyResolver
    {
        private static IUserDao _userDao;
        public static IUserDao UserDao => _userDao ?? (_userDao = new UserDao());
        private static IUserLogic _userLogic;
        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDao));


        private static IAnalystDao _analystDao;
        public static IAnalystDao AnalystDao => _analystDao ?? (_analystDao = new AnalystDao());
        private static IAnalystLogic _analystLogic;
        public static IAnalystLogic AnalystLogic => _analystLogic ?? (_analystLogic = new AnalystLogic(AnalystDao));


        private static ICommonDao _commonDao;
        public static ICommonDao CommonDao => _commonDao ?? (_commonDao = new CommonDao());
        private static ICommonLogic _commonLogic;
        public static ICommonLogic CommonLogic => _commonLogic ?? (_commonLogic = new CommonLogic(CommonDao));
    }
}

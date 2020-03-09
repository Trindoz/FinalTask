using DAL.Interfaces;
using FinalTask.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.BLL
{
    public class CommonLogic:ICommonLogic
    {
        private readonly ICommonDao _commonDao;
        public CommonLogic(ICommonDao commonDao)
        {
            _commonDao = commonDao;
        }
        public List<string> GetUserLogins()
        {
            return _commonDao.GetUserLogins();
        }
        public List<string> GetUserPasswords()
        {
            return _commonDao.GetUserPasswords();
        }
    }
}

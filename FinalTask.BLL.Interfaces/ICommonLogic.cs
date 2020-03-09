using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.BLL.Interfaces
{
    public interface ICommonLogic
    {
        List<string> GetUserLogins();
        List<string> GetUserPasswords();
    }
}

using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.BLL.Interfaces
{
    public interface IUserLogic
    {
        User Add(User user);
        bool Delete(int id);
        User Update(User user);
        User GetById(int id);
        IEnumerable<User> GetAll();
        User GetByLogin(string login);
        List<string> GetLogins();
        List<string> GetPasswords();
        List<string> GetEmails();
    }
}

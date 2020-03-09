using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.DAL.Interfaces
{
    public interface IUserDao
    {
        User Add(User user);
        bool Delete(int id);
        User Update(User user);
        User GetById(int id);
        IEnumerable<User> GetAll();
        User GetUserByLogin(string login);
    }
}

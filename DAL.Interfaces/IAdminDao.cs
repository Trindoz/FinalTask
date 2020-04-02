using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAdminDao
    {
        Admin Add(Admin admin);
        bool Delete(int id);
        Admin Update(Admin admin);
        Admin GetById(int id);
        IEnumerable<Admin> GetAll();
        List<string> GetLogins();
        List<string> GetPasswords();
    }
}

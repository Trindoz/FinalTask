﻿using Entities;
using FinalTask.BLL.Interfaces;
using FinalTask.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userDao;
        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }
        public User Add(User user)
        {
            return _userDao.Add(user);
        }

        public bool Delete(int id)
        {
            return _userDao.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userDao.GetAll();
        }

        public User GetById(int id)
        {
            return _userDao.GetById(id);
        }

        public User GetByLogin(string login)
        {
            return _userDao.GetByLogin(login);
        }

        public List<string> GetEmails()
        {
            return _userDao.GetEmails();
        }

        public List<string> GetLogins()
        {
            return _userDao.GetLogins();
        }

        public List<string> GetPasswords()
        {
            return _userDao.GetPasswords();
        }

        public User Update(User user)
        {
            return _userDao.Update(user);
        }     
    }
}

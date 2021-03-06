﻿using DAL.Interfaces;
using Entities;
using FinalTask.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.BLL
{
    public class AnalystLogic : IAnalystLogic
    {
        private readonly IAnalystDao _analystDao;
        public AnalystLogic(IAnalystDao analystDao)
        {
            _analystDao = analystDao;
        }
        public Analyst Add(Analyst analyst)
        {
            return _analystDao.Add(analyst);
        }

        public bool AddArticle(Article article)
        {
            return _analystDao.AddArticle(article);
        }

        public bool Delete(int id)
        {
            return _analystDao.Delete(id);
        }

        public bool DeleteArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Analyst> GetAll()
        {
            return _analystDao.GetAll();
        }

        public Analyst GetById(int id)
        {
            return _analystDao.GetById(id);
        }

        public List<string> GetEmails()
        {
            return _analystDao.GetEmails();
        }

        public List<string> GetLogins()
        {
            return _analystDao.GetLogins();
        }

        public List<string> GetPasswords()
        {
            return _analystDao.GetPasswords();
        }

        public Analyst Update(Analyst analyst)
        {
            return _analystDao.Update(analyst);
        }
    }
}

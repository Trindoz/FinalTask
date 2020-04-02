using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAnalystDao
    {
        Analyst Add(Analyst analyst);
        bool Delete(int id);
        Analyst Update(Analyst analyst);
        Analyst GetById(int id);
        Analyst GetByLogin(string login);
        List<string> GetLogins();
        List<string> GetPasswords();
        List<string> GetEmails();
        IEnumerable<Analyst> GetAll();
        bool AddArticle(Article article);
        bool DeleteArticle(Article article);
        IEnumerable<Article> GetArticles();
        IEnumerable<Article> GetArticlesByAnalystId(int id);
    }
}

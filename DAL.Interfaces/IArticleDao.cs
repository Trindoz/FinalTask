using System;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IArticleDao
    {
        Article Add(Analyst article);
        bool Delete(int id);
        Article Update(Analyst article);
        Article GetById(int id);
        IEnumerable<Article> GetAll();
    }
}

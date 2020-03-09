using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.BLL.Interfaces
{
    public interface IAnalystLogic
    {
        Analyst Add(Analyst analyst);
        bool Delete(int id);
        Analyst Update(Analyst analyst);
        Analyst GetById(int id);
        IEnumerable<Analyst> GetAll();
        bool AddArticle(int analystid, Article article);
        bool DeleteArticle(int analystid, Article article);
    }
}

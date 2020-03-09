using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICommentDao
    {
        Comment Add(Comment comment);
        bool Delete(int id);
        Comment Update(Comment comment);
        Comment GetById(int id);
        IEnumerable<Comment> GetAll();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Analyst Autor { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }
        public List<Comment> Comments { get; set; }
    }
}

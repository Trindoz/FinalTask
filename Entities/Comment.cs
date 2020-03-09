using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
    }
}

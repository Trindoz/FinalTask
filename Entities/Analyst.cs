using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Analyst
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public DateTime Birthday { get; set; }
        public int Age
        {
            get
            {
                var now = DateTime.Today;
                int age = now.Year - Birthday.Year;
                if (Birthday > now.AddYears(-age)) age--;
                return age;
            }
            private set { }
        }
        public string Role { get { return "Analyst"; } set { } }
        public List<Article> Article { get; set; }
        public int Rating { get; set; }
    }
}

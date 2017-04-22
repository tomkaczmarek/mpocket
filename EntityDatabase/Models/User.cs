using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDatabase.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Login { get; set; } 
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsConfigure { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

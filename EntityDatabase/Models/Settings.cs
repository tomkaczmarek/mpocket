using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDatabase.Models
{
    public class Settings
    {
        public int Id { get; set; }
        public bool IsManual { get; set; }
        public int UserId { get; set; }
    }
}

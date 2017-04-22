using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDatabase.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal StartBudget { get; set; }
        public decimal CurrentBudget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

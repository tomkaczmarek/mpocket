using EntityDatabase.Models;
using MPocket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPocket.ViewsModel
{
    public class BudgetViewModel
    {
        public List<HistoryModel> History { get; set; }
        public List<Budget> Budget { get; set; }
        public IDictionary<Budget, bool> Budgets {get; set;}
    }
}
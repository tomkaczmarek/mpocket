using EntityDatabase.Context;
using EntityDatabase.Models;
using EntityDatabase.Repository.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPocket.Models
{
    public class BudgetModel
    {
        public decimal StartBudget { get; set; }
        public decimal CurrentBudget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public void AddBudget(int userId)
        {
            using (var c = new EntityContext())
            {
                BudgetOperation operation = new BudgetOperation();
                Budget budget = new Budget();
                budget.UserId = userId;
                budget.StartDate = DateTime.Now;
                budget.EndDate = DateTime.Now;
                operation.Add(budget, c);
            }
        }
    }
}
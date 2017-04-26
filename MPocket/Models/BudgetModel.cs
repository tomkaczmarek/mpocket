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
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal StartBudget { get; set; }
        public decimal CurrentBudget { get; set; }
        public decimal AddedBudget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public void AddBudget(BudgetModel model)
        {
            //Budget budget = AutoMapper.Mapper.Map<BudgetModel, Budget>(model);
            Budget budget = new Budget();
            budget.StartBudget = model.StartBudget;
            budget.StartDate = model.StartDate;
            budget.EndDate = model.EndDate;
            budget.CurrentBudget = model.StartBudget;
            budget.UserId = model.UserId;

            using (var c = new EntityContext())
            {
                BudgetOperation operation = new BudgetOperation();
                operation.Add(budget, c);
            }
        }

        public Budget GetCurrentBudget(int userId)
        {
            Budget budget;
            using (var c = new EntityContext())
            {
                BudgetOperation operation = new BudgetOperation();
                budget = operation.GetByUserId(userId, DateTime.Now, c);
            }
            return budget;
        }

        public int GetCurrentBudgetId(int userId)
        {
            int budgetid = 0;

            using (var c = new EntityContext())
            {
                BudgetOperation operation = new BudgetOperation();
                budgetid = operation.GetCurrentBudgetId(userId, DateTime.Now, c);
            }

            return budgetid;
        }

        public void UpdateBudget(Budget budget)
        {
            using (var c = new EntityContext())
            {
                BudgetOperation operation = new BudgetOperation();
                operation.Update(budget, c);
            }
        }
    }
}
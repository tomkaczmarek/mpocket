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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public void AddBudget(BudgetModel model)
        {
            //Budget budget = AutoMapper.Mapper.Map<BudgetModel, Budget>(model);
            Budget budget = new Budget();
            budget.StartBudget = model.StartBudget;
            budget.StartDate = model.StartDate;
            budget.EndDate = model.EndDate;
            budget.CurrentBudget = model.CurrentBudget;
            budget.UserId = model.UserId;

            using (var c = new EntityContext())
            {
                BudgetOperation operation = new BudgetOperation();
                operation.Add(budget, c);
            }
        }

        public Budget GetBudget(int userId)
        {
            Budget budget;
            using (var c = new EntityContext())
            {
                BudgetOperation operation = new BudgetOperation();
                budget = operation.GetByUserId(userId, c);
            }
            return budget;
        }
    }
}
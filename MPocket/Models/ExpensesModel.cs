using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityDatabase.Repository.Operation;
using EntityDatabase.Models;
using MPocket.ViewsModel;
using EntityDatabase.Context;
using EntityDatabase.Repository;

namespace MPocket.Models
{
    public class ExpensesModel
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }


        public void Save(ExpensesModel expeModel)
        {
            using (var c = new EntityContext())
            {
                ExpensesOperation operation = new ExpensesOperation();
                Expenses dto = new Expenses();
                dto.Amount = Amount;
                dto.Description = Description;
                dto.BudgetId = expeModel.BudgetId;
                operation.Add(dto, c);
            }                      
        }

        public List<Expenses> GetAll(int budgetId)
        {
            List<Expenses> expe = new List<Expenses>();
            using (var c = new EntityContext())
            {
                ExpensesOperation operation = new ExpensesOperation();
                expe = operation.GetAll(budgetId, c);
            }

            return expe;
               
        }
    }
}
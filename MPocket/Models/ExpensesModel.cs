using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityDatabase.Repository.Operation;
using EntityDatabase.Models;

namespace MPocket.Models
{
    public class ExpensesModel
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }


        public void Save()
        {
            using (var c = new EntityDatabase.Context.EntityContext())
            {
                ExpensesOperation operation = new ExpensesOperation();
                Expenses dto = new Expenses();
                dto.Amount = Amount;
                dto.Description = Description;
                operation.Add(dto, c);
            }                      
        }
    }
}
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


        public void Save(int userId)
        {
            using (var c = new EntityDatabase.Context.EntityContext())
            {
                ExpensesOperation operation = new ExpensesOperation();
                Expenses dto = new Expenses();
                UserModel model = new UserModel();
                User user = model.GetById(userId);
                dto.Amount = Amount;
                dto.Description = Description;
                dto.UserId = userId;
                operation.Add(dto, c);
            }                      
        }
    }
}
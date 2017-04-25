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
        public int UserId { get; set; }
        public int BudgetId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }


        public void Save(int userId)
        {
            using (var c = new EntityContext())
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

        public List<Expenses> GetAll(int userid)
        {
            List<Expenses> expe = new List<Expenses>();
            using (var c = new EntityContext())
            {
                ExpensesOperation operation = new ExpensesOperation();
                expe = operation.GetAll(userid, c);
            }

            return expe;
               
        }
    }
}
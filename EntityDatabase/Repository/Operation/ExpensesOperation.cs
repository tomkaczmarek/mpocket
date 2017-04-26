using EntityDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityDatabase.Context;

namespace EntityDatabase.Repository.Operation
{
    public class ExpensesOperation : IRepository<Expenses>
    {
        public void Add(Expenses item, EntityContext context)
        {
            context.Expenses.Add(item);
            context.SaveChanges();                     
        }

        public void Delete(Expenses item)
        {
            throw new NotImplementedException();
        }

        public Expenses Get(int id, EntityContext context)
        {
            throw new NotImplementedException();
        }

        public void Update(Expenses item, EntityContext context)
        {
            throw new NotImplementedException();
        }

        public List<Expenses> GetAll(int budgetId, EntityContext context)
        {
            return context.Expenses.Where(i => i.BudgetId == budgetId).ToList();
        }
    }
}

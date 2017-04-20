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

        public Expenses Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Expenses item)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityDatabase.Context;
using EntityDatabase.Models;

namespace EntityDatabase.Repository.Operation
{
    public class BudgetOperation : IRepository<Budget>
    {
        public void Add(Budget item, EntityContext context)
        {
            context.Budget.Add(item);
            context.SaveChanges();
        }

        public void Delete(Budget item)
        {
            throw new NotImplementedException();
        }

        public Budget Get(int id, EntityContext context)
        {
            return context.Budget.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Update(Budget item, EntityContext context)
        {
            throw new NotImplementedException();
        }

        public Budget GetByUserId(int userId, DateTime now, EntityContext context)
        {
            return context.Budget.Where(p => p.UserId == userId && p.StartDate <= now && p.EndDate >= now).FirstOrDefault();
        }

        public int GetCurrentBudgetId(int userId, DateTime now, EntityContext context)
        {
            return context.Budget.Where(p => p.UserId == userId && p.StartDate <= now && p.EndDate >= now).Select(i => i.Id).FirstOrDefault();
        }
    }
}

using EntityDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EntityDatabase.Context;

namespace EntityDatabase.Repository.Operation
{
    public class UsersOperation : IRepository<User>
    {
        public void Add(User item, EntityContext context)
        {
            context.User.Add(item);
            context.SaveChanges();
        }

        public void Delete(User item)
        {
            
        }

        public User Get(int id, EntityContext context)
        {
            return context.User.Where(i => i.Id == id).FirstOrDefault();
        }

        public User GetByLogin(string login, EntityContext context)
        {
            User user;
            user = context.User.Where(l => l.Login == login).FirstOrDefault();
            return user;
        }

        public void Update(User item, EntityContext context)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public int AddAndGetId(User item, EntityContext context)
        {
            context.User.Add(item);
            context.SaveChanges();
            context.Entry(item).GetDatabaseValues();
            return item.Id;
        }
    }
}

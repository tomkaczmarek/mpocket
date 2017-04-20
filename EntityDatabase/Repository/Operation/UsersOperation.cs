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
    public class UsersRepository : IRepository<User>
    {
        public void Add(User item, EntityContext context)
        {
            throw new NotImplementedException();
        }

        public void Delete(User item)
        {
            
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            
        }
    }
}

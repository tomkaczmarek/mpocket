using EntityDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDatabase.Context
{
    public class EntityContext : DbContext
    {
        public DbSet<User> User { get; set; }
    }
}

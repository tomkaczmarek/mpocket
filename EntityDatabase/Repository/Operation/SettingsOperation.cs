using EntityDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityDatabase.Context;

namespace EntityDatabase.Repository.Operation
{
    public class SettingsOperation : IRepository<Settings>
    {
        public void Add(Settings item, EntityContext context)
        {
            context.Settings.Add(item);
            context.SaveChanges();
        }

        public void Delete(Settings item)
        {
            throw new NotImplementedException();
        }

        public Settings Get(int id, EntityContext context)
        {
            return context.Settings.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Update(Settings item, EntityContext context)
        {
            throw new NotImplementedException();
        }

        public Settings GetByUserId(int userid , EntityContext context)
        {
            return context.Settings.Where(p => p.UserId == userid).FirstOrDefault();
        }
    }
}

using EntityDatabase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityDatabase.Repository
{
    public interface IRepository<T>
    {
        void Add(T item, EntityContext context);
        void Update(T item);
        void Delete(T item);
        T Get(int id);
    }
}

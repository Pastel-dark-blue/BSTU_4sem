using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10.Repository
{
    public interface IRepository<Entity> where Entity : class
    {
        List<Entity> GetAll();
        List<Entity> Find(System.Linq.Expressions.Expression<Func<Entity, bool>> predicate);

        void Add(Entity entity);

        void Remove(Entity entity);
        
        void Update(Entity entity);
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lab10.Repository
{
    public class Repository<Entity> : IRepository<Entity> where Entity : class
    {
        protected readonly ShopDBContext _context;
        protected DbSet<Entity> _entities;

        public Repository()
        {
            _context = new ShopDBContext();
            _entities = _context.Set<Entity>();
        }

        // получаем в конструктор текущий контект выполнения
        public Repository(ShopDBContext context)
        {
            _context = context;
            _entities = _context.Set<Entity>();
        }

        public List<Entity> GetAll()
        {
            return _entities.ToList();
        }

        public List<Entity> Find(Expression<Func<Entity, bool>> predicate)
        {
            return _entities.Where(predicate).ToList();
        }

        public void Add(Entity entity)
        {
            _entities.Add(entity);
        }

        public void Remove(Entity entity)
        {
            _entities.Attach(entity);
            _entities.Remove(entity);
            //_context.Entry(entity).State = EntityState.Deleted;
        }

        public void Update(Entity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}

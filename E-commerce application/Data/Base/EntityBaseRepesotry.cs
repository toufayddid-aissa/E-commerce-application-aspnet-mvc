using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_commerce_application.Data.Base
{
    public class EntityBaseRepesotry<T> : IEntityBaseRepesotry<T> where T : class, IEntityBase, new()
    {

        private AddDbContext _context;
        public EntityBaseRepesotry(AddDbContext context)
        {
            _context = context;

        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = _context.Set<T>().FirstOrDefault(e => e.Id == id);
            _context.Set<T>().Remove(data);
            _context.SaveChanges();
        }


        public IEnumerable<T> GetAll()
        {
            var result = _context.Set<T>().ToList();
            return result;
        }

        /*   public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
           {
               IQueryable<T> query = _context.Set<T>();
               foreach (var includeProperty in includeProperties)
               {
                   query = query.Include(includeProperty);
               }
               return query.ToList() ;
           }*/
        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
       
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            

            return await query.ToListAsync();
        }

        public T GetById(int id)
        {
            var data = _context.Set<T>().FirstOrDefault(e => e.Id == id);
            return data;
        }

        public T Update(int id, T NewEntity)
        {
            _context.Set<T>().Update(NewEntity);
            _context.SaveChanges();
            return NewEntity;
        }
    }
}

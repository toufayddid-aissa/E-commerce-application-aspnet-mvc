using System.Linq.Expressions;

namespace E_commerce_application.Data.Base
{
    public interface IEntityBaseRepesotry<T> where T : class, IEntityBase, new()
    {
        IEnumerable<T> GetAll();

        // TO INCLUDE OR JOIN OTHER CLASS WITH T
        //IQueryable<T> GetAll( params Expression<Func<T, object>>[] includeProperties);
        //IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        T GetById(int id);
        void Add(T entity);

        T Update(int id, T NewEntity);
        void Delete(int id);
    }

}
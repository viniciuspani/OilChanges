using System.Linq.Expressions;

namespace OilChanges.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();

        T GetById(Expression<Func<T, bool>> predicate);
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}

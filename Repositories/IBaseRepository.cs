using System.Linq.Expressions;

namespace Api.Repositories;

public interface IBaseRepository<T>
{
    public T? GetById(int id);
    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    public void Add(T entity);
    public void Update(T entity);
    public void Delete(T entity);
}
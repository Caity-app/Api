using System.Linq.Expressions;

namespace Api.Repositories;

public interface IBaseRespository<T>
{
    public Task<T> GetAsync(int id);
    public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    public void Add(T entity);
    public void Update(T entity);
    public void Delete(T entity);
}
using System.Linq.Expressions;

namespace _0_Framework.Domain;

public interface IRepository<in TKey, T> where T : class
{
    T? Get(TKey id);
    List<T> GetAll();
    List<T> Get(params Expression<Func<T, bool>>[] predicate);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    bool Exists(params Expression<Func<T, bool>>[] predicate);
    void CommitTransaction();
}
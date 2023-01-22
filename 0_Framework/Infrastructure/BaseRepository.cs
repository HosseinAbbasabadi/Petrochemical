using System.Linq.Expressions;
using _0_Framework.Domain;
using Microsoft.EntityFrameworkCore;

namespace _0_Framework.Infrastructure;

public class BaseRepository<TKey, T> : IRepository<TKey, T> where T : class
{
    private readonly DbContext _context;

    public BaseRepository(DbContext context)
    {
        _context = context;
    }

    public T? Get(TKey id)
    {
        return _context.Find<T>(id);
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public List<T> Get(params Expression<Func<T, bool>>[] predicate)
    {
        //expression: x => x.name == "a"
        var query = _context.Set<T>().AsQueryable();

        return predicate
            .Aggregate(query, (current, expression)
                => current.Where(expression))
            .ToList();
    }

    public void Create(T entity)
    {
        _context.Add(entity);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
    }

    public bool Exists(params Expression<Func<T, bool>>[] predicate)
    {
        var query = _context.Set<T>().AsQueryable();

        return predicate
            .Aggregate(query, (current, expression)
                => current.Where(expression))
            //.LongCount()
            //.Count()
            .Any();
    }

    public void CommitTransaction()
    {
        try
        {
            _context.SaveChanges();
        }
        catch (Exception)
        {
            var entityEntries = _context.ChangeTracker
                .Entries()
                .Where(x => x.State is EntityState.Added 
                    or EntityState.Modified 
                    or EntityState.Deleted)
                .ToList();

            foreach (var entityEntry in entityEntries)
                entityEntry.State = EntityState.Detached;

            throw;
        }
    }
}
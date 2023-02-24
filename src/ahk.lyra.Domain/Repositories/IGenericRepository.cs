using ahk.lyra.Domain.Entities;
using System.Linq.Expressions;

namespace ahk.lyra.Domain.Repositories
{
    public interface IGenericRepository<T> : IDisposable where T : BaseEntity
    {
        Task<bool> Add(T entity);
        Task<T> GetById(int id);
        Task<List<T>> ListAll();
        Task<T> FindOne(Expression<Func<T, bool>> predicate);
        Task<bool> Exists(Expression<Func<T, bool>> predicate);
        Task Update(T entity);
        Task<bool> Delete(Guid Id);
        Task<int> SaveChanges();
    }
}

using ahk.lyra.Domain.Entities;
using ahk.lyra.Domain.Repositories;
using ahk.lyra.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ahk.lyra.Infra.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly MyAppContext _context;
        protected readonly DbSet<T> DbSet;

        protected GenericRepository(MyAppContext context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }

        public async Task<List<T>> ListAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            DbSet.Add(entity);
            return await SaveChanges() > 0;
        }

        public async Task<T?> FindOne(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<bool> Exists(Expression<Func<T, bool>> criteria)
        {
            var result = await DbSet.AsNoTracking().Where(criteria).ToListAsync();
            return result.Any();
        }

        public async Task Update(T entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<bool> Delete(Guid Id)
        {
            var usuario = await DbSet.SingleAsync(x => x.Id == Id);
            DbSet.Remove(usuario);
            return await SaveChanges() > 0;
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}

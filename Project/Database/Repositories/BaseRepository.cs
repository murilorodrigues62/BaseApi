using Project.Model;
using Microsoft.EntityFrameworkCore;
using Project.Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Database.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly BaseApiContext _baseApiContext;
        private readonly DbSet<T> _dbSet;

        public DbSet<T> DbSet => _dbSet;

        public BaseRepository(BaseApiContext baseApiContext)
        {
            _baseApiContext = baseApiContext;
            _dbSet = baseApiContext.Set<T>();
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> FindByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<Guid> CreateAsync(T entity)
        {
            var entityCreated = await _dbSet.AddAsync(entity);
            await _baseApiContext.SaveChangesAsync();
            return entityCreated.Entity.Id;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _baseApiContext.Entry(entity).State = EntityState.Modified;
            return await _baseApiContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _dbSet.Remove(entity);
            await _baseApiContext.SaveChangesAsync();

            return true;
        }
    }
}

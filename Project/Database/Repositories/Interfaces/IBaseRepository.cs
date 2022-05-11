using Project.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Database.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        DbSet<T> DbSet { get; }
        Task<IEnumerable<T>> ListAsync();
        Task<T> FindByIdAsync(Guid id);
        Task<Guid> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
    }
}

using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> ListAsync();
        Task<Customer> FindByIdAsync(Guid id);
        Task<Guid> CreateAsync(Customer entity);
        Task<int> UpdateAsync(Customer entity);
        Task<bool> DeleteAsync(Guid id);
    }
}

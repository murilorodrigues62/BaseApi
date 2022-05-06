using Project.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Services.Interfaces
{
    public interface ICustomerService
    {        
        Task<CustomerDTO> FindByIdAsync(Guid id);

        Task<IEnumerable<CustomerDTO>> ListAsync();
        
        Task<Guid> CreateAsync(CustomerDTO entity);
        Task<int> UpdateAsync(CustomerDTO entity);
        Task<bool> DeleteAsync(Guid id);
    }
}

using Mapster;
using Project.Database.Repositories.Interfaces;
using Project.DTO;
using Project.Model;
using Project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // TODO - Input data in CreatedAt and LastModifiedAt
        public async Task<Guid> CreateAsync(CustomerDTO entity) => await _customerRepository.CreateAsync(entity.Adapt<Customer>());            

        public async Task<bool> DeleteAsync(Guid id) => await _customerRepository.DeleteAsync(id);        

        public async Task<CustomerDTO> FindByIdAsync(Guid id) => (await _customerRepository.FindByIdAsync(id)).Adapt<CustomerDTO>();

        public async Task<IEnumerable<CustomerDTO>> ListAsync() => (await _customerRepository.ListAsync()).Adapt<IEnumerable<CustomerDTO>>();

        // TODO - Update LastModifiedAt
        public async Task<int> UpdateAsync(CustomerDTO entity) => await _customerRepository.UpdateAsync(entity.Adapt<Customer>());        
    }
}

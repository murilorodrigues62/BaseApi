using Project.Database.Repositories.Interfaces;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Database.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IBaseRepository<Customer> _baseRepository;

        public CustomerRepository(IBaseRepository<Customer> baseRepository) => _baseRepository = baseRepository;        

        public async Task<Guid> CreateAsync(Customer entity) => await _baseRepository.CreateAsync(entity);

        public async Task<bool> DeleteAsync(Guid id) => await _baseRepository.DeleteAsync(id);

        public async Task<Customer> FindByIdAsync(Guid id) => await _baseRepository.FindByIdAsync(id);

        public async Task<IEnumerable<Customer>> ListAsync() => await _baseRepository.ListAsync();        

        public async Task<int> UpdateAsync(Customer entity) => await _baseRepository.UpdateAsync(entity);        
    }
}

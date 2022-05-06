using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Model;
using Project.Database.Repositories.Interfaces;
using Project.Services.Interfaces;
using Project.DTO;

namespace Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {        
        private readonly ICustomerService _customerService;        

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
        {
            var result = await _customerService.ListAsync();

            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(Guid id)
        {
            var customer = await _customerService.FindByIdAsync(id);

            if (customer == null)
                return NotFound();

            return customer;
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(Guid id, CustomerDTO customerDTO)
        {
            if (id == Guid.Empty)
                return BadRequest();

            customerDTO.Id = id;

            try
            {
                await _customerService.UpdateAsync(customerDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                var customerExists = await _customerService.FindByIdAsync(id);

                if (customerExists != null)
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CustomerDTO customerDTO)
        {
            customerDTO.Id = await _customerService.CreateAsync(customerDTO);

            return CreatedAtAction(nameof(GetCustomer), new { id = customerDTO.Id }, customerDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var result = await _customerService.DeleteAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}

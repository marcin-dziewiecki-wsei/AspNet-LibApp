using AutoMapper;
using LibApp.Data.Repository.Interfaces;
using LibApp.Domain.Dtos;
using LibApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CustomersController(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        // GET /api/customers
        [HttpGet]
        public async Task<IActionResult> GetCustomers(string query = null)
        {
            var customers = await customerRepository.GetAllFilteredByNameWithMembershipTypesAsync(query);
            var response = customers.Select(mapper.Map<Customer, CustomerDto>);

            return Ok(response);
        }

        // GET /api/customers/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await customerRepository.GetByIdAsync(id);

            if (customer is null)
                return NotFound();

            var response = mapper.Map<CustomerDto>(customer);

            return Ok(response);
        }

        // POST /api/customers/
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = mapper.Map<Customer>(customerDto);
            var response = await customerRepository.AddAsync(customer);
            customerDto.Id = response;

            return Ok(customerDto);
        }

        // PUT api/customers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = mapper.Map<Customer>(customerDto);

            if (await customerRepository.UpdateAsync(customer))
                return Ok();

            return NotFound();
        }

        // DELETE /api/customers
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (await customerRepository.DeleteByIdAsync(id))
                return Ok();

            return NotFound();
        }
    }
}
